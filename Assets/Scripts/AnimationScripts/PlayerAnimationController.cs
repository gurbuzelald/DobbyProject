using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AbstractPlayerAnimation<PlayerAnimationController>
{
    [Header("Animator")]
    private Animator _animator;

    [Header("Data")]
    private PlayerData playerData;

    private BulletManager bulletManager;

    [System.Obsolete]
    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        playerData = this.gameObject.transform.parent.transform.parent.GetComponent<PlayerManager>()._playerData;
    }
    void OnEnable()
    {
        _animator = GetComponent<Animator>();

        if (_animator != null)
        {
            _animator.SetLayerWeight(8, 0);
        }
    }
    void Update()
    {       
        AnimationStates();
    }
    public void AnimationStates()
    {
        PickupAnimation(playerData, _animator);
        IdleAnimation(playerData, _animator);
        JumpAnimation(playerData, _animator);
        WalkAnimation(playerData, _animator);
        FireNonWalkAnimation(playerData, _animator);
        SwordAnimation(playerData, _animator);
        DeathAnimation(playerData, _animator);
        VictoryAnimation(playerData, _animator);
        RunAnimation(playerData, _animator);
        PickRotateAnimation(playerData, _animator);

    }
    public void SwordAnimationCompleted()
    {
        //bulletManager.SwordFire();
        playerData.isSwordAnimate = false;
    }
    public void SwordFireBulletParticle()
    {
        if (PlayerManager.GetInstance._playerData)
        {
            bulletManager.SwordFire(PlayerManager.GetInstance._bulletData.swordBulletDelay,
                                    PlayerManager.GetInstance._playerData.playerSwordBulletObjectPoolCount);
        }
    }
}