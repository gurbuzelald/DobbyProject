using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public PlayerData _playerData;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        AnimationStates();
    }
    public void AnimationStates()
    {
        IdleAnimation();
        JumpAnimation();
        WalkAnimation();
        ClimbAnimation();
        FireAnimation();
    }
    void IdleAnimation()
    {
        if (_playerData.isIdling && PlayerManager.GetInstance._xValue == 0 && PlayerManager.GetInstance._zValue == 0 && !_playerData.isJumping)
        {
            _animator.SetBool("isIdling", true);

            _animator.SetBool("isWalking", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
        }
    }
    void WalkAnimation()
    {
        if (_playerData.isWalking && !_playerData.isBackWalking && !_playerData.isJumping)
        {
            _animator.SetBool("isWalking", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 0);
        }
        else if (_playerData.isBackWalking && !_playerData.isWalking && !_playerData.isJumping)
        {
            _animator.SetBool("isBackWalking", true);

            _animator.SetBool("isWalking", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(2, 1);
            _animator.SetLayerWeight(1, 0);
        }
        else if (!_playerData.isBackWalking && !_playerData.isWalking && !_playerData.isClimbing && !_playerData.isJumping)
        {
            _animator.SetBool("isIdling", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
        }
        
        RightWalkAnimation();
        LeftWalkAnimation();
    }
    void LeftWalkAnimation()
    {
        if (PlayerManager.GetInstance._xValue < 0)
        {
            _animator.SetBool("isLeftWalk", true);

            _animator.SetBool("isIdling", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isRightWalk", false);

            _animator.SetLayerWeight(5, 1);

        }
        else if (PlayerManager.GetInstance._xValue == 0 && !_playerData.isJumping)
        {
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(0, 1);
        }
    }
    void RightWalkAnimation()
    {
        if (PlayerManager.GetInstance._xValue > 0)
        {
            _animator.SetBool("isRightWalk", true);

            _animator.SetBool("isLeftWalk", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(6, 1);
            _animator.SetLayerWeight(0, 0);
        }
        else if (PlayerManager.GetInstance._xValue == 0 && !_playerData.isJumping)
        {
            _animator.SetLayerWeight(6, 0);
            _animator.SetLayerWeight(0, 1);
        }
    }

    void ClimbAnimation()
    {
        if (_playerData.isClimbing && PlayerManager.GetInstance._zValue > 0)
        {
            _animator.SetBool("isIdling", false);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", true);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 1);
        }
        if (_playerData.isClimbing && PlayerManager.GetInstance._zValue < 0)
        {
            _animator.SetBool("isIdling", false);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", true);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(4, 1);
        }
        else if (PlayerManager.GetInstance._zValue == 0)
        {
            _animator.SetBool("isIdling", false);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", true);

            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(4, 0);
        }
        if ((_playerData.isClimbing || !_playerData.isClimbing) && PlayerManager.GetInstance._zValue == 0 && !_playerData.isFiring && !_playerData.isJumping)
        {
            _animator.SetBool("isIdling", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
        }        
    }
    void FireAnimation()
    {
        if (_playerData.isFiring)
        {
            _animator.SetBool("isFiring", true);

            _animator.SetBool("isIdling", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
        else if (!_playerData.isFiring && PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0 && !_playerData.isClimbing)
        {
            _animator.SetBool("isIdling", true);

            _animator.SetBool("isFiring", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
    }
    void JumpAnimation()
    {
        if (_playerData.isJumping && _playerData.isGround && (PlayerManager.GetInstance._zValue > 0 || PlayerManager.GetInstance._xValue > 0))
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool("isWalking", true);
            _animator.SetBool("isJumping", false);
        }
        if (_playerData.isJumping && PlayerManager.GetInstance._zValue == 0)
        {
            _animator.SetBool("isJumping", true);

            _animator.SetBool("isIdling", false);
            _animator.SetBool("isFiring", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
        else if (_playerData.isJumping && PlayerManager.GetInstance._zValue > 0)
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool("isJumping", true);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isFiring", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
        else if (!_playerData.isJumping && PlayerManager.GetInstance._zValue > 0)
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool("isJumping", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isFiring", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
        else if (!_playerData.isJumping && !_playerData.isWalking && PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0)
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isWalking", false);

            _animator.SetLayerWeight(1, 0);
        }
    }
    IEnumerator DelayAnimation(float value)
    {
        yield return new WaitForSeconds(value);
        _animator.SetLayerWeight(7, 0);
    }
}