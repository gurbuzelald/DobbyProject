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
            PickJoleen();
            PickGlassy();
            PickDobby();
            PickLusth();
            PickGuard();
            PickEve();
            PickMichelle();
            PickBoss();
            PickAj();
            PickMremireh();
            PickTy();
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
    
    public void PickJoleen()
    {
        if (ButtonController.Joleen && playerCoinData.avaliableCoin >= playerData.joleenPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Joleen)
        {
            if (playerData.joleenLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.joleenPrice;
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
        else if((playerData.joleenPrice - playerCoinData.avaliableCoin) > 0 && playerData.joleenLock == playerData.locked)
        {
            if (ButtonController.Joleen)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[0].text = "Satin Almak İçİn " + (playerData.joleenPrice - playerCoinData.avaliableCoin).ToString() + " Coİn' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[0].text = "You need " + (playerData.joleenPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }    
    public void PickDobby()
    {
        if (ButtonController.Dobby && playerCoinData.avaliableCoin >= playerData.dobbyPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Dobby)
        {
            if (playerData.dobbyLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.dobbyPrice;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);                

                playerData.dobbyLock = playerData.unLocked;                
            }
            characterPriceErrorTextObjectChilds[1].text = "";

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
        else if ((playerData.dobbyPrice - playerCoinData.avaliableCoin) > 0 && playerData.dobbyLock == playerData.locked)
        {
            if (ButtonController.Dobby)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[1].text = "Satin Almak İçİn " + (playerData.dobbyPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[1].text = "You need " + (playerData.dobbyPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickGlassy()
    {
        if (ButtonController.Glassy && playerCoinData.avaliableCoin >= playerData.glassyPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Glassy)
        {
            if (playerData.glassyLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.glassyPrice;
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
        else if ((playerData.glassyPrice - playerCoinData.avaliableCoin) > 0 && playerData.glassyLock == playerData.locked)
        {
            if (ButtonController.Glassy)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[2].text = "Satin Almak İçİn " + (playerData.glassyPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[2].text = "You need " + (playerData.glassyPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickLusth()
    {
        if ((ButtonController.Lusth) && playerCoinData.avaliableCoin >= playerData.lusthPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Lusth )
        {
            if (playerData.lusthLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.lusthPrice;
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
        else if ((playerData.lusthPrice - playerCoinData.avaliableCoin) > 0 && playerData.lusthLock == playerData.locked)
        {
            if (ButtonController.Lusth)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[3].text = "Satin Almak İçİn " + (playerData.lusthPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[3].text = "You need " + (playerData.lusthPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickGuard()
    {
        if ((ButtonController.Guard) && playerCoinData.avaliableCoin >= playerData.guardPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Guard)
        {
            if (playerData.guardLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.guardPrice;
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
        else if ((playerData.guardPrice - playerCoinData.avaliableCoin) > 0 && playerData.guardLock == playerData.locked)
        {
            if (ButtonController.Guard)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[4].text = "Satin Almak İçİn " + (playerData.guardPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[4].text = "You need " + (playerData.guardPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickEve()
    {
        if ((ButtonController.Eve) && playerCoinData.avaliableCoin >= playerData.evePrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Eve)
        {
            if (playerData.eveLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.evePrice;
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
        else if ((playerData.evePrice - playerCoinData.avaliableCoin) > 0 && playerData.eveLock == playerData.locked)
        {
            if (ButtonController.Eve)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[5].text = "Satin Almak İçİn " + (playerData.evePrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[5].text = "You need " + (playerData.evePrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickMichelle()
    {
        if ((ButtonController.Michelle) && playerCoinData.avaliableCoin >= playerData.michellePrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Michelle)
        {
            if (playerData.michelleLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.michellePrice;
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
        else if ((playerData.michellePrice - playerCoinData.avaliableCoin) > 0 && playerData.michelleLock == playerData.locked)
        {
            if (ButtonController.Michelle)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }

            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[6].text = "Satin Almak İçİn " + (playerData.michellePrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[6].text = "You need " + (playerData.michellePrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickBoss()
    {
        if ((ButtonController.Boss) && playerCoinData.avaliableCoin >= playerData.bossPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Boss)
        {
            if (playerData.bossLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.bossPrice;
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
        else if ((playerData.bossPrice - playerCoinData.avaliableCoin) > 0 && playerData.bossLock == playerData.locked)
        {
            if (ButtonController.Boss)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[7].text = "Satin Almak İçİn " + (playerData.bossPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[7].text = "You need " + (playerData.bossPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickAj()
    {
        if ((ButtonController.Aj) && playerCoinData.avaliableCoin >= playerData.ajPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Aj)
        {
            if (playerData.ajLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.ajPrice;
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
        else if ((playerData.ajPrice - playerCoinData.avaliableCoin) > 0 && playerData.ajLock == playerData.locked)
        {
            if (ButtonController.Aj)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[8].text = "Satin Almak İçİn " + (playerData.ajPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[8].text = "You need " + (playerData.ajPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickMremireh()
    {
        if ((ButtonController.Mremireh) && playerCoinData.avaliableCoin >= playerData.mremirehPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Mremireh)
        {
            if (playerData.mremirehLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.mremirehPrice;
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
       
        else if ((playerData.mremirehPrice - playerCoinData.avaliableCoin) > 0 && playerData.mremirehLock == playerData.locked)
        {
            if (ButtonController.Mremireh)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[9].text = "Satin Almak İçİn " + (playerData.mremirehPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[9].text = "You need " + (playerData.mremirehPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
    public void PickTy()
    {
        if ((ButtonController.Ty) && playerCoinData.avaliableCoin >= playerData.tyPrice &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Ty)
        {
            if (playerData.tyLock == playerData.locked)
            {
                playerCoinData.avaliableCoin -= playerData.tyPrice;
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
        else if ((playerData.tyPrice - playerCoinData.avaliableCoin) > 0 && playerData.tyLock == playerData.locked)
        {
            if (ButtonController.Ty)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                characterPriceErrorTextObjectChilds[10].text = "Satin Almak İçİn " + (playerData.tyPrice - playerCoinData.avaliableCoin).ToString() + " Coin' e Daha İhtİyacin Var!";
            }
            else
            {
                characterPriceErrorTextObjectChilds[10].text = "You need " + (playerData.tyPrice - playerCoinData.avaliableCoin).ToString() + " More Coin!";
            }
        }
    }
}
