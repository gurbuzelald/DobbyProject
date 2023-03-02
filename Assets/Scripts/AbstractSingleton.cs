using UnityEngine;
using Cinemachine;


public abstract class AbstractSingleton<T> : MonoBehaviour where T : MonoBehaviour
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
    //public virtual void ShootSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
    //    }
    //}
    //public virtual void NonShootSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
    //    }
    //}

    //public virtual void SwordSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Sword);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Sword);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Sword);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Sword);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Sword);
    //    }
    //}


    //public virtual void GetHitSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);
    //    }
    //}

    //public virtual void JumpSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);
    //    }
    //}


    //public virtual void JumpToSeaSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.JumpToSea);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.JumpToSea);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.JumpToSea);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.JumpToSea);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.JumpToSea);
    //    }
    //}

    //public virtual void DeathSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
    //    }
    //}

    //public virtual void PickUpCoinSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
    //    }
    //}



    //public virtual void PickUpBulletCoinSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
    //    }
    //}

    //public virtual void TrapSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Trap);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Trap);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Trap);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Trap);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Trap);
    //    }
    //}


    //public virtual void LevelUpSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
    //    }
    //}
    //public virtual void ShootOffSFX(PlayerData _playerData)
    //{
    //    if (PlayerData.CharacterNames.Dobby == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ShootOff);
    //    }
    //    else if (PlayerData.CharacterNames.Glassy == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ShootOff);
    //    }
    //    else if (PlayerData.CharacterNames.Spartacus == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ShootOff);
    //    }
    //    else if (PlayerData.CharacterNames.Guard == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ShootOff);
    //    }
    //    else if (PlayerData.CharacterNames.Lusth == _playerData.currentCharacterName)
    //    {
    //        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ShootOff);
    //    }
    //}

}