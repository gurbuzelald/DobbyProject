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

    public static bool isCreatedWeaponBullet;

    void Start()
    {
        SetWeaponTransform();

        isCreatedWeaponBullet = false;
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
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.warriorSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.warriorSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.hummer == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.hummerObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.orcSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.orcObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.axeSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.axeSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.axeKnight == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.axeKnightObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.barbarianSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.barbarianSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.demonSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.demonSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);

        }
        else if (BulletData.magicSword == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.magicWeaponObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.longHummer == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.longHummerObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        else if (BulletData.club == bulletData.currentSwordName)
        {
            _currentSwordObject = Instantiate(bulletData.clubObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform.transform);
        }
        _currentSwordObject.SetActive(false);

        _currentSwordObject.transform.position = PlayerManager.GetInstance._swordTransform.transform.position;

        _currentSwordObject.transform.rotation = PlayerManager.GetInstance._swordTransform.transform.rotation;
    }
    public void CreateWeaponObject()
    {
        if (bulletData.currentWeaponName == BulletData.ak47)
        {
            _currentWeaponObject = Instantiate(bulletData.ak47Object,
                                               _bulletSpawnTransform.position,
                                               Quaternion.identity,
                                               PlayerManager.GetInstance._gunTransform.transform);
        }
        else if (bulletData.currentWeaponName == BulletData.m4a4)
        {
            _currentWeaponObject = Instantiate(bulletData.m4a4Object,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);
        }
        else if (bulletData.currentWeaponName == BulletData.bulldog)
        {
            _currentWeaponObject = Instantiate(bulletData.bullDogObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);
        }
        else if (bulletData.currentWeaponName == BulletData.cow)
        {
            _currentWeaponObject = Instantiate(bulletData.cowObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);

        }
        else if (bulletData.currentWeaponName == BulletData.crystal)
        {
            _currentWeaponObject = Instantiate(bulletData.crsytalObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);
        }
        else if (bulletData.currentWeaponName == BulletData.demon)
        {
            _currentWeaponObject = Instantiate(bulletData.demonObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);
        }
        else if (bulletData.currentWeaponName == BulletData.ice)
        {
            _currentWeaponObject = Instantiate(bulletData.iceObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);
        }
        else if (bulletData.currentWeaponName == BulletData.negev)
        {
            _currentWeaponObject = Instantiate(bulletData.negevObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);
        }
        else if (bulletData.currentWeaponName == BulletData.axe)
        {
            _currentWeaponObject = Instantiate(bulletData.axeObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);
        }
        else if (bulletData.currentWeaponName == BulletData.pistol)
        {
            _currentWeaponObject = Instantiate(bulletData.pistolObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform.transform);
        }
        else
        {
            Debug.Log("Check current weapon name");
        }

        _currentWeaponObject.SetActive(true);

        _currentWeaponObject.transform.position = PlayerManager.GetInstance._gunTransform.transform.position;
        _currentWeaponObject.transform.rotation = PlayerManager.GetInstance._gunTransform.transform.rotation;
    }

    public void SetWeaponTransform()//Getting finger transform parameter
    {
        if (bulletData.currentWeaponName == BulletData.ak47)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("Ak47Transform");
        }
        else if (bulletData.currentWeaponName == BulletData.m4a4)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("M4a4Transform");
        }
        else if (bulletData.currentWeaponName == BulletData.bulldog)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("BulldogTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.cow)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("CowTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.crystal)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("CrystalTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.demon)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("DemonTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.ice)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("IceTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.negev)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("NegevTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.axe)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("AxeTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.pistol)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("PistolTransform");
        }
    }
    public void SetSwordTransform(GameObject pinky)//Getting finger transform parameter
    {
        if (bulletData.currentWeaponName == BulletData.lowSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("LowSwordTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.warriorSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("WarriorSwordTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.hummer)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("HummerTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.orcSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("OrcSwordTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.axeSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("AxeSwordTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.axeKnight)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("AxeKnightTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.barbarianSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("BarbarianSwordTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.demonSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("DemonSwordTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.magicSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("MagicSwordTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.longHummer)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("LongHummerTransform");
        }
        else if (bulletData.currentWeaponName == BulletData.club)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("ClubTransform");
        }
    }
    public void DestroyWeaponObject()
    {   
        if (bulletData.isM4a4)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.axe
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.demon || 
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cow ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.m4a4;
                CreateWeaponObject();
            }
            bulletData.isM4a4 = false;
        }
        else if (bulletData.isAk47)
        {
            if (bulletData.currentWeaponName == BulletData.m4a4 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.axe
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.demon ||
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cow ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.ak47;
                CreateWeaponObject();
            }
            bulletData.isAk47 = false;
        }
        else if (bulletData.isAxe)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.m4a4
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.demon ||
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cow ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.axe;
                CreateWeaponObject();
            }
            bulletData.isAxe = false;
        }
        else if (bulletData.isNegev)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.axe || bulletData.currentWeaponName == BulletData.m4a4
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.demon ||
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cow ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.negev;
                CreateWeaponObject();
            }
            bulletData.isNegev = false;
        }
        else if (bulletData.isCrystal)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.m4a4
                || bulletData.currentWeaponName == BulletData.axe || bulletData.currentWeaponName == BulletData.demon ||
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cow ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.crystal;
                CreateWeaponObject();
            }
            bulletData.isCrystal = false;
        }
        else if (bulletData.isDemon)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.m4a4
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.axe ||
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cow ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.demon;
                CreateWeaponObject();
            }
            bulletData.isDemon = false;
        }
        else if (bulletData.isIce)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.m4a4
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.demon ||
                bulletData.currentWeaponName == BulletData.axe || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.cow ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.ice;
                CreateWeaponObject();
            }
            bulletData.isIce = false;
        }
        else if (bulletData.isBulldog)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.m4a4
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.demon ||
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.axe || bulletData.currentWeaponName == BulletData.cow ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.bulldog;
                CreateWeaponObject();
            }
            bulletData.isBulldog = false;
        }
        else if (bulletData.isCow)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.m4a4
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.demon ||
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.axe ||
                bulletData.currentWeaponName == BulletData.pistol)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.cow;
                CreateWeaponObject();
            }
            bulletData.isCow = false;
        }
        else if (bulletData.isPistol)
        {
            if (bulletData.currentWeaponName == BulletData.ak47 || bulletData.currentWeaponName == BulletData.negev || bulletData.currentWeaponName == BulletData.m4a4
                || bulletData.currentWeaponName == BulletData.crystal || bulletData.currentWeaponName == BulletData.demon ||
                bulletData.currentWeaponName == BulletData.ice || bulletData.currentWeaponName == BulletData.bulldog || bulletData.currentWeaponName == BulletData.axe ||
                bulletData.currentWeaponName == BulletData.cow)
            {
                Destroy(_currentWeaponObject);
                bulletData.currentWeaponName = BulletData.pistol;
                CreateWeaponObject();
            }
            bulletData.isPistol = false;
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
                CreateSwordObject();
            }
            bulletData.isClub = false;
        }
    }
    void FixedUpdate()
    {//Bullet Sound Opening With Fix Because Of This Method

        DestroyWeaponObject();
        DestroySwordObject();

        BulletRotation(PlayerManager.GetInstance._currentCamera,
                       _bulletSpawnTransform);
        
        if (_playerData.isSwording && !_playerData.isFireNonWalk && bulletData.bulletDelayCounter == 0 && _playerData.isSwordTime)
        {
           
            bulletData.bulletDelayCounter++;

            StartCoroutine(Delay(bulletData.weaponBulletDelay, 2));
        }
        WeaponFire();
    }

    public void WeaponFire()
    {
        if ((_playerData.isFireNonWalk || _playerData.isFireWalk) && !_playerData.isSwording && bulletData.bulletDelayCounter == 0 && _playerData.isFireTime)
        {
            bulletData.bulletDelayCounter++;

            StartCoroutine(Delay(bulletData.weaponBulletDelay, 0));
        }
    }

    public void WeaponSoundTypeState()
    {//PlayerManager.GetInstance.SwordSFX(_playerData);
        if (bulletData.currentWeaponName == BulletData.ak47)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Ak47);
        }
        else if (bulletData.currentWeaponName == BulletData.m4a4)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.M4a4);
        }
        else if (bulletData.currentWeaponName == BulletData.bulldog)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Bulldog);
        }
        else if (bulletData.currentWeaponName == BulletData.cow)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Cow);
        }
        else if (bulletData.currentWeaponName == BulletData.crystal)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Crystal);
        }
        else if (bulletData.currentWeaponName == BulletData.demon)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Demon);
        }
        else if (bulletData.currentWeaponName == BulletData.ice)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Ice);
        }
        else if (bulletData.currentWeaponName == BulletData.negev)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Negev);
        }
        else if (bulletData.currentWeaponName == BulletData.axe)
        {            
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Axe);
        }
        else if (bulletData.currentWeaponName == BulletData.pistol)
        {
            PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Pistol);
        }
    }

    public void SwordSoundTypeState()
    {
        if (bulletData.currentSwordName == BulletData.lowSword)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.LowSword);
        }
        else if (bulletData.currentSwordName == BulletData.warriorSword)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.WarriorSword);
        }
        else if (bulletData.currentSwordName == BulletData.hummer)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.Hummer);
        }
        else if (bulletData.currentSwordName == BulletData.orcSword)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.OrcSword);
        }
        else if (bulletData.currentSwordName == BulletData.axeSword)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.AxeSword);
        }
        else if (bulletData.currentSwordName == BulletData.axeKnight)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.AxeKnight);
        }
        else if (bulletData.currentSwordName == BulletData.barbarianSword)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.BarbarianSword);
        }
        else if (bulletData.currentSwordName == BulletData.demonSword)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.DemonSword);
        }
        else if (bulletData.currentSwordName == BulletData.magicSword)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.MagicSword);
        }
        else if (bulletData.currentSwordName == BulletData.longHummer)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.LongHummer);
        }
        else if (bulletData.currentSwordName == BulletData.club)
        {
            PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.Club);
        }
    }
    IEnumerator Delay(float delayValue, int objectPoolCount)
    {        
        if (objectPoolCount == 2)
        {//SwordBullet
            //yield return new WaitForSeconds(1);
            _currentSwordObject.SetActive(true);
            _currentWeaponObject.SetActive(false);
            yield return new WaitForSeconds(delayValue);
             
            SwordSoundTypeState();

            _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._currentCamera.transform.position.x, 
                                                        _bulletSpawnTransform.transform.position.y, 
                                                        _bulletSpawnTransform.transform.position.z);
            CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, PlayerManager.GetInstance._objectPool, 1f, .1f);
            bulletData.bulletDelayCounter = 0;
            yield return new WaitForSeconds(delayValue * 50f);
            //_swordObject.SetActive(false);
        }
        else if (objectPoolCount == 0)
        {//WeaponBullet
            _currentWeaponObject.SetActive(true);
            _currentSwordObject.SetActive(false);
            yield return new WaitForSeconds(delayValue);
            if (_playerData.bulletAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
            }
            else
            {
                WeaponSoundTypeState();
                CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, PlayerManager.GetInstance._objectPool, 0f, 3f);
                isCreatedWeaponBullet = true;
            }
            //PlayerManager.GetInstance._currentCamera.transform.position.x
            _bulletSpawnTransform.position = new Vector3(_bulletSpawnTransform.transform.position.x, 
                                                         _bulletSpawnTransform.transform.position.y, 
                                                         _bulletSpawnTransform.transform.position.z);
            bulletData.bulletDelayCounter = 0;
            //yield return new WaitForSeconds(delayValue * 50f);
            //_currentWeaponObject.SetActive(false);
            //yield return new WaitForSeconds(3f);
            //_currentSwordObject.SetActive(true);
        }
        
    }
}
