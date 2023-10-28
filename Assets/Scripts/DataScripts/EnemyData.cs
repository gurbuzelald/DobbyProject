using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Particles")]
    public GameObject _enemyDestroyParticle;
    public GameObject _enemyTouchParticle;

    [Header("Bullet Object")]
    public GameObject _playerBulletObject;

    

    [Header("Sounds")]
    //public AudioClip shootClip;
    public AudioClip getHitClip;
    public AudioClip giveHitClip;
    public AudioClip dyingClip;
    public AudioClip bulletHitClip;
    public AudioClip swordHitClip;

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
    public float swordDamageValue;
    public bool isSpeedZero;
    public bool isWalkable;

    public bool isActivateCreateEnemy;
}
