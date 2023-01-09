using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayerAnimation<T> : MonoBehaviour where T : MonoBehaviour
{
    public void IdleAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isIdling && PlayerManager.GetInstance._xValue == 0 && PlayerManager.GetInstance._zValue == 0 && !playerData.isJumping && !playerData.isDying)
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
    public void WalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isWalking && !playerData.isBackWalking && !playerData.isJumping && !playerData.isClimbing)
        {
            _animator.SetBool("isWalking", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);
        }
        else if (playerData.isBackWalking && !playerData.isWalking && !playerData.isJumping && !playerData.isBackClimbing)
        {
            _animator.SetBool("isBackWalking", true);

            _animator.SetBool("isWalking", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(2, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(4, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);
        }
        else if (!playerData.isBackWalking && !playerData.isWalking && !playerData.isClimbing && !playerData.isJumping)
        {
            _animator.SetBool("isIdling", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
        }
        RightWalkAnimation(playerData, _animator);
        LeftWalkAnimation(playerData, _animator);
    }
    public void LeftWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (PlayerManager.GetInstance._xValue < -0.03f && PlayerManager.GetInstance._zValue > -0.05f && PlayerManager.GetInstance._zValue < 0.05f)
        {
            _animator.SetBool("isLeftWalk", true);

            _animator.SetBool("isIdling", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isRightWalk", false);

            _animator.SetLayerWeight(5, 1);
            _animator.SetLayerWeight(6, 0);

        }
        else if (PlayerManager.GetInstance._xValue == 0 && !playerData.isJumping)
        {
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);
            _animator.SetLayerWeight(0, 1);
        }


    }
    public void RightWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (PlayerManager.GetInstance._xValue > 0.03f && PlayerManager.GetInstance._zValue < 0.05f && PlayerManager.GetInstance._zValue > -0.05f)
        {
            _animator.SetBool("isRightWalk", true);

            _animator.SetBool("isLeftWalk", false);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);

            _animator.SetLayerWeight(6, 1);
            _animator.SetLayerWeight(5, 0);

        }
        else if (PlayerManager.GetInstance._xValue == 0 && !playerData.isJumping)
        {
            _animator.SetLayerWeight(6, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(0, 1);
        }
    }

    public void ClimbAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isClimbing && !playerData.isBackClimbing && PlayerManager.GetInstance._zValue > 0)
        {
            _animator.SetBool("isIdling", false);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", true);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 1);
        }
        if (!playerData.isClimbing && playerData.isBackClimbing && PlayerManager.GetInstance._zValue < 0)
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
        if ((playerData.isClimbing || !playerData.isClimbing) && PlayerManager.GetInstance._zValue == 0 && !playerData.isFiring && !playerData.isJumping)
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
    public void FireAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isFiring && !playerData.isWalking && !playerData.isBackWalking && !playerData.isClimbing && playerData.isPlayable)
        {
            _animator.SetBool("isFiring", true);

            _animator.SetBool("isIdling", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
        else if (!playerData.isFiring && PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0 && !playerData.isClimbing)
        {
            _animator.SetBool("isIdling", true);

            _animator.SetBool("isFiring", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
    }
    public void JumpAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isJumping && playerData.isGround && !playerData.isSkateBoarding && (PlayerManager.GetInstance._zValue > 0 || PlayerManager.GetInstance._xValue > 0))
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool("isWalking", true);
            _animator.SetBool("isJumping", true);
        }
        if (playerData.isJumping && PlayerManager.GetInstance._zValue == 0)
        {
            _animator.SetBool("isJumping", true);

            _animator.SetBool("isIdling", false);
            _animator.SetBool("isFiring", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
        else if (playerData.isJumping && PlayerManager.GetInstance._zValue > 0 && !playerData.isSkateBoarding)
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool("isJumping", true);
            _animator.SetBool("isIdling", false);
            _animator.SetBool("isFiring", false);
            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isClimbing", false);
            _animator.SetBool("isBackClimbing", false);
        }
        else if (!playerData.isJumping && PlayerManager.GetInstance._zValue > 0)
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
        else if (!playerData.isJumping && !playerData.isWalking && PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0)
        {
            _animator.SetBool("isJumping", false);
            _animator.SetBool("isWalking", false);

            _animator.SetLayerWeight(1, 0);
        }
    }
    public void DeathAnimation(PlayerData playerData, Animator _animator, PlayerData cloneData)
    {
        if (playerData.isDying || !cloneData.isTouchMain && !cloneData.isTouchFirst)
        {
            _animator.SetBool("isDying", true);
            _animator.SetLayerWeight(7, 1);
            _animator.SetLayerWeight(0, 0);
        }
    }
    public void VictoryAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isWinning)
        {
            _animator.SetBool("isWinning", true);
            _animator.SetLayerWeight(8, 1);
            _animator.SetLayerWeight(0, 0);
            //StartCoroutine(DelayAnimation(5f, 8, 0));
        }
    }
    public void SkateBoardAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isSkateBoarding && PlayerManager.GetInstance._zValue > 0 && !playerData.isJumping && !playerData.isRunning)
        {
            _animator.SetLayerWeight(9, 1);
            _animator.SetBool("isSkating", true);
        }
        else if (playerData.isSkateBoarding && PlayerManager.GetInstance._zValue == 0)
        {
            DisableSkateAnimation(playerData, _animator);
        }
        else if (!playerData.isSkateBoarding && playerData.isJumping)
        {
            _animator.SetLayerWeight(9, 1);
            _animator.SetBool("isJumping", true);
        }
        else
        {
            DisableSkateAnimation(playerData, _animator);
        }
    }
    public void DisableSkateAnimation(PlayerData playerData, Animator _animator)
    {
        playerData.clickTabCount = 0;
        playerData.isSkateBoarding = false;
        _animator.SetBool("isSkating", false);
        _animator.SetLayerWeight(9, 0);
    }
    public void RunAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isRunning && PlayerManager.GetInstance._zValue > 0 && !playerData.isJumping)
        {
            _animator.SetLayerWeight(12, 1);
            _animator.SetBool("isRunning", true);
        }
        else if (playerData.isRunning && PlayerManager.GetInstance._zValue == 0)
        {
            DisableRunAnimation(playerData, _animator);
        }
        else if (!playerData.isRunning && playerData.isJumping)
        {
            _animator.SetLayerWeight(12, 1);
            _animator.SetBool("isJumping", true);
        }
        else
        {
            DisableRunAnimation(playerData, _animator);
        }
    }
    public void DisableRunAnimation(PlayerData playerData, Animator _animator)
    {
        playerData.clickShiftCount = 0;
        playerData.isRunning = false;
        _animator.SetBool("isRunning", false);
        _animator.SetLayerWeight(12, 0);
    }

    public void PickupAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isPicking)
        {
            _animator.SetLayerWeight(10, 1);
            _animator.SetBool("isPickup", true);
            StartCoroutine(DelayAnimation(playerData, _animator, 0.5f, 10, 0));
        }
    }
    public void PickRotateAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isPickRotateCoin)
        {
            _animator.SetLayerWeight(11, 1);
            _animator.SetBool("isPickRotateCoin", true);
            StartCoroutine(DelayAnimation(playerData, _animator, 0.5f, 11, 0));
        }
    }
    public  IEnumerator DelayAnimation(PlayerData playerData, Animator _animator, float delayValue, int layerOrder, float weightAmount)
    {
        yield return new WaitForSeconds(delayValue);
        playerData.playerSpeed = 2f;
        _animator.SetBool("isPickup", false);
        _animator.SetBool("isPickRotateCoin", false);
        _animator.SetLayerWeight(layerOrder, weightAmount);
        playerData.isPicking = false;
        playerData.isPickRotateCoin = false;
        PlayerManager.GetInstance._coinObject.SetActive(false);
    }
}
