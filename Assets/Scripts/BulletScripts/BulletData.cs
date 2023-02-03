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

    public GameObject _pistolObject;
    public GameObject _swordObject;

    [Header("Enemy")]
    [Header("Bullet Transform")]
    public int enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed = 3f;
}
