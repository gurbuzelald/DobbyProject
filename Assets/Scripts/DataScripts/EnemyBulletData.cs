using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBulletData", menuName = "Scriptable Objects/EnemyBulletData")]
public class EnemyBulletData : ScriptableObject
{
    [Serializable]
    public struct EnemyAttackInfos
    {
        public string bulletName;
        public int id;
        public int bulletDamage;
        public int attackDamage;
        public int hitDamage;
    }

    public EnemyAttackInfos[] enemyAttackInfos = new EnemyAttackInfos[13];


    public int currentEnemyBulletDamage;
    public int currentEnemyAttackDamage;
    public int currentEnemyHitDamage;

    [Header("Bullet Transform")]
    public float enemyFireFrequency;
    public float enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed;

    public bool isFirable;
}
