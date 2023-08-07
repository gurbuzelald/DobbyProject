using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacterController : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;

    [SerializeField] GameObject _panelObject;
    [SerializeField] PlayerData playerData;
    [SerializeField] PlayerCoinData playerCoinData;


    private PlayerController _playerController;
    

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        RotateCharacters();
        SlideMenu();
        CharacterChooseStates();
    }
    void CharacterChooseStates()
    {        
        ChoosedSpartacus(playerData.glassyPrice);
        ChoosedGlassy(playerData.glassyPrice);
        ChoosedDobby(playerData.glassyPrice);
        ChoosedLusth(playerData.glassyPrice);
        ChoosedGuard(playerData.glassyPrice);
        ChoosedEve(playerData.glassyPrice);
        ChoosedMichelle(playerData.glassyPrice);
        ChoosedBoss(playerData.glassyPrice);
        ChoosedAj(playerData.glassyPrice);
        ChoosedMremireh(playerData.glassyPrice);
        ChoosedTy(playerData.glassyPrice);
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
        if (_playerController.Spartacus && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Spartacus;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }
    }
    public void ChoosedDobby(int avaliableCoinAmount)
    {
        if (_playerController.Dobby && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }
    }
    public void ChoosedGlassy(int avaliableCoinAmount)
    {
        if (_playerController.Glassy && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Glassy;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedLusth(int avaliableCoinAmount)
    {
        if ((_playerController.Lusth) && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Lusth;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedGuard(int avaliableCoinAmount)
    {
        if ((_playerController.Guard) && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Guard;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }            
    }
    public void ChoosedEve(int avaliableCoinAmount)
    {
        if ((_playerController.Eve) && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Eve;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedMichelle(int avaliableCoinAmount)
    {
        if ((_playerController.Michelle) && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Michelle;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedBoss(int avaliableCoinAmount)
    {
        if ((_playerController.Boss) && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Boss;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedAj(int avaliableCoinAmount)
    {
        if ((_playerController.Aj) && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Aj;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }

    public void ChoosedMremireh(int avaliableCoinAmount)
    {
        if ((_playerController.Mremireh) && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Mremireh;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }        
    }

    public void ChoosedTy(int avaliableCoinAmount)
    {
        if ((_playerController.Ty) && playerCoinData.avaliableCoin >= avaliableCoinAmount)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Ty;

            playerCoinData.avaliableCoin -= avaliableCoinAmount;

            SceneController.GetInstance.LoadMenuScene();
        }
    }



    
}
