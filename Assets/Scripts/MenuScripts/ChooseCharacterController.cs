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

    [SerializeField] float menuSlideSpeed;

    private PriceSetting priceSetting;

    private void Start()
    {
        priceSetting = FindObjectOfType<PriceSetting>();
        
        if (playerCoinData.avaliableCoin < 0)
        {
            playerCoinData.avaliableCoin = 0;
        }
        //ResetTheCharacters();
        //playerData.avaliableCharacters[0] = "Dobby";
        _playerController = FindObjectOfType<PlayerController>();


        CharacterPriceError();
        GetCharacterUnLockData();



        //infoPanel = new GameObject[gameObject.transform.GetChild(1).GetChild(0).childCount];

        SetCharacterInfos();
        

        //ResetTheCharacters();

        //characterLockStatesTextsObject = GameObject.Find("CharacterLockStatesTexts");
    }

    void GetCharacterUnLockData()
    {
        if (PlayerPrefs.GetFloat("DobbyLock") == 1)
        {
            playerData.dobbyLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("JoleenLock") == 1)
        {
            playerData.joleenLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("GlassyLock") == 1)
        {
            playerData.glassyLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("LusthLock") == 1)
        {
            playerData.lusthLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("GuardLock") == 1)
        {
            playerData.guardLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("MichelleLock") == 1)
        {
            playerData.michelleLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("EveLock") == 1)
        {
            playerData.eveLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("AjLock") == 1)
        {
            playerData.ajLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("BossLock") == 1)
        {
            playerData.bossLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("TyLock") == 1)
        {
            playerData.tyLock = playerData.unLocked;
        }
        if (PlayerPrefs.GetFloat("MremirehLock") == 1)
        {
            playerData.mremirehLock = playerData.unLocked;
        }
        if (priceSetting)
        {
            priceSetting.SetCharacterPrices();
        }        
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
            playerData.characterStaffs = new Dictionary<int, GameObject>();

            //Debug.Log(characterStaffs.Length);
            for (int i = 0; i < characterStaffs.Length; i++)
            {
                playerData.characterStaffs[i] = characterStaffs[i];
            }

            for (int i = 0; i < playerData.characterStaffs.Count; i++)
            {
                
                if (playerData.characterStaffs[i].name == "DobbyStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.dobbySpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.dobbyJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.dobbyDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "JoleenStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.joleenSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.joleenJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.joleenDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "GlassyStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.glassySpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.glassyJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.glassyDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "LusthStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.lusthSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.lusthJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.lusthDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "GuardStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.guardSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.guardJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.guardDurability.ToString();

                }
                else if (playerData.characterStaffs[i].name == "MichelleStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.michelleSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.michelleJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.michelleDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "EveStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.eveSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.eveJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.eveDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "AjStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.ajSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.ajJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.ajDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "BossStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.bossSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.bossJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.bossDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "TyStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.tySpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.tyJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.tyDurability.ToString();
                }
                else if (playerData.characterStaffs[i].name == "MremirehStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.mremirehSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.mremirehJumpForce.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = playerData.mremirehDurability.ToString();
                }
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
            PickJoleen(playerData.joleenPrice);
            PickGlassy(playerData.glassyPrice);
            PickDobby(playerData.dobbyPrice);
            PickLusth(playerData.lusthPrice);
            PickGuard(playerData.guardPrice);
            PickEve(playerData.evePrice);
            PickMichelle(playerData.michellePrice);
            PickBoss(playerData.bossPrice);
            PickAj(playerData.ajPrice);
            PickMremireh(playerData.mremirehPrice);
            PickTy(playerData.tyPrice);
        }       
    }
    void SlideMenu()
    {
        if (_playerController.characterStick.x < 0f)
        {
            _panelObject.transform.position = new Vector3(_panelObject.transform.position.x - menuSlideSpeed * Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
        }
        if (_playerController.characterStick.x > 0f)
        {
            _panelObject.transform.position = new Vector3(_panelObject.transform.position.x + menuSlideSpeed * Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
        }
        if (_panelObject.transform.localPosition.x > 0)
        {
            _panelObject.transform.localPosition = new Vector3(0f, _panelObject.transform.localPosition.y, _panelObject.transform.localPosition.z);
        }
        if (_panelObject.transform.localPosition.x < -9000)
        {
            _panelObject.transform.localPosition = new Vector3(-9000f, _panelObject.transform.localPosition.y, _panelObject.transform.localPosition.z);
        }
    }
    
    public void PickJoleen(int avaliableCoinAmount)
    {
        if (ButtonController.Joleen && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Joleen)
        {
            if (playerData.joleenLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);                

                playerData.joleenLock = playerData.unLocked;

                PlayerPrefs.SetFloat("JoleenLock", 1);
            }

            playerData.currentCharacterName = PlayerData.CharacterNames.Joleen;

            characterPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();            

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        }
        else if (ButtonController.Joleen && playerData.joleenLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Joleen;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.joleenLock == playerData.locked)
        {
            if (ButtonController.Joleen)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "JoleenPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    
    public void PickDobby(int avaliableCoinAmount)
    {
        if (ButtonController.Dobby && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Dobby)
        {
            if (playerData.dobbyLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);                

                playerData.dobbyLock = playerData.unLocked;                
            }

            playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Dobby && playerData.dobbyLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.dobbyLock == playerData.locked)
        {
            if (ButtonController.Dobby)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "DobbyPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }

    }
    public void PickGlassy(int avaliableCoinAmount)
    {
        if (ButtonController.Glassy && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Glassy)
        {
            if (playerData.glassyLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.glassyLock = playerData.unLocked;

                PlayerPrefs.SetFloat("GlassyLock", 1);
            }

            characterPriceErrorTextObjectChilds[2].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Glassy;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Glassy && playerData.glassyLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Glassy;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.glassyLock == playerData.locked)
        {
            if (ButtonController.Glassy)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "GlassyPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickLusth(int avaliableCoinAmount)
    {
        if ((ButtonController.Lusth) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Lusth )
        {
            if (playerData.lusthLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.lusthLock = playerData.unLocked;

                PlayerPrefs.SetFloat("LusthLock", 1);
            }

            characterPriceErrorTextObjectChilds[3].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Lusth;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Lusth && playerData.lusthLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Lusth;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.lusthLock == playerData.locked)
        {
            if (ButtonController.Lusth)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "LusthPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickGuard(int avaliableCoinAmount)
    {
        if ((ButtonController.Guard) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Guard)
        {
            if (playerData.guardLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.guardLock = playerData.unLocked;

                PlayerPrefs.SetFloat("GuardLock", 1);
            }

            characterPriceErrorTextObjectChilds[4].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Guard;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Guard && playerData.guardLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Guard;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.guardLock == playerData.locked)
        {
            if (ButtonController.Guard)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "GuardPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickEve(int avaliableCoinAmount)
    {
        if ((ButtonController.Eve) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Eve)
        {
            if (playerData.eveLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.eveLock = playerData.unLocked;

                PlayerPrefs.SetFloat("EveLock", 1);
            }

            characterPriceErrorTextObjectChilds[5].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Eve;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Eve && playerData.eveLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Eve;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.eveLock == playerData.locked)
        {
            if (ButtonController.Eve)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "EvePriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickMichelle(int avaliableCoinAmount)
    {
        if ((ButtonController.Michelle) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Michelle)
        {
            if (playerData.michelleLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.michelleLock = playerData.unLocked;

                PlayerPrefs.SetFloat("MichelleLock", 1);
            }

            characterPriceErrorTextObjectChilds[6].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Michelle;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Michelle && playerData.michelleLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Michelle;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.michelleLock == playerData.locked)
        {
            if (ButtonController.Michelle)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }

            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "MichellePriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickBoss(int avaliableCoinAmount)
    {
        if ((ButtonController.Boss) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Boss)
        {
            if (playerData.bossLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.bossLock = playerData.unLocked;

                PlayerPrefs.SetFloat("BossLock", 1);
            }

            characterPriceErrorTextObjectChilds[7].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Boss;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Boss && playerData.bossLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Boss;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.bossLock == playerData.locked)
        {
            if (ButtonController.Boss)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "BossPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickAj(int avaliableCoinAmount)
    {
        if ((ButtonController.Aj) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Aj)
        {
            if (playerData.ajLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.ajLock = playerData.unLocked;

                PlayerPrefs.SetFloat("AjLock", 1);
            }

            characterPriceErrorTextObjectChilds[8].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Aj;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Aj && playerData.ajLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Aj;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }       
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.ajLock == playerData.locked)
        {
            if (ButtonController.Aj)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "AjPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }

    public void PickMremireh(int avaliableCoinAmount)
    {
        if ((ButtonController.Mremireh) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Mremireh)
        {
            if (playerData.mremirehLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.mremirehLock = playerData.unLocked;

                PlayerPrefs.SetFloat("MremirehLock", 1);
            }

            characterPriceErrorTextObjectChilds[9].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Mremireh;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Mremireh && playerData.mremirehLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Mremireh;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
       
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.mremirehLock == playerData.locked)
        {
            if (ButtonController.Mremireh)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "MremirehPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }

    public void PickTy(int avaliableCoinAmount)
    {
        if ((ButtonController.Ty) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Ty)
        {
            if (playerData.tyLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                playerData.tyLock = playerData.unLocked;

                PlayerPrefs.SetFloat("TyLock", 1);
            }

            characterPriceErrorTextObjectChilds[10].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Ty;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Ty && playerData.tyLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Ty;

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.tyLock == playerData.locked)
        {
            if (ButtonController.Ty)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < characterPriceErrorTextObjectChilds.Length; i++)
            {
                if (characterPriceErrorTextObjectChilds[i].gameObject.name == "TyPriceErrorText")
                {
                    characterPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
}
