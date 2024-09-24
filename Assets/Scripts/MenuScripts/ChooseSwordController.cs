using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseSwordController : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] GameObject _panelObject;
    [SerializeField] BulletData bulletData;
    [SerializeField] TextMeshProUGUI havingSwordText;

    void FixedUpdate()
    {
        RotateSword(50f);
    }
    void RotateSword(float rotateSpeed)
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            if (i == 2)
            {
                _objects[i].transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * rotateSpeed));
            }
            else if (i == 10)
            {
                _objects[i].transform.Rotate(new Vector3(Time.deltaTime * rotateSpeed, 0f, 0f));
            }
            else
            {
                _objects[i].transform.Rotate(new Vector3(0f, Time.deltaTime * rotateSpeed, 0f));
            }
        }
    }
    public void PickSword(string swordName)
    {
        if (bulletData.currentSwordName == swordName)
        {
            havingSwordText.text = "You already have this!!!";
        }
        else
        {
            havingSwordText.text = "";

            bulletData.currentSwordName = swordName;
            SceneController.LoadCharacterChoosingScene();
        }
    }



    public void GoLeft(int value)
    {
        havingSwordText.text = "";

        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.position = new Vector3(_objects[i].transform.position.x - value,
                                                         _objects[i].transform.position.y,
                                                         _objects[i].transform.position.z);
        }
    }
    public void GoRight(int value)
    {
        havingSwordText.text = "";

        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.position = new Vector3(_objects[i].transform.position.x + value,
                                                         _objects[i].transform.position.y,
                                                         _objects[i].transform.position.z);
        }
    }
}
