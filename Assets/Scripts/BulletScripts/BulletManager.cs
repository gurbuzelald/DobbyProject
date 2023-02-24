using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletManager : AbstractBullet<BulletManager>
{
    [Header("Bullet Transform")]
    [SerializeField] Transform _bulletSpawnTransform;

    [Header("Data")]
    public BulletData bulletData;
    public PlayerData _playerData;

    [Header("Initial Transform of This")]
    private Transform _initTransform;

    public GameObject _currentWeaponObject;
    public GameObject _currentSwordObject;
    public GameObject pinky;

    void Awake()
    {
        CreateWeaponObject();

        CreateSwordObject();

        bulletData.bulletDelayCounter = 0;
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    public void CreateSwordObject()
    {
        if (BulletData.lowSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.lowSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.warriorSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.warriorSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.hummer == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.hummerObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.orcSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.orcSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.axeSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.axeObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.axeKnight == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.axeKnightObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.barbarianSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.barbarianSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.demonSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.demonSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);

        }
        else if (BulletData.magicSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.magicWeaponObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.longHummer == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.longHummerObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        else if (BulletData.club == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.clubObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);
        }
        _currentSwordObject.SetActive(false);

        _currentSwordObject.transform.position = PlayerManager.GetInstance._swordTransform.position;

        _currentSwordObject.transform.rotation = PlayerManager.GetInstance._swordTransform.rotation;
    }
    public void CreateWeaponObject()
    {
        if (bulletData.currentWeaponName == BulletData.ak47)
        {
            _currentWeaponObject = Instantiate(bulletData.ak47Object,
                                               _bulletSpawnTransform.position,
                                               Quaternion.identity,
                                               PlayerManager.GetInstance._gunTransform);
        }
        else if (bulletData.currentWeaponName == BulletData.rifle)
        {
            _currentWeaponObject = Instantiate(bulletData.rifleObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);
        }
        else if (bulletData.currentWeaponName == BulletData.bulldog)
        {
            _currentWeaponObject = Instantiate(bulletData.bullDogObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);
        }
        else if (bulletData.currentWeaponName == BulletData.cowgun)
        {
            _currentWeaponObject = Instantiate(bulletData.cowgunObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);
        }
        else if (bulletData.currentWeaponName == BulletData.crystalgun)
        {
            _currentWeaponObject = Instantiate(bulletData.crsytalgunObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);
        }
        else if (bulletData.currentWeaponName == BulletData.demongun)
        {
            _currentWeaponObject = Instantiate(bulletData.demongunObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);
        }
        else if (bulletData.currentWeaponName == BulletData.icegun)
        {
            _currentWeaponObject = Instantiate(bulletData.icegunObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);
        }
        else if (bulletData.currentWeaponName == BulletData.negev)
        {
            _currentWeaponObject = Instantiate(bulletData.negevObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);
        }
        else if (bulletData.currentWeaponName == BulletData.axegun)
        {
            _currentWeaponObject = Instantiate(bulletData.axegunObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);
        }
        _currentWeaponObject.SetActive(false);

        _currentWeaponObject.transform.position = PlayerManager.GetInstance._gunTransform.position;
        _currentWeaponObject.transform.rotation = bulletData.rifleObject.transform.rotation;
    }

    public GameObject GetPinky()
    {
        if (_playerData.currentCharacterName == PlayerData.CharacterNames.Dobby)
        {
            pinky = PlayerManager.GetInstance._pinkyDobby;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Glassy)
        {
            pinky = PlayerManager.GetInstance._pinkyGlassy;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Spartacus)
        {
            pinky = PlayerManager.GetInstance._pinkySpartacus;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Lusth)
        {
            pinky = PlayerManager.GetInstance._pinkyLusth;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Guard)
        {
            pinky = PlayerManager.GetInstance._pinkyGuard;
        }
        else
        {
            pinky = PlayerManager.GetInstance._pinkyDobby;
        }
        return pinky;
    }
    public void ChooseGunTransform(GameObject pinky)//Getting finger transform parameter
    {
        if (bulletData.currentWeaponName == BulletData.ak47)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(0);
        }
        else if (bulletData.currentWeaponName == BulletData.rifle)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(1);
        }
        else if (bulletData.currentWeaponName == BulletData.bulldog)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(2);
        }
        else if (bulletData.currentWeaponName == BulletData.cowgun)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(3);
        }
        else if (bulletData.currentWeaponName == BulletData.crystalgun)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(4);
        }
        else if (bulletData.currentWeaponName == BulletData.demongun)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(5);
        }
        else if (bulletData.currentWeaponName == BulletData.icegun)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(6);
        }
        else if (bulletData.currentWeaponName == BulletData.negev)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(7);
        }
        else if (bulletData.currentWeaponName == BulletData.axegun)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(1).GetChild(8);
        }
    }
    public void ChooseSwordTransform(GameObject pinky)//Getting finger transform parameter
    {
        if (bulletData.currentWeaponName == BulletData.lowSword)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(0);
        }
        else if (bulletData.currentWeaponName == BulletData.warriorSword)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(1);
        }
        else if (bulletData.currentWeaponName == BulletData.hummer)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(2);
        }
        else if (bulletData.currentWeaponName == BulletData.orcSword)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(3);
        }
        else if (bulletData.currentWeaponName == BulletData.axeSword)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(4);
        }
        else if (bulletData.currentWeaponName == BulletData.axeKnight)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(5);
        }
        else if (bulletData.currentWeaponName == BulletData.barbarianSword)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(6);
        }
        else if (bulletData.currentWeaponName == BulletData.demonSword)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(7);
        }
        else if (bulletData.currentWeaponName == BulletData.magicSword)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(8);
        }
        else if (bulletData.currentWeaponName == BulletData.longHummer)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(9);
        }
        else if (bulletData.currentWeaponName == BulletData.club)
        {
            PlayerManager.GetInstance._gunTransform = pinky.transform.GetChild(2).GetChild(10);
        }
    }
    public void DestroyWeaponObject()
    {   
        if (bulletData.isRifle)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.axegun
                || bulletData.currentWeaponName == BulletData.crystalgun || bulletData.currentWeaponName == BulletData.demongun || 
                bulletData.currentWeaponName == BulletData.icegun || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cowgun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.rifle;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isRifle = false;
        }
        else if (bulletData.isAk47)
        {
            if (bulletData.currentWeaponName == BulletData.rifle || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.axegun
                || bulletData.currentWeaponName == BulletData.crystalgun || bulletData.currentWeaponName == BulletData.demongun ||
                bulletData.currentWeaponName == BulletData.icegun || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cowgun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.ak47;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isAk47 = false;
        }
        else if (bulletData.isAxegun)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.rifle
                || bulletData.currentWeaponName == BulletData.crystalgun || bulletData.currentWeaponName == BulletData.demongun ||
                bulletData.currentWeaponName == BulletData.icegun || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cowgun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.axegun;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isAxegun = false;
        }
        else if (bulletData.isNegev)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.axegun || bulletData.currentWeaponName == BulletData.rifle
                || bulletData.currentWeaponName == BulletData.crystalgun || bulletData.currentWeaponName == BulletData.demongun ||
                bulletData.currentWeaponName == BulletData.icegun || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cowgun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.negev;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isNegev = false;
        }
        else if (bulletData.isCrystalgun)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.rifle
                || bulletData.currentWeaponName == BulletData.axegun || bulletData.currentWeaponName == BulletData.demongun ||
                bulletData.currentWeaponName == BulletData.icegun || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cowgun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.crystalgun;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isCrystalgun = false;
        }
        else if (bulletData.isDemongun)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.rifle
                || bulletData.currentWeaponName == BulletData.crystalgun || bulletData.currentWeaponName == BulletData.axegun ||
                bulletData.currentWeaponName == BulletData.icegun || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cowgun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.demongun;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isDemongun = false;
        }
        else if (bulletData.isIcegun)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.rifle
                || bulletData.currentWeaponName == BulletData.crystalgun || bulletData.currentWeaponName == BulletData.demongun ||
                bulletData.currentWeaponName == BulletData.axegun || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cowgun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.icegun;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isIcegun = false;
        }
        else if (bulletData.isBulldog)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.rifle
                || bulletData.currentWeaponName == BulletData.crystalgun || bulletData.currentWeaponName == BulletData.demongun ||
                bulletData.currentWeaponName == BulletData.icegun || bulletData.currentWeaponName == BulletData.axegun || bulletData.currentWeaponName == BulletData.cowgun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.bulldog;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isBulldog = false;
        }
        else if (bulletData.isCowgun)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.rifle
                || bulletData.currentWeaponName == BulletData.crystalgun || bulletData.currentWeaponName == BulletData.demongun ||
                bulletData.currentWeaponName == BulletData.icegun || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.axegun)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.cowgun;
                ChooseGunTransform(GetPinky());
                CreateWeaponObject();
            }
            bulletData.isCowgun = false;
        }
    }
    public void DestroySwordObject()
    {
        if (bulletData.isLowSword)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.lowSword;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isLowSword = false;
        }
        else if (bulletData.isWarriorSword)
        {
            if (bulletData.currentSwordName == BulletData.lowSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.warriorSword;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isWarriorSword = false;
        }
        else if (bulletData.isHummer)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.lowSword || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.hummer;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isHummer = false;
        }
        else if (bulletData.isOrcSword)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.lowSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.orcSword;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isOrcSword = false;
        }
        else if (bulletData.isAxeSword)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.lowSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.axeSword;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isAxeSword = false;
        }
        else if (bulletData.isAxeKnight)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.lowSword ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.axeKnight;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isAxeKnight = false;
        }
        else if (bulletData.isBarbarianSword)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.lowSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.barbarianSword;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isBarbarianSword = false;
        }
        else if (bulletData.isDemonSword)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.lowSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.demonSword;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isDemonSword = false;
        }
        else if (bulletData.isMagicSword)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.lowSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.magicSword;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isMagicSword = false;
        }
        else if (bulletData.isLongHummer)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.lowSword || bulletData.currentSwordName == BulletData.club)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.longHummer;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isLongHummer = false;
        }
        else if (bulletData.isClub)
        {
            if (bulletData.currentSwordName == BulletData.warriorSword || bulletData.currentSwordName == BulletData.hummer || bulletData.currentSwordName == BulletData.orcSword
                || bulletData.currentSwordName == BulletData.axeSword || bulletData.currentSwordName == BulletData.axeKnight ||
                bulletData.currentSwordName == BulletData.barbarianSword || bulletData.currentSwordName == BulletData.demonSword || bulletData.currentSwordName == BulletData.magicSword
                || bulletData.currentSwordName == BulletData.longHummer || bulletData.currentSwordName == BulletData.lowSword)
            {
                Destroy(_currentSwordObject);
                bulletData.currentWeaponName = BulletData.club;
                ChooseSwordTransform(GetPinky());
                CreateSwordObject();
            }
            bulletData.isClub = false;
        }
    }
    void FixedUpdate()
    {//Bullet Sound Opening With Fix Because Of This Method

        DestroyWeaponObject();
        DestroySwordObject();

        BulletRotation(_playerData.isLookingUp, 
                       PlayerManager.GetInstance._currentCamera.transform.GetComponent<CinemachineVirtualCamera>(), 
                       _bulletSpawnTransform);

        if (_playerData.isFiring && !_playerData.isSwording && bulletData.bulletDelayCounter == 0)
        {
            bulletData.bulletDelayCounter++;       
            
            StartCoroutine(Delay(bulletData.bulletDelay, 0));
        }
        if (_playerData.isSwording && !_playerData.isFiring && bulletData.bulletDelayCounter == 0 && _playerData.isSwordTime)
        {
            bulletData.bulletDelayCounter++;

            StartCoroutine(Delay(bulletData.bulletDelay, 2));
        }
    }

    IEnumerator Delay(float delayValue, int objectPoolCount)
    {
        if (objectPoolCount == 2)
        {
            //yield return new WaitForSeconds(1);
            _currentSwordObject.SetActive(true);
            _currentWeaponObject.SetActive(false);
            yield return new WaitForSeconds(delayValue);
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Sword);
            _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._currentCamera.transform.position.x, _bulletSpawnTransform.transform.position.y, _bulletSpawnTransform.transform.position.z);
            CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, PlayerManager.GetInstance._objectPool, 1f);
            bulletData.bulletDelayCounter = 0;
            yield return new WaitForSeconds(delayValue * 50f);
            //_swordObject.SetActive(false);
        }
        else
        {
            _currentWeaponObject.SetActive(true);
            _currentSwordObject.SetActive(false);
            yield return new WaitForSeconds(delayValue);
            if (_playerData.bulletAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
            }
            else
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
            }
            _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._currentCamera.transform.position.x, 
                                                         _bulletSpawnTransform.transform.position.y, 
                                                         _bulletSpawnTransform.transform.position.z);
            if (_playerData.bulletAmount >= 0)
            {
                CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, PlayerManager.GetInstance._objectPool, 2f);
            }
            bulletData.bulletDelayCounter = 0;
            //yield return new WaitForSeconds(delayValue * 50f);
            //_currentWeaponObject.SetActive(false);
            //yield return new WaitForSeconds(3f);
            //_currentSwordObject.SetActive(true);
        }
        
    }

}
