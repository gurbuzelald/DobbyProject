using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [Header("Animator")]
    private Animator _animator;

    [Header("Data")]
    public PlayerData _playerData;

    private void Start()
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
        PickupAnimation();
        IdleAnimation();
        JumpAnimation();
        WalkAnimation();
        ClimbAnimation();
        FireAnimation();
        DeathAnimation();
        VictoryAnimation();
        SkateBoardAnimation();
    }
    void IdleAnimation()
    {
        if (_playerData.isIdling && PlayerManager.GetInstance._xValue == 0 && PlayerManager.GetInstance._zValue == 0 && !_playerData.isJumping && !_playerData.isDying)
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
        if (_playerData.isWalking && !_playerData.isBackWalking && !_playerData.isJumping && !_playerData.isClimbing)
        {
            _animator.SetBool("isWalking", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
        }
        else if (_playerData.isBackWalking && !_playerData.isWalking && !_playerData.isJumping && !_playerData.isBackClimbing)
        {
            _animator.SetBool("isBackWalking", true);

            _animator.SetBool("isWalking", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(2, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(4, 0);
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
        if (_playerData.isClimbing && !_playerData.isBackClimbing && PlayerManager.GetInstance._zValue > 0)
        {
            _animator.SetBool("isIdling", false);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", true);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 1);
        }
        if (!_playerData.isClimbing && _playerData.isBackClimbing && PlayerManager.GetInstance._zValue < 0)
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
        if ((_playerData.isClimbing || !_playerData.isClimbing) && PlayerManager.GetInstance._zValue == 0 && !_playerData.isFiring && !_playerData.isJumping)
        {
            _animator.SetBool("isIdling", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);

            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(4, 0);
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
        if (_playerData.isJumping && _playerData.isGround && !_playerData.isSkateBoarding && (PlayerManager.GetInstance._zValue > 0 || PlayerManager.GetInstance._xValue > 0))
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool("isWalking", true);
            _animator.SetBool("isJumping", true);
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
        else if (_playerData.isJumping && PlayerManager.GetInstance._zValue > 0 && !_playerData.isSkateBoarding)
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

            _animator.SetBool("isWalking", true);
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
    void DeathAnimation()
    {
        if (_playerData.isDying)
        {
            _animator.SetBool("isDying", true);
            _animator.SetLayerWeight(7, 1);
            _animator.SetLayerWeight(0, 0);
        }
    }
    void VictoryAnimation()
    {
        if (_playerData.isWinning)
        {
            _animator.SetBool("isWinning", true);
            _animator.SetLayerWeight(8, 1);
            _animator.SetLayerWeight(0, 0);
            //StartCoroutine(DelayAnimation(5f, 8, 0));
        }
    }
    void SkateBoardAnimation()
    {
        if (_playerData.isSkateBoarding && PlayerManager.GetInstance._zValue > 0 && !_playerData.isJumping)
        {
            _animator.SetLayerWeight(9, 1);
            _animator.SetBool("isSkating", true);
        }
        else if (_playerData.isSkateBoarding && PlayerManager.GetInstance._zValue == 0)
        {
            DisableSkateAnimation();
        }
        else if (!_playerData.isSkateBoarding && _playerData.isJumping)
        {
            _animator.SetLayerWeight(9, 1);
            _animator.SetBool("isJumping", true);
        }
        else
        {
            DisableSkateAnimation();
        }        
    }
    void DisableSkateAnimation()
    {
        _playerData.clickTabCount = 0;
        _playerData.isSkateBoarding = false;
        _animator.SetBool("isSkating", false);
        _animator.SetLayerWeight(9, 0);
    }

    void PickupAnimation()
    {
        if (_playerData.isPicking)
        {
            _animator.SetLayerWeight(10, 1);
            _animator.SetBool("isPickup", true);
            StartCoroutine(DelayAnimation(0.5f, 10, 0));
        }
    }
    IEnumerator DelayAnimation(float delayValue, int layerOrder, float weightAmount)
    {
        yield return new WaitForSeconds(delayValue);
        _animator.SetBool("isPickup", false);
        _animator.SetLayerWeight(layerOrder, weightAmount);
        _playerData.isPicking = false;
        PlayerManager.GetInstance._coinObject.SetActive(false);
    }
}