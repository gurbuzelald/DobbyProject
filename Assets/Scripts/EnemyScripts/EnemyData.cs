using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
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
    public bool isActivateMagnet;

    public float enemySpeed;
    public float enemyBulletSpeed;
}
