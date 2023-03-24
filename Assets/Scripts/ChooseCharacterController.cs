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
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));
        }
        if (_playerController.stick.x < 0f)
        {
            for (int i = 0; i < _objects.Length; i++)
            {
                _panelObject.transform.position = new Vector3(_panelObject.transform.position.x - 1.5f*Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
            }
        }
        if (_playerController.stick.x > 0f)
        {
            for (int i = 0; i < _objects.Length; i++)
            {
                _panelObject.transform.position = new Vector3(_panelObject.transform.position.x + 1.5f*Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
            }
        }
    }
    public void ChoosedSpartacus()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Spartacus;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedDobby()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedGlassy()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Glassy;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedLusth()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Lusth;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedGuard()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Guard;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedEve()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Eve;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedMichelle()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Michelle;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedBoss()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Boss;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedAj()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Aj;
        SceneController.GetInstance.LoadMenuScene();
    }

    public void ChoosedMremireh()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Mremireh;
        SceneController.GetInstance.LoadMenuScene();
    }

    public void ChoosedTy()
    {
        playerData.currentCharacterName = PlayerData.CharacterNames.Ty;
        SceneController.GetInstance.LoadMenuScene();
    }
}
