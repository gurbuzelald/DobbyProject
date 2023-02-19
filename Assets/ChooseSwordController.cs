using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSwordController : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] GameObject _panelObject;
    [SerializeField] BulletData bulletData;
    void FixedUpdate()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            if (i == 2)
            {
                _objects[i].transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * 50f));
            }
            else
            {
                _objects[i].transform.Rotate(new Vector3(0f, Time.deltaTime * 50f, 0f));
            }
        }
    }
    public void ChoosedHummer()
    {
        bulletData.currentSwordName = BulletData.SwordNames.hummer;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedWarriorSword()
    {
        bulletData.currentSwordName = BulletData.SwordNames.warriorSword;
        SceneController.GetInstance.LoadMenuScene();
    }
    public void ChoosedLowSword()
    {
        bulletData.currentSwordName = BulletData.SwordNames.lowSword;
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
