using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : AbstractSingleton<PlayerSoundEffect>
{
    public PlayerData playerData;
    public void SoundEffectStatement(SoundEffectTypes soundEffect)
    {
        if (soundEffect == SoundEffectTypes.Shoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.shootClip);
        }
        else if (soundEffect == SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.getHitClip);
        }
        else if (soundEffect == SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.jumpingClip);
        }
        else if (soundEffect == SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.dyingClip);
        }
        else if (soundEffect == SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.getHitClip);
        }
        else if (soundEffect == SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.pickupCoinClip);
        }
        else if (soundEffect == SoundEffectTypes.Trap)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.trapClip);
        }
        else if (soundEffect == SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.levelUpClip);
        }
        else if (soundEffect == SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(playerData.jumpingSeaClip);
        }
    }
    public enum SoundEffectTypes
    {
        Shoot,
        GetHit,
        Jump,
        JumpToSea,
        Death,
        PickUpCoin,
        Trap,
        LevelUp, 
        ShootOf
    }
}
