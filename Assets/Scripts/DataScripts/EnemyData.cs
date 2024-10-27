using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Scriptable Objects/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Tag")]
    public string currentEnemyName;


    [Header("Bools")]
    public bool isGround;
    public bool isDying;
    public bool isWalking;
    public bool isFiring;
    public bool isAttacking;
    public bool isTouchable;
    public bool isActivateMagnet;

    public float enemySpeed;
    public float bulletDamageValue;
    public float enemyDurability;
    public bool isSpeedZero;

    public bool isActivateCreateEnemy;
}
