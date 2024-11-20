using UnityEngine;

[CreateAssetMenu(fileName = "MainEnemyData", menuName = "Scriptable Objects/MainEnemyData")]
public class MainEnemyData : ScriptableObject
{
    [Header("Enemy Death Count")]
    public static int enemyDeathCount;

    [Header("Sounds")]
    //public AudioClip shootClip;
    public AudioClip getHitClip;
    public AudioClip giveHitClip;
    public AudioClip dyingClip;
    public AudioClip giveBulletHitClip;

    public int enemyID;
}
