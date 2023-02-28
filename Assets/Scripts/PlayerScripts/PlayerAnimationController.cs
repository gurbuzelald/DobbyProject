using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AbstractPlayerAnimation<PlayerAnimationController>
{
    [Header("Animator")]
    private Animator _animator;
    private Animator _slaveAnimator;

    [Header("Data")]
    public PlayerData playerData;
    public SlaveData slaveData;
    public PlayerData cloneData;

    void OnEnable()
    {
        if (gameObject.transform.CompareTag(SceneController.Tags.Slave.ToString()))
        {
            _slaveAnimator = GetComponent<Animator>();
        }
        else
        {
            _animator = GetComponent<Animator>();
        }

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
        if (gameObject.transform.CompareTag(SceneController.Tags.Slave.ToString()) && slaveData != null)
        {
            if (slaveData.isSwording == true)
            {
                SlaveSwordingAnimation(_slaveAnimator);
            }
            else
            {
                SlaveWalkAnimation(playerData, _slaveAnimator);
                SlaveBackWalkAnimation(playerData, _slaveAnimator);
            }
        }
        else
        {
            PickupAnimation(playerData, _animator);
            IdleAnimation(playerData, _animator);
            JumpAnimation(playerData, _animator);
            WalkAnimation(playerData, _animator);
            ClimbAnimation(playerData, _animator);
            FireAnimation(playerData, _animator);
            SwordAnimation(playerData, _animator);
            DeathAnimation(playerData, _animator, cloneData);
            VictoryAnimation(playerData, _animator);
            SkateBoardAnimation(playerData, _animator);
            RunAnimation(playerData, _animator);
            PickRotateAnimation(playerData, _animator);
        }
        
    }
    public void SlaveSwordingAnimation(Animator _slaveAnimator)
    {
        base.SlaveFireAnimation(_slaveAnimator);
    }
}