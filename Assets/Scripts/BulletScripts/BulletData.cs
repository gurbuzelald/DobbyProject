using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "BulletData")]
public class BulletData : ScriptableObject
{
    [Header("Player")]
    [Header("Bullet Transform")]
    public float bulletDelay = 0.05f;
    public float bulletSpeed = 5f;
    public int bulletDelayCounter;
    public GameObject _bulletObject;
    public GameObject _swordingObject;

    [Header("Bullet Types")]
    public GameObject _pistolObject;
    public GameObject _lowSword;
    public GameObject _warriorSwordObject;
    public GameObject _hummer;

    [Header("ChooseSword")]
    public SwordNames currentSwordName = SwordNames.warriorSword;

    [Header("Enemy")]
    [Header("Bullet Transform")]
    public int enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed = 3f;


    public enum SwordNames
    {
        lowSword,
        warriorSword,
        hummer
    }
}
