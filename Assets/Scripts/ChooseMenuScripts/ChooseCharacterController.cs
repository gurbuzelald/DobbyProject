using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class ChooseCharacterController : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;

    [SerializeField] GameObject _panelObject;
    [SerializeField] PlayerData playerData;
    [SerializeField] PlayerCoinData playerCoinData;


    private PlayerController _playerController;
    private void Start()
    {
        //ResetTheCharacters();
        playerData.avaliableCharacters[0] = "Spartacus";
        _playerController = FindObjectOfType<PlayerController>();

        //infoPanel = new GameObject[gameObject.transform.GetChild(1).GetChild(0).childCount];

        SetCharacterInfos();
        for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
        {
            Debug.Log(playerData.avaliableCharacters[i]);
        }

        //characterLockStatesTextsObject = GameObject.Find("CharacterLockStatesTexts");
    }
    void SetCharacterInfos()
    {
        if (gameObject.transform.GetChild(1).gameObject.name == "Panel")
        {
            playerData.characterStaffs = new Dictionary<int, GameObject>();

            for (int i = 0; i < gameObject.transform.GetChild(1).GetChild(0).childCount; i++)
            {
                playerData.characterStaffs[i] = gameObject.transform.GetChild(1).GetChild(0).GetChild(i).gameObject;
            }

            for (int i = 0; i < playerData.characterStaffs.Count; i++)
            {
                if (playerData.characterStaffs[i].name == "SpartacusStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.spartacusSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.spartacusJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "DobbyStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.dobbySpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.dobbyJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "GlassyStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.glassySpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.glassyJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "LusthStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.lusthSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.lusthJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "GuardStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.guardSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.guardJumpForce.ToString();

                }
                else if (playerData.characterStaffs[i].name == "MichelleStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.michelleSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.michelleJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "EveStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.eveSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.eveJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "AjStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.ajSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.ajJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "BossStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.bossSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.bossJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "TyStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.tySpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.tyJumpForce.ToString();
                }
                else if (playerData.characterStaffs[i].name == "MremirehStaff")
                {
                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = playerData.guardSpeed.ToString();

                    playerData.characterStaffs[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = playerData.guardJumpForce.ToString();
                }
            }
        }
        

    }
    
    void Update()
    {
        RotateCharacters();
        SlideMenu();
        CharacterChooseStates();
    }
    void CharacterChooseStates()
    {        
        ChoosedSpartacus(playerData.spartacusPrice);
        ChoosedGlassy(playerData.glassyPrice);
        ChoosedDobby(playerData.dobbyPrice);
        ChoosedLusth(playerData.lusthPrice);
        ChoosedGuard(playerData.guardPrice);
        ChoosedEve(playerData.evePrice);
        ChoosedMichelle(playerData.michellePrice);
        ChoosedBoss(playerData.bossPrice);
        ChoosedAj(playerData.ajPrice);
        ChoosedMremireh(playerData.mremirehPrice);
        ChoosedTy(playerData.tyPrice);
    }

    void RotateCharacters()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));
        }
    }
    void SlideMenu()
    {
        if (_playerController.stick.x < 0f)
        {
            for (int i = 0; i < _objects.Length; i++)
            {
                _panelObject.transform.position = new Vector3(_panelObject.transform.position.x - 1.5f * Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
            }
        }
        if (_playerController.stick.x > 0f)
        {
            for (int i = 0; i < _objects.Length; i++)
            {
                _panelObject.transform.position = new Vector3(_panelObject.transform.position.x + 1.5f * Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
            }
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
    public void ChoosedSpartacus(int avaliableCoinAmount)
    {
        if (_playerController.Spartacus && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Spartacus)
        {
            
            playerData.currentCharacterName = PlayerData.CharacterNames.Spartacus;

            playerCoinData.avaliableCoin -= 0;

            SceneController.GetInstance.LoadMenuScene();

            playerData.spartacusLock = PlayerData.CharacterLocking.Unlocked;

        }
    }
    void ResetTheCharacters()
    {
        for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
        {
            playerData.avaliableCharacters[i] = "";
        }
    }
    public void ChoosedDobby(int avaliableCoinAmount)
    {
        if (_playerController.Dobby && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Dobby)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.dobbyLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Dobby";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.dobbyLock = PlayerData.CharacterLocking.Unlocked;
                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;

            

            SceneController.GetInstance.LoadMenuScene();
        }
        
    }
    public void ChoosedGlassy(int avaliableCoinAmount)
    {
        if (_playerController.Glassy && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Glassy)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.glassyLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Glassy";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.glassyLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Glassy;


            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedLusth(int avaliableCoinAmount)
    {
        if ((_playerController.Lusth) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Lusth)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.lusthLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Lusth";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.lusthLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Lusth;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedGuard(int avaliableCoinAmount)
    {
        if ((_playerController.Guard) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Guard)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.guardLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Guard";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.guardLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Guard;

            SceneController.GetInstance.LoadMenuScene();
        }            
    }
    public void ChoosedEve(int avaliableCoinAmount)
    {
        if ((_playerController.Eve) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Eve)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.eveLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Eve";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.eveLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Eve;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedMichelle(int avaliableCoinAmount)
    {
        if ((_playerController.Michelle) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Michelle)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.michelleLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Michelle";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.michelleLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Michelle;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedBoss(int avaliableCoinAmount)
    {
        if ((_playerController.Boss) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Boss)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.bossLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Boss";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.bossLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Boss;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedAj(int avaliableCoinAmount)
    {
        if ((_playerController.Aj) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Aj)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.ajLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Aj";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.ajLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Aj;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }

    public void ChoosedMremireh(int avaliableCoinAmount)
    {
        if ((_playerController.Mremireh) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Mremireh)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.mremirehLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Mremireh";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.mremirehLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Mremireh;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }

    public void ChoosedTy(int avaliableCoinAmount)
    {
        if ((_playerController.Ty) && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            playerData.currentCharacterName != PlayerData.CharacterNames.Ty)
        {
            for (int i = 0; i < playerData.avaliableCharacters.Length; i++)
            {
                if (playerData.avaliableCharacters[i] == "" && playerData.tyLock == PlayerData.CharacterLocking.Locked)
                {
                    playerData.avaliableCharacters[i] = "Ty";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    playerData.tyLock = PlayerData.CharacterLocking.Unlocked;

                    break;
                }
            }
            playerData.currentCharacterName = PlayerData.CharacterNames.Ty;

            SceneController.GetInstance.LoadMenuScene();
        }
    }



    
}
