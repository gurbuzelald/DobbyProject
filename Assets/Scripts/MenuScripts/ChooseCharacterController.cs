using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ChooseCharacterController : MonoBehaviour
{
    [SerializeField] GameObject _panelObject;
    [SerializeField] PlayerData playerData;
    [SerializeField] PlayerCoinData playerCoinData;
    [SerializeField] LevelData levelData;


    private PlayerController _playerController;

    public GameObject[] characterPriceErrorTextObjects;
    private TextMeshProUGUI[] characterPriceErrorTextObjectChilds;

    public GameObject[] characterStaffs;
    public GameObject[] infoPanels;

    [SerializeField] float menuSlideSpeed;

    private PriceSetting priceSetting;

    [SerializeField] GameObject[] holoCharacterObjects;
    [SerializeField] GameObject[] normalCharacterObjects;

    [SerializeField] ButtonController buttonController;

    private void Start()
    {
        priceSetting = FindObjectOfType<PriceSetting>();
        
        if (playerCoinData.avaliableCoin < 0)
        {
            playerCoinData.avaliableCoin = 0;
        }

        _playerController = FindObjectOfType<PlayerController>();


        CharacterPriceError();

        SetCharacterUnLockData();

        SetCharacterInfos();

        SetCharacterHoloOrNormalAtStart();
    }

    void SetCharacterHoloOrNormalAtStart()
    {
        for (int i = 0; i < playerData.characterStruct.Length; i++)
        {
            bool isLocked = playerData.characterStruct[i].lockState == PlayerData.locked;
            holoCharacterObjects[i].SetActive(isLocked);
            normalCharacterObjects[i].SetActive(!isLocked);
        }
    }

    void SetCharacterUnLockData()
    {
        // Array of lock keys corresponding to each character
        string[] lockKeys = {
        "ALock", "BLock", "CLock",
        "DLock", "ELock", "FLock",
        "GLock", "HLock", "ILock",
        "JLock", "KLock"
    };

        // Iterate through each character and set the lock state based on PlayerPrefs
        for (int i = 0; i < lockKeys.Length; i++)
        {
            if (PlayerPrefs.GetFloat(lockKeys[i]) == 1)
            {
                playerData.characterStruct[i].lockState = PlayerData.unLocked;
            }
        }

        // Call SetCharacterPrices if priceSetting is not null
        priceSetting?.SetCharacterPrices();
    }


    void CharacterPriceError()
    {

        if (characterPriceErrorTextObjects.Length != 0)
        {
            characterPriceErrorTextObjectChilds = new TextMeshProUGUI[characterPriceErrorTextObjects.Length];

            for (int i = 0; i < characterPriceErrorTextObjects.Length; i++)
            {
                characterPriceErrorTextObjectChilds[i] = characterPriceErrorTextObjects[i].transform.GetComponent<TextMeshProUGUI>();
            }
        }

       
    }
    
    void SetCharacterInfos()
    {
        if (gameObject.transform.GetChild(1).gameObject.name == "CharacterPanel")
        {
            PlayerData.characterInfos = new Dictionary<int, GameObject>();

            //Debug.Log(characterStaffs.Length);
            for (int i = 0; i < characterStaffs.Length; i++)
            {
                PlayerData.characterInfos[i] = infoPanels[i];
            }

            SetCharacterStaffs();
        }
    }

    void SetCharacterStaffs()
    {
        // Create a dictionary to map staff names to their corresponding indices
        var staffNameToIndex = new Dictionary<string, int>
    {
        { "AStaff", 0 },
        { "BStaff", 1 },
        { "CStaff", 2 },
        { "DStaff", 3 },
        { "EStaff", 4 },
        { "FStaff", 5 },
        { "GStaff", 6 },
        { "HStaff", 7 },
        { "IStaff", 8 },
        { "JStaff", 9 },
        { "KStaff", 10 }
    };

        for (int i = 0; i < PlayerData.characterInfos.Count; i++)
        {
            var staff = PlayerData.characterInfos[i];
            string staffName = staff.transform.parent.name;

            // Try to get the index from the dictionary
            if (staffNameToIndex.TryGetValue(staffName, out int index))
            {
                // Get the corresponding stats based on the index
                var characterStat = playerData.characterStruct[index];

                // Update TextMeshProUGUI fields
                var textFields = staff.transform.GetChild(0);
                textFields.GetChild(0).GetComponent<TextMeshProUGUI>().text = characterStat.speed.ToString();
                textFields.GetChild(1).GetComponent<TextMeshProUGUI>().text = characterStat.jumpForce.ToString();
                textFields.GetChild(2).GetComponent<TextMeshProUGUI>().text = characterStat.durability.ToString();
            }
            else
            {
                // Handle the case where the staff name is not recognized
                Debug.LogWarning($"Unrecognized staff name: {staffName}");
            }
        }
    }


    void Update()
    {
        SlideMenu();
        CharacterPickStates();
    }
    void CharacterPickStates()
    {
        if (characterPriceErrorTextObjects.Length != 0)
        {
            // Array of lock keys corresponding to each character
            string[] lockKeys = {
            "ALock", "BLock", "CLock",
            "DLock", "ELock", "FLock",
            "GLock", "HLock", "ILock",
            "JLock", "KLock"
        };

            // Iterate through each character and pick their state
            for (int i = 0; i < playerData.characterStruct.Length; i++)
            {
                var character = playerData.characterStruct[i];
                PickCharacter(character.id, ref character.lockState, character.price, character.id, lockKeys[i]);
            }
        }
    }


    void SlideMenu()
    {
        // Calculate the change in position based on input
        float deltaX = PlayerController.GetCharacterStick().x * menuSlideSpeed * Time.deltaTime;

        // Update the current position
        Vector3 currentPosition = _panelObject.transform.position;
        currentPosition.x += deltaX;

        // Clamp the x position to the limits
        currentPosition.x = Mathf.Clamp(currentPosition.x, -9000f, 0f);

        // Apply the new position
        _panelObject.transform.position = currentPosition;
    }

    public void PickCharacter(int characterID, ref string characterLock, int characterPrice, int characterIndex, string lockKey)
    {
        if (buttonController.GetCharacterButtonState(characterID) && playerCoinData.avaliableCoin >= characterPrice &&
            PlayerData.currentCharacterID != characterID)
        {
            if (characterLock == PlayerData.locked)
            {
                playerCoinData.avaliableCoin -= characterPrice;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                characterLock = PlayerData.unLocked;
                PlayerPrefs.SetFloat(lockKey, 1);
            }

            characterPriceErrorTextObjectChilds[characterIndex].text = "";

            PlayerData.currentCharacterID = characterID;

            PlayerPrefs.SetInt("CurrentCharacterID", PlayerData.currentCharacterID);

            SceneController.LoadMenuScene();
        }
        else if (buttonController.GetCharacterButtonState(characterID) && characterLock == PlayerData.unLocked)
        {
            PlayerData.currentCharacterID = characterID;

            PlayerPrefs.SetInt("CurrentCharacterID", PlayerData.currentCharacterID);

            SceneController.LoadMenuScene();
        }
        else if ((characterPrice - playerCoinData.avaliableCoin) > 0 && characterLock == PlayerData.locked)
        {
            if (buttonController.GetCharacterButtonState(characterID))
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }

            string errorMessage = PlayerData.currentLanguage == PlayerData.Languages.Turkish ?
                "Satin Almak İçİn " + (characterPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!" :
                "You need " + (characterPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";

            characterPriceErrorTextObjectChilds[characterIndex].text = errorMessage;
        }
    }
}
