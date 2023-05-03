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

    [Header("Objects")]
    public GameObject[] enemyFirstObjects;
    public GameObject[] enemySecondObjects;
    public GameObject[] enemyThirdObjects;
    public GameObject[] enemyFourthObjects;
    public GameObject enemyTransformsFirstMap;
    public GameObject enemyTransformsSecondMap;
    public GameObject enemyTransformsThirdMap;
    public GameObject enemyTransformsFourthMap;

    [Header("Sounds")]
    //public AudioClip shootClip;
    public AudioClip getHitClip;
    public AudioClip giveHitClip;
    public AudioClip dyingClip;

    [Header("Bools")]
    public bool isGround;
    public bool isDying;
    public bool isWalking;
    public bool isFiring;
    public bool isTouchable;
    public bool isActivateMagnet;

    public float enemySpeed;
    public bool isSpeedZero;
}
