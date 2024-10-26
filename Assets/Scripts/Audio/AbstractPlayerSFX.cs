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
#pragma warning disable CS0618 // Type or member is obsolete
                _instance = FindObjectOfType<T>();
#pragma warning restore CS0618 // Type or member is obsolete
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

            //DontDestroyOnLoad(gameObject);
        }
    }
    public void SFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffectName, AudioData audioData)
    {
        // Create a dictionary to map sound effect types to corresponding audio clips
        var soundEffectMap = new Dictionary<PlayerSoundEffect.SoundEffectTypes, AudioClip>
    {
        { PlayerSoundEffect.SoundEffectTypes.NonShoot, audioData.nonShoot },
        { PlayerSoundEffect.SoundEffectTypes.Poison, audioData.playerClip[PlayerData.currentCharacterID].poison },
        { PlayerSoundEffect.SoundEffectTypes.GetEnemyHit, audioData.playerClip[PlayerData.currentCharacterID].getEnemyHit },
        { PlayerSoundEffect.SoundEffectTypes.Jump, audioData.playerClip[PlayerData.currentCharacterID].jumping },
        { PlayerSoundEffect.SoundEffectTypes.Death, audioData.playerClip[PlayerData.currentCharacterID].dying },
        { PlayerSoundEffect.SoundEffectTypes.PickUpCoin, audioData.pickUpCoin },
        { PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin, audioData.pickUpBulletCoin },
        { PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin, audioData.errorPickUpBulletCoin },
        { PlayerSoundEffect.SoundEffectTypes.DestroyGiftBox, audioData.destroyGiftBox },
        { PlayerSoundEffect.SoundEffectTypes.TouchGiftBox, audioData.touchGiftBox },
        { PlayerSoundEffect.SoundEffectTypes.LevelUp, audioData.levelUp },
        { PlayerSoundEffect.SoundEffectTypes.Teleport, audioData.teleport },
        { PlayerSoundEffect.SoundEffectTypes.IncreasingHealth, audioData.health }
    };

        // Play the corresponding sound effect if it exists in the map
        if (soundEffectMap.TryGetValue(soundEffectName, out AudioClip clip))
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(clip);
        }
    }


    public void WeaponSFX(string shootSoundEffectName, AudioData audioData)
    {
        // Loop through the weapon clips to find the correct one
        for (int i = 0; i < audioData.weaponClip.Length; i++)
        {
            if (shootSoundEffectName == audioData.weaponClip[i].name)
            {
                audioData.currentBulletHitClip = audioData.weaponClip[i].weaponHitClip;

                PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.weaponClip[i].weaponClip);
                return; // Exit the function once the correct clip is found
            }
        }
    }


    public void SwordSFX(PlayerSoundEffect.SwordSoundEffectTypes swordSoundEffectType, AudioData audioData)
    {
        if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.LowSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.LowSwordClip);
        }
    }

    public void MenuSFX(MenuSoundEffect.MenuSoundEffectTypes soundEffect, AudioData audioData)
    {
        if (soundEffect == MenuSoundEffect.MenuSoundEffectTypes.MenuClick &&
            MenuSoundEffect.GetInstance.audioSource && audioData)
        {
            MenuSoundEffect.GetInstance.audioSource.PlayOneShot(audioData.menuClickClip);
        }
        else if (soundEffect == MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick &&
            MenuSoundEffect.GetInstance.audioSource && audioData)
        {
            MenuSoundEffect.GetInstance.audioSource.PlayOneShot(audioData.menuNotClickClip);
        }
    }
}
