using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : AbstractPlayerSFX<PlayerSoundEffect>
{
    public PlayerData playerData;
    public void SoundEffectStatement(SoundEffectTypes soudEffectType)
    {
        SFXStatement(soudEffectType, playerData);
    }
    public enum SoundEffectTypes
    {
        Shoot,
        NonShoot,
        Sword,
        GetHit,
        Jump,
        JumpToSea,
        Death,
        PickUpCoin,
        PickUpBulletCoin,
        Trap,
        LevelUp, 
        ShootOf
    }
}
