using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterController : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] GameObject _panelObject;
    [SerializeField] PlayerData playerData;
    void FixedUpdate()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));
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
    public void GoLeft(int value)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.position = new Vector3(_objects[i].transform.position.x - value, 
                                                         _objects[i].transform.position.y, 
                                                         _objects[i].transform.position.z);
        }
    }
    public void GoRight(int value)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.position = new Vector3(_objects[i].transform.position.x + value,
                                                         _objects[i].transform.position.y,
                                                         _objects[i].transform.position.z);
        }
    }
}
