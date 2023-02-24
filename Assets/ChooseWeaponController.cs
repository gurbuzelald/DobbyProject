using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseWeaponController : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] GameObject _panelObject;
    [SerializeField] BulletData bulletData;
    [SerializeField] TextMeshProUGUI havingWeaponText;
    void FixedUpdate()
    {
        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.Rotate(new Vector3(0f, Time.deltaTime * 50f, 0f));
        }
    }
    public void ChoosedWeapon(string weaponName)
    {
        if (bulletData.currentWeaponName == weaponName)
        {
            havingWeaponText.text = "You already have this!!!";
        }
        else
        {
            havingWeaponText.text = "";

            bulletData.currentWeaponName = weaponName;
            SceneController.GetInstance.LoadCharacterChoosingScene();
        }
    }
    public void GoLeft(int value)
    {
        havingWeaponText.text = "";

        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.position = new Vector3(_objects[i].transform.position.x - value,
                                                         _objects[i].transform.position.y,
                                                         _objects[i].transform.position.z);
        }
    }
    public void GoRight(int value)
    {
        havingWeaponText.text = "";

        for (int i = 0; i < _objects.Length; i++)
        {
            _objects[i].transform.position = new Vector3(_objects[i].transform.position.x + value,
                                                         _objects[i].transform.position.y,
                                                         _objects[i].transform.position.z);
        }
    }
}
