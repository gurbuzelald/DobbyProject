using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractPlayerSFX<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }
            return _instance;
        }

    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;

            DontDestroyOnLoad(gameObject);
        }
    }
    public virtual void SFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, PlayerData playerData)
    {
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.shootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.nonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Sword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.swordClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.getHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.jumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.dyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.getHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.pickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Trap)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.trapClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.levelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.jumpingSeaClip);
        }
    }
}
