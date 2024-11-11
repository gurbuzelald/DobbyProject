using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Serializable]
    public struct EnemyStats
    {
        public string currentEnemyName;

        public bool[] isGround;
        public bool[] enemyDying;
        public bool[] isWalking;
        public bool[] isFiring;
        public bool[] isAttacking;
        public bool[] isTouchable;
        public bool[] isActivateMagnet;
        public bool[] isSpeedZero;
        public float[] bulletDamageValue;

        public float enemySpeed;
        public float enemyDurability;
    }

    public EnemyStats[] enemyStats = new EnemyStats[14];

    public bool isActivateCreateEnemy;
}
