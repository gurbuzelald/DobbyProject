using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioMusicData", menuName = "AudioMusicData")]
public class AudioData : ScriptableObject
{
    public AudioClip gameMusic;
    public AudioClip menuMusic;
    public AudioClip endMusic;    
    public AudioClip winMusic;


    [Header("Sounds")]

    //Defaulth
    [Header("Defaulth")]
    //public AudioClip shootClip;
    public AudioClip nonShootClip;
    public AudioClip swordClip;
    public AudioClip getHitClip;
    public AudioClip jumpingClip;
    public AudioClip dyingClip;
    public AudioClip pickupCoinClip;
    public AudioClip pickupBulletCoinClip;
    public AudioClip errorPickupBulletCoinClip;
    public AudioClip trapClip;
    public AudioClip levelUpClip;
    public AudioClip jumpingSeaClip;


    [Header("Dobby")]
    public AudioClip dobbyNonShootClip;
    public AudioClip dobbyPoisonClip;
    public AudioClip dobbyGetEnemyHitClip;
    public AudioClip dobbyGetBulletHitClip;
    public AudioClip dobbyJumpingClip;
    public AudioClip dobbyDyingClip;
    public AudioClip dobbyPickupCoinClip;
    public AudioClip dobbyPickupBulletCoinClip;
    public AudioClip dobbyErrorPickupBulletCoinClip;
    public AudioClip dobbyTrapClip;
    public AudioClip dobbyLevelUpClip;
    public AudioClip dobbyJumpingSeaClip;



    [Header("Glassy")]
    public AudioClip glassyNonShootClip;
    public AudioClip glassyPoisonClip;
    public AudioClip glassyGetEnemyHitClip;
    public AudioClip glassyGetBulletHitClip;
    public AudioClip glassyJumpingClip;
    public AudioClip glassyDyingClip;
    public AudioClip glassyPickupCoinClip;
    public AudioClip glassyPickupBulletCoinClip;
    public AudioClip glassyErrorPickupBulletCoinClip;
    public AudioClip glassyTrapClip;
    public AudioClip glassyLevelUpClip;
    public AudioClip glassyJumpingSeaClip;


    [Header("Spartacus")]
    public AudioClip spartacusNonShootClip;
    public AudioClip spartacusPoisonClip;
    public AudioClip spartacusGetEnemyHitClip;
    public AudioClip spartacusGetBulletHitClip;
    public AudioClip spartacusJumpingClip;
    public AudioClip spartacusDyingClip;
    public AudioClip spartacusPickupCoinClip;
    public AudioClip spartacusPickupBulletCoinClip;
    public AudioClip spartacusErrorPickupBulletCoinClip;
    public AudioClip spartacusTrapClip;
    public AudioClip spartacusLevelUpClip;
    public AudioClip spartacusJumpingSeaClip;


    [Header("Guard")]
    public AudioClip guardNonShootClip;
    public AudioClip guardPoisonClip;
    public AudioClip guardGetEnemyHitClip;
    public AudioClip guardGetBulletHitClip;
    public AudioClip guardJumpingClip;
    public AudioClip guardDyingClip;
    public AudioClip guardPickupCoinClip;
    public AudioClip guardPickupBulletCoinClip;
    public AudioClip guardErrorPickupBulletCoinClip;
    public AudioClip guardTrapClip;
    public AudioClip guardLevelUpClip;
    public AudioClip guardJumpingSeaClip;


    [Header("Lusth")]
    public AudioClip lusthNonShootClip;
    public AudioClip lusthPoisonClip;
    public AudioClip lusthGetEnemyHitClip;
    public AudioClip lusthGetBulletHitClip;
    public AudioClip lusthJumpingClip;
    public AudioClip lusthDyingClip;
    public AudioClip lusthPickupCoinClip;
    public AudioClip lusthPickupBulletCoinClip;
    public AudioClip lusthErrorPickupBulletCoinClip;
    public AudioClip lusthTrapClip;
    public AudioClip lusthLevelUpClip;
    public AudioClip lusthJumpingSeaClip;

    [Header("Eve")]
    public AudioClip eveNonShootClip;
    public AudioClip evePoisonClip;
    public AudioClip eveGetEnemyHitClip;
    public AudioClip eveGetBulletHitClip;
    public AudioClip eveJumpingClip;
    public AudioClip eveDyingClip;
    public AudioClip evePickupCoinClip;
    public AudioClip evePickupBulletCoinClip;
    public AudioClip eveErrorPickupBulletCoinClip;
    public AudioClip eveTrapClip;
    public AudioClip eveLevelUpClip;
    public AudioClip eveJumpingSeaClip;

    [Header("Michelle")]
    public AudioClip michelleNonShootClip;
    public AudioClip michellePoisonClip;
    public AudioClip michelleGetEnemyHitClip;
    public AudioClip michelleGetBulletHitClip;
    public AudioClip michelleJumpingClip;
    public AudioClip michelleDyingClip;
    public AudioClip michellePickupCoinClip;
    public AudioClip michellePickupBulletCoinClip;
    public AudioClip michelleErrorPickupBulletCoinClip;
    public AudioClip michelleTrapClip;
    public AudioClip michelleLevelUpClip;
    public AudioClip michelleJumpingSeaClip;
    
    [Header("Boss")]
    public AudioClip bossNonShootClip;
    public AudioClip bossPoisonClip;
    public AudioClip bossGetEnemyHitClip;
    public AudioClip bossGetBulletHitClip;
    public AudioClip bossJumpingClip;
    public AudioClip bossDyingClip;
    public AudioClip bossPickupCoinClip;
    public AudioClip bossPickupBulletCoinClip;
    public AudioClip bossErrorPickupBulletCoinClip;
    public AudioClip bossTrapClip;
    public AudioClip bossLevelUpClip;
    public AudioClip bossJumpingSeaClip;

    [Header("Aj")]
    public AudioClip ajNonShootClip;
    public AudioClip ajPoisonClip;
    public AudioClip ajGetEnemyHitClip;
    public AudioClip ajGetBulletHitClip;
    public AudioClip ajJumpingClip;
    public AudioClip ajDyingClip;
    public AudioClip ajPickupCoinClip;
    public AudioClip ajPickupBulletCoinClip;
    public AudioClip ajErrorPickupBulletCoinClip;
    public AudioClip ajTrapClip;
    public AudioClip ajLevelUpClip;
    public AudioClip ajJumpingSeaClip;


    [Header("Mremireh")]
    public AudioClip mremirehNonShootClip;
    public AudioClip mremirehPoisonClip;
    public AudioClip mremirehGetEnemyHitClip;
    public AudioClip mremirehGetBulletHitClip;
    public AudioClip mremirehJumpingClip;
    public AudioClip mremirehDyingClip;
    public AudioClip mremirehPickupCoinClip;
    public AudioClip mremirehPickupBulletCoinClip;
    public AudioClip mremirehErrorPickupBulletCoinClip;
    public AudioClip mremirehTrapClip;
    public AudioClip mremirehLevelUpClip;
    public AudioClip mremirehJumpingSeaClip;

    [Header("Ty")]
    public AudioClip tyNonShootClip;
    public AudioClip tyPoisonClip;
    public AudioClip tyGetEnemyHitClip;
    public AudioClip tyGetBulletHitClip;
    public AudioClip tyJumpingClip;
    public AudioClip tyDyingClip;
    public AudioClip tyPickupCoinClip;
    public AudioClip tyPickupBulletCoinClip;
    public AudioClip tyErrorPickupBulletCoinClip;
    public AudioClip tyTrapClip;
    public AudioClip tyLevelUpClip;
    public AudioClip tyJumpingSeaClip;

    [Header("Weapons")]
    public AudioClip Ak47Clip;
    public AudioClip RifleClip;
    public AudioClip BulldogClip;
    public AudioClip CowgunClip;
    public AudioClip CrystalgunClip;
    public AudioClip DemongunClip;
    public AudioClip IcegunClip;
    public AudioClip NegevClip;
    public AudioClip AxegunClip;

    [Header("Swords")]
    public AudioClip LowSwordClip;
    public AudioClip WarriorSwordClip;
    public AudioClip HummerClip;
    public AudioClip OrcSwordClip;
    public AudioClip AxeSwordClip;
    public AudioClip AxeKnightClip;
    public AudioClip BarbarianSwordClip;
    public AudioClip DemonSwordClip;
    public AudioClip MagicSwordClip;
    public AudioClip LongHummerClip;
    public AudioClip ClubClip;
}
