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
    public void SFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.nonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.poisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.getEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.getBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.jumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.pickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.pickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.errorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DestroyGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.destroyGiftBoxClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.TouchGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.touchGiftBoxClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.levelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.jumpingSeaClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Teleport)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.teleportClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.IncreasingHealth)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.healthClip);
        }
    }

    public void WeaponSFX(PlayerSoundEffect.ShootSoundEffectTypes shootSoundEffectType, AudioData audioData)
    {
        if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Ak47)
        {
            audioData.currentBulletHitClip = audioData.ak47HitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.Ak47Clip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.M4a4)
        {
            audioData.currentBulletHitClip = audioData.m4a4HitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.M4a4Clip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Bulldog)
        {
            audioData.currentBulletHitClip = audioData.bulldogHitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.BulldogClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Cow)
        {
            audioData.currentBulletHitClip = audioData.cowHitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.CowClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Crystal)
        {
            audioData.currentBulletHitClip = audioData.crystalHitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.CrystalClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Demon)
        {
            audioData.currentBulletHitClip = audioData.demonHitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.DemonClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Ice)
        {
            audioData.currentBulletHitClip = audioData.iceHitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.IceClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Negev)
        {
            audioData.currentBulletHitClip = audioData.negevHitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.NegevClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Axe)
        {
            audioData.currentBulletHitClip = audioData.axeHitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.AxeClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Pistol)
        {
            audioData.currentBulletHitClip = audioData.pistolHitClip;

            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.PistolClip);
        }
    }

    public void SwordSFX(PlayerSoundEffect.SwordSoundEffectTypes swordSoundEffectType, AudioData audioData)
    {
        if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.LowSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.LowSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.WarriorSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.WarriorSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.Hummer)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.HummerClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.OrcSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.OrcSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.AxeSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.AxeSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.AxeKnight)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.AxeKnightClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.BarbarianSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.BarbarianSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.DemonSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.DemonSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.MagicSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.MagicSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.LongHummer)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.LongHummerClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.Club)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ClubClip);
        }
    }

    public void MenuSFX(MenuSoundEffect.MenuSoundEffectTypes soundEffect, AudioData audioData)
    {
        if (soundEffect == MenuSoundEffect.MenuSoundEffectTypes.MenuClick &&
            MenuSoundEffect.GetInstance.audioSource && audioData)
        {
            MenuSoundEffect.GetInstance.audioSource.PlayOneShot(audioData.menuClickClip);
        }
    }
}
