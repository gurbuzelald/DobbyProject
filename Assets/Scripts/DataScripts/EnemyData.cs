using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Particles")]
    public GameObject _enemyDestroyParticle;
    public GameObject currentBulletExplosionParticle;    
    public GameObject currentSwordBulletExplosionParticle;    

    [Header("Bullet Object")]
    public GameObject _playerBulletObject;

    [Header("Enemy Death Count")]
    public static int enemyDeathCount;


    [Header("Sounds")]
    //public AudioClip shootClip;
    public AudioClip getHitClip;
    public AudioClip giveHitClip;
    public AudioClip dyingClip;
    public AudioClip giveBulletHitClip;


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
    public bool isSpeedZero;
    public bool isWalkable;

    public bool isActivateCreateEnemy;

    [Header("Particle Burning Effect")]
    public ParticleSystem currentBottomParticle;
    public ParticleSystem currentMiddleParticle;
    public ParticleSystem currentTopParticle;
}
