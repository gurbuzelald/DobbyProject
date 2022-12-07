using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "BulletData")]
public class BulletData : ScriptableObject
{
    [Header("Player")]
    [Header("Bullet Transform")]
    public float bulletDelay = 0.05f;
    public float bulletSpeed = 5f;
    public int bulletDelayCounter;

    [Header("Enemy")]
    [Header("Bullet Transform")]
    public int enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed = 3f;
}
