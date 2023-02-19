using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPlayerAnimation<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }
            return _instance;
        }

    }
    public virtual void IdleAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isIdling && PlayerManager.GetInstance._xValue == 0 && PlayerManager.GetInstance._zValue == 0 && !playerData.isJumping && !playerData.isDying)
        {
            if (!playerData.isLockedWalking)
            {
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), true);

                _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);

                _animator.SetLayerWeight(0, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
            }            
        }
        if (!playerData.isBackWalking && !playerData.isWalking && !playerData.isClimbing && !playerData.isJumping && !playerData.isLockedWalking)
        {
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), true);

            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
        }
    }
    public virtual void WalkAnimation(PlayerData playerData, Animator _animator)
    {
        if ((playerData.isLockedWalking) || (playerData.isWalking && !playerData.isBackWalking && !playerData.isJumping && !playerData.isClimbing))
        {
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
            _animator.SetBool(AnimatorParameters.isSword.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);


            _animator.SetLayerWeight(0, 0);
            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);

            //Debug.Log(_animator.GetLayerIndex("Walking"));
        }
        BackWalkAnimation(playerData, _animator);
        IdleAnimation(playerData, _animator);
        RightWalkAnimation(playerData, _animator);
        LeftWalkAnimation(playerData, _animator);
    }
    public virtual void SlaveWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if ((playerData.isLockedWalking || playerData.isWalking) && playerData.isPlayable)
        {
            _animator.SetLayerWeight(0, 0);
            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);

        }
        else
        {
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
        }
    }
    public virtual void BackWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isBackWalking && !playerData.isWalking && !playerData.isJumping && !playerData.isBackClimbing && !playerData.isLockedWalking)
        {
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), true);

            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);

            _animator.SetLayerWeight(2, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(4, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);
        }
    }
    public virtual void SlaveBackWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isBackWalking && !playerData.isWalking && !playerData.isJumping && !playerData.isBackClimbing && !playerData.isLockedWalking)
        {
            _animator.SetLayerWeight(2, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(4, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);
        }
    }
    public virtual void LeftWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (PlayerManager.GetInstance._xValue < -0.03f && PlayerManager.GetInstance._zValue > -0.05f && PlayerManager.GetInstance._zValue < 0.05f)
        {
            _animator.SetBool(AnimatorParameters.isLeftWalk.ToString(), true);

            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
            _animator.SetBool(AnimatorParameters.isRightWalk.ToString(), false);

            _animator.SetLayerWeight(5, 1);
            _animator.SetLayerWeight(6, 0);

        }
        else if (PlayerManager.GetInstance._xValue == 0 && !playerData.isJumping)
        {
            if (!playerData.isLockedWalking)
            {
                _animator.SetLayerWeight(5, 0);
                _animator.SetLayerWeight(6, 0);
                _animator.SetLayerWeight(0, 1);
            }            
        }
    }
    public virtual void RightWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (PlayerManager.GetInstance._xValue > 0.03f && PlayerManager.GetInstance._zValue < 0.05f && PlayerManager.GetInstance._zValue > -0.05f)
        {
            _animator.SetBool(AnimatorParameters.isRightWalk.ToString(), true);

            _animator.SetBool(AnimatorParameters.isLeftWalk.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);

            _animator.SetLayerWeight(6, 1);
            _animator.SetLayerWeight(5, 0);

        }
        else if (PlayerManager.GetInstance._xValue == 0 && !playerData.isJumping)
        {
            if (!playerData.isLockedWalking)
            {
                _animator.SetLayerWeight(6, 0);
                _animator.SetLayerWeight(5, 0);
                _animator.SetLayerWeight(0, 1);
            }            
        }
    }

    public virtual void ClimbAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isClimbing && !playerData.isBackClimbing && PlayerManager.GetInstance._zValue > 0)
        {
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);

            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), true);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 1);
        }
        if (!playerData.isClimbing && playerData.isBackClimbing && PlayerManager.GetInstance._zValue < 0)
        {
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);

            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), true);

            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(4, 1);
        }
        if ((playerData.isClimbing || !playerData.isClimbing) && PlayerManager.GetInstance._zValue == 0 && !playerData.isFiring && !playerData.isJumping)
        {
            if (!playerData.isLockedWalking)
            {
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), true);

                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), false);

                _animator.SetLayerWeight(0, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }            
        }
    }
    public virtual void FireAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isFiring && !playerData.isSwording && !playerData.isWalking && !playerData.isBackWalking && !playerData.isClimbing && playerData.isPlayable)
        {            
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), true);

            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), false);
        }
        else if (!playerData.isFiring && !playerData.isSwording && PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0 && !playerData.isClimbing)
        {
            if (!playerData.isLockedWalking)
            {
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), true);

                _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), false);
            }            
        }
    }
    public virtual void SlaveFireAnimation(Animator _animator)
    {
        _animator.SetLayerWeight(3, 1);
    }
    public virtual void SwordAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isSwording && !playerData.isFiring && !playerData.isWalking && !playerData.isBackWalking && !playerData.isClimbing && playerData.isPlayable)
        {
            _animator.SetBool(AnimatorParameters.isSword.ToString(), true);

            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), false);
        }
        else if (!playerData.isSwording && !playerData.isFiring && PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0 && !playerData.isClimbing)
        {
            if (!playerData.isLockedWalking)
            {
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), true);

                _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
                _animator.SetBool(AnimatorParameters.isSword.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), false);
            }
        }
    }
    public virtual void JumpAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isJumping && playerData.isGround && !playerData.isSkateBoarding && (PlayerManager.GetInstance._zValue > 0 || PlayerManager.GetInstance._xValue > 0))
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), true);
        }
        if (playerData.isJumping && PlayerManager.GetInstance._zValue == 0)
        {
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), true);

            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), false);
        }
        else if (playerData.isJumping && PlayerManager.GetInstance._zValue > 0 && !playerData.isSkateBoarding)
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool(AnimatorParameters.isJumping.ToString(), true);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), false);
        }
        else if (!playerData.isJumping && PlayerManager.GetInstance._zValue > 0)
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isClimbing.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackClimbing.ToString(), false);
        }
        else if (!playerData.isJumping && !playerData.isWalking && PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0)
        {
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);

            _animator.SetLayerWeight(1, 0);
        }
    }
    public virtual void DeathAnimation(PlayerData playerData, Animator _animator, PlayerData cloneData)
    {
        if (playerData.isDying)
        {
            _animator.SetBool(AnimatorParameters.isDying.ToString(), true);
            _animator.SetLayerWeight(7, 1);
            _animator.SetLayerWeight(0, 0);
        }
    }
    public virtual void VictoryAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isWinning)
        {
            _animator.SetBool(AnimatorParameters.isWinning.ToString(), true);
            _animator.SetLayerWeight(8, 1);
            _animator.SetLayerWeight(0, 0);
            //StartCoroutine(DelayAnimation(playerData, _animator, 3f, 8, 0));
        }
    }
    public virtual void SkateBoardAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isSkateBoarding && PlayerManager.GetInstance._zValue > 0 && !playerData.isJumping && !playerData.isRunning)
        {
            _animator.SetLayerWeight(9, 1);
            _animator.SetBool(AnimatorParameters.isSkating.ToString(), true);
        }
        else if (playerData.isSkateBoarding && PlayerManager.GetInstance._zValue == 0)
        {
            DisableSkateAnimation(playerData, _animator);
        }
        else if (!playerData.isSkateBoarding && playerData.isJumping)
        {
            _animator.SetLayerWeight(9, 1);
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), true);
        }
        else
        {
            DisableSkateAnimation(playerData, _animator);
        }
    }
    public virtual void DisableSkateAnimation(PlayerData playerData, Animator _animator)
    {
        playerData.clickTabCount = 0;
        playerData.isSkateBoarding = false;
        _animator.SetBool(AnimatorParameters.isSkating.ToString(), false);
        _animator.SetLayerWeight(9, 0);
    }
    public virtual void RunAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isRunning && PlayerManager.GetInstance._zValue > 0 && !playerData.isJumping)
        {
            _animator.SetLayerWeight(12, 1);
            _animator.SetBool(AnimatorParameters.isRunning.ToString(), true);
        }
        else if (playerData.isRunning && PlayerManager.GetInstance._zValue == 0)
        {
            DisableRunAnimation(playerData, _animator);
        }
        else if (!playerData.isRunning && playerData.isJumping)
        {
            _animator.SetLayerWeight(12, 1);
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), true);
        }
        else
        {
            DisableRunAnimation(playerData, _animator);
        }
    }
    public virtual void DisableRunAnimation(PlayerData playerData, Animator _animator)
    {
        playerData.clickShiftCount = 0;
        playerData.isRunning = false;
        _animator.SetBool(AnimatorParameters.isRunning.ToString(), false);
        _animator.SetLayerWeight(12, 0);
    }

    public virtual void PickupAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isPicking)
        {
            _animator.SetLayerWeight(10, 1);
            _animator.SetBool(AnimatorParameters.isPickup.ToString(), true);
            StartCoroutine(DelayAnimation(playerData, _animator, 0.5f, 10, 0));
        }
    }
    public virtual void PickRotateAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isPickRotateCoin)
        {
            _animator.SetLayerWeight(11, 1);
            _animator.SetBool(AnimatorParameters.isPickRotateCoin.ToString(), true);
            StartCoroutine(DelayAnimation(playerData, _animator, 0.5f, 11, 0));
        }
    }
    public virtual IEnumerator DelayAnimation(PlayerData playerData, Animator _animator, float delayValue, int layerOrder, float weightAmount)
    {
        yield return new WaitForSeconds(delayValue);
        playerData.playerSpeed = 2f;
        _animator.SetBool(AnimatorParameters.isPickup.ToString(), false);
        _animator.SetBool(AnimatorParameters.isPickRotateCoin.ToString(), false);
        _animator.SetLayerWeight(layerOrder, weightAmount);
        playerData.isPicking = false;
        playerData.isPickRotateCoin = false;
        PlayerManager.GetInstance._coinObject.SetActive(false);
        PlayerManager.GetInstance._cheeseObject.SetActive(false);
    }
    public enum AnimatorParameters
    {
        isIdling,
        isWalking,
        isBackWalking,
        isLeftWalk,
        isRightWalk,
        isClimbing,
        isBackClimbing,
        isLeftWalking,
        isRightWalking,
        isFiring,
        isJumping,
        isDying,
        isWinning,
        isSkating,
        isPickup,
        isPickRotateCoin,
        isRunning,
        isSword
    }
}
