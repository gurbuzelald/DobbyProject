using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterController : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;

    [SerializeField] GameObject _panelObject;
    [SerializeField] PlayerData playerData;


    private PlayerController _playerController;

    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    void FixedUpdate()
    {
        RotateCharacters();
        SlideMenu();
        CharacterChooseStates();
    }
    void CharacterChooseStates()
    {        
        ChoosedSpartacus();
        ChoosedGlassy();
        ChoosedDobby();
        ChoosedLusth();
        ChoosedGuard();
        ChoosedEve();
        ChoosedMichelle();
        ChoosedBoss();
        ChoosedAj();
        ChoosedMremireh();
        ChoosedTy();
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
    }
    public void ChoosedSpartacus()
    {
        if (_playerController.Spartacus)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Spartacus;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedDobby()
    {
        if (_playerController.Dobby)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedGlassy()
    {
        if (_playerController.Glassy)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Glassy;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedLusth()
    {
        if ((_playerController.Lusth))
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Lusth;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedGuard()
    {
        if ((_playerController.Guard))
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Guard;
            SceneController.GetInstance.LoadMenuScene();
        }            
    }
    public void ChoosedEve()
    {
        if ((_playerController.Eve))
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Eve;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedMichelle()
    {
        if ((_playerController.Michelle))
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Michelle;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedBoss()
    {
        if ((_playerController.Boss))
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Boss;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }
    public void ChoosedAj()
    {
        if ((_playerController.Aj))
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Aj;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }

    public void ChoosedMremireh()
    {
        if ((_playerController.Mremireh))
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Mremireh;
            SceneController.GetInstance.LoadMenuScene();
        }        
    }

    public void ChoosedTy()
    {
        if ((_playerController.Ty))
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Ty;
            SceneController.GetInstance.LoadMenuScene();
        }
    }
}
