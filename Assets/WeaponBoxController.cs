using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxController : MonoBehaviour
{

    private int damageToWeaponBox;

    private void Start()
    {
        damageToWeaponBox = 0;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(SceneController.Tags.Bullet.ToString()) || other.CompareTag(SceneController.Tags.Sword.ToString()))
        {
            if (damageToWeaponBox > 1)
            {
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
            damageToWeaponBox++;
        }
    }
}
