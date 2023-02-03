using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AbstractPlayerAnimation<PlayerAnimationController>
{
    [Header("Animator")]
    private Animator _animator;

    [Header("Data")]
    public PlayerData playerData;
    public PlayerData cloneData;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator != null)
        {
            _animator.SetLayerWeight(8, 0);
        }
        //_playerController = FindObjectOfType<PlayerController>();
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