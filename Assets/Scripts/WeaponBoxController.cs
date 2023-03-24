using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxController : MonoBehaviour
{

    private int damageToWeaponBox;
    [SerializeField] GameObject damageGiftBoxParticle;
    private GameObject _damageGiftBoxParticle;

    private void Start()
    {
        damageToWeaponBox = 0;
    }
    private void Update()
    {
        if (_damageGiftBoxParticle != null)
        {
            StartCoroutine(DelayDestroyParticle());
        }
    }
    IEnumerator DelayDestroyParticle()
    {
        yield return new WaitForSeconds(2);
        Destroy(_damageGiftBoxParticle);
        yield return new WaitForSeconds(0f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(SceneController.Tags.Bullet.ToString()) || other.CompareTag(SceneController.Tags.Sword.ToString()))
        {
            if (damageToWeaponBox > 1)
            {
                _damageGiftBoxParticle = Instantiate(damageGiftBoxParticle,gameObject.transform.position, Quaternion.identity, gameObject.transform);
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.DamageGiftBox);

                other.gameObject.SetActive(false);
            }
            damageToWeaponBox++;
        }
    }
}
