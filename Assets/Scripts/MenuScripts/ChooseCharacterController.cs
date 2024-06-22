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


    private PlayerController _playerController;

    public GameObject[] characterPriceErrorTextObjects;
    private TextMeshProUGUI[] characterPriceErrorTextObjectChilds;

    public GameObject[] characterStaffs;

    [SerializeField] float menuSlideSpeed;


    private void Start()
    {

        if (playerCoinData.avaliableCoin < 0)
        {
            playerCoinData.avaliableCoin = 0;
        }
        //ResetTheCharacters();
        playerData.avaliableCharacters[0] = "Dobby";
        _playerController = FindObjectOfType<PlayerController>();


        CharacterPriceError();
        


        //infoPanel = new GameObject[gameObject.transform.GetChild(1).GetChild(0).childCount];

        SetCharacterInfos();
        

        //ResetTheCharacters();

        //characterLockStatesTextsObject = GameObject.Find("CharacterLockStatesTexts");
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
    public void ResetTheCharacters()
    {
        for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
        {
            playerData.avaliableCharacters[i] = playerData.unLocked;
        }
    }
    public void PickJoleen(int avaliableCoinAmount)
    {
        if (_playerController.Joleen && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Joleen)
        {
            
            playerData.currentCharacterName = PlayerData.CharacterNames.Joleen;

            playerCoinData.avaliableCoin -= 0;

            characterPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

            playerData.joleenLock = playerData.unLocked;

        }
        else if (_playerController.Joleen && playerData.joleenLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Joleen;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.joleenLock == playerData.locked)
        {
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
        if (_playerController.Dobby && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Dobby)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.dobbyLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Dobby";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.dobbyLock = playerData.unLocked;
                    break;
                }
            }

            characterPriceErrorTextObjectChilds[1].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Dobby && playerData.dobbyLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.dobbyLock == playerData.locked)
        {
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
        if (_playerController.Glassy && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Glassy)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.glassyLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Glassy";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.glassyLock = playerData.unLocked;

                    break;
                }
            }

            characterPriceErrorTextObjectChilds[2].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Glassy;


            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Glassy && playerData.glassyLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Glassy;


            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.glassyLock == playerData.locked)
        {
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
        if ((_playerController.Lusth) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Lusth )
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.lusthLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Lusth";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.lusthLock = playerData.unLocked;

                    break;
                }
            }

            characterPriceErrorTextObjectChilds[3].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Lusth;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Lusth && playerData.lusthLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Lusth;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.lusthLock == playerData.locked)
        {
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
        if ((_playerController.Guard) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Guard)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.guardLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Guard";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.guardLock = playerData.unLocked;

                    break;
                }
            }

            characterPriceErrorTextObjectChilds[4].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Guard;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Guard && playerData.guardLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Guard;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.guardLock == playerData.locked)
        {
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
        if ((_playerController.Eve) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Eve)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.eveLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Eve";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.eveLock = playerData.unLocked;

                    break;
                }
            }

            characterPriceErrorTextObjectChilds[5].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Eve;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Eve && playerData.eveLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Eve;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.eveLock == playerData.locked)
        {
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
        if ((_playerController.Michelle) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Michelle)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.michelleLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Michelle";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.michelleLock = playerData.unLocked;

                    break;
                }
            }

            characterPriceErrorTextObjectChilds[6].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Michelle;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Michelle && playerData.michelleLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Michelle;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.michelleLock == playerData.locked)
        {
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
        if ((_playerController.Boss) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Boss)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.bossLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Boss";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.bossLock = playerData.unLocked;

                    break;
                }
            }

            characterPriceErrorTextObjectChilds[7].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Boss;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Boss && playerData.bossLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Boss;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.bossLock == playerData.locked)
        {
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
        if ((_playerController.Aj) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Aj)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.ajLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Aj";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.ajLock = playerData.unLocked;

                    break;
                }
            }
            characterPriceErrorTextObjectChilds[8].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Aj;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Aj && playerData.ajLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Aj;

            SceneController.GetInstance.LoadMenuScene();
        }       
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.ajLock == playerData.locked)
        {
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
        if ((_playerController.Mremireh) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Mremireh)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.mremirehLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Mremireh";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.mremirehLock = playerData.unLocked;

                    break;
                }
            }

            characterPriceErrorTextObjectChilds[9].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Mremireh;

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Mremireh && playerData.mremirehLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Mremireh;

            SceneController.GetInstance.LoadMenuScene();
        }
       
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.mremirehLock == playerData.locked)
        {
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
        if ((_playerController.Ty) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Ty)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.tyLock == playerData.locked)
                {
                    playerData.avaliableCharacters[i] = "Ty";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.tyLock = playerData.unLocked;

                    break;
                }
            }

            characterPriceErrorTextObjectChilds[10].text = "";

            playerData.currentCharacterName = PlayerData.CharacterNames.Ty;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Ty && playerData.tyLock == playerData.unLocked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Ty;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && playerData.tyLock == playerData.locked)
        {
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
