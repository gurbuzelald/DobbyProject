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
        if (playerData.isIdling && !playerData.isWalking && PlayerManager.GetInstance.GetXValue() == 0 && 
            PlayerManager.GetInstance.GetZValue() == 0 && !playerData.isJumping && 
            !playerData.isDying && !playerData.isSwordAnimate && !playerData.isBackWalking)
        {
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), true);

            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);

            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
        }
    }
    public virtual void WalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isWalking &&
            !playerData.isSideWalking &&
            !playerData.isSwordAnimate)
        {
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isSword.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);


            _animator.SetLayerWeight(0, 0);
            _animator.SetLayerWeight(1, 1);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);          
            _animator.SetLayerWeight(7, 0);          

        }
        else if (playerData.isFire || playerData.isBackWalking || playerData.isJumping || 
            playerData.isSwordAnimate || playerData.isSideWalking ||
            playerData.isDying || playerData.isPlayable || playerData.isSideWalking || !playerData.isWalking)
        {
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isSword.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);

            
            _animator.SetLayerWeight(0, 0);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);
            _animator.SetLayerWeight(7, 0);
            _animator.SetLayerWeight(16, 0);
        }
        else
        {
            _animator.SetLayerWeight(1, 0);

            _animator.SetLayerWeight(16, 0);
        }
        BackWalkAnimation(playerData, _animator);
        IdleAnimation(playerData, _animator);
        RightWalkAnimation(playerData, _animator);
        LeftWalkAnimation(playerData, _animator);
    }
    public virtual void BackWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isBackWalking && !playerData.isSwordAnimate &&
            !playerData.isSwordAnimate)
        {
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), true);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetLayerWeight(2, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(4, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);
            _animator.SetLayerWeight(7, 0);
        }
        else
        {
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);

            _animator.SetLayerWeight(2, 0);

        }
    }
    public virtual void LeftWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if ((PlayerManager.GetInstance.GetXValue() < -0.001f) &&
            !playerData.isRunning && !playerData.isSwordAnimate &&
            playerData.isSideWalking && !playerData.isWalking)
        {
            _animator.SetBool(AnimatorParameters.isLeftWalk.ToString(), true);

            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isRightWalk.ToString(), false);

            _animator.SetLayerWeight(5, 1);
            _animator.SetLayerWeight(6, 0);
            _animator.SetLayerWeight(7, 0);

        }
        else if (PlayerManager.GetInstance.GetXValue() >= 0 || 
                 playerData.isJumping ||  
                 playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(5, 0);     
        }
    }
    public virtual void RightWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (PlayerManager.GetInstance.GetXValue() > 0.001f &&
            !playerData.isRunning && !playerData.isSwordAnimate &&
            playerData.isSideWalking && !playerData.isWalking)
        {
            _animator.SetBool(AnimatorParameters.isRightWalk.ToString(), true);
            _animator.SetBool(AnimatorParameters.isLeftWalk.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);

            _animator.SetLayerWeight(6, 1);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(7, 0);

        }
        else if (PlayerManager.GetInstance.GetXValue() <= 0 || 
                !playerData.isJumping || 
                !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(6, 0);
        }
    }

    
    public virtual void FireNonWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isFire && 
            playerData.isPlayable && 
            !playerData.isBackWalking && 
            !playerData.isSwordAnimate && 
            !playerData.isSideWalking)
        {
            _animator.SetBool(AnimatorParameters.isFireWalk.ToString(), false);

            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
        }


        FireAnimation(playerData, _animator);


        FireWalkAnimation(playerData, _animator);
    }

    void FireAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isFire &&
                playerData.isFireAnimation &&
                PlayerManager.GetInstance.GetZValue() == 0 &&
                PlayerManager.GetInstance.GetXValue() == 0 &&
                !playerData.isSwordAnimate &&
                !playerData.isSideWalking &&
                !playerData.isWalking &&
                !playerData.isBackWalking &&
                !playerData.isDying)
        {
            _animator.SetLayerWeight(17, 1);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);

            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
        }
        else if (((!playerData.isFire &&
                !playerData.isFireAnimation) &&
                (PlayerManager.GetInstance.GetZValue() != 0 ||
                PlayerManager.GetInstance.GetXValue() != 0)) ||
                playerData.isDying ||
                PlayerManager.GetInstance.GetXValue() != 0 ||
                PlayerManager.GetInstance.GetZValue() != 0)
        {
            _animator.SetLayerWeight(17, 0);

            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
        }

    }

    void FireWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (!playerData.isJumping &&
                 playerData.isWalking &&
                 playerData.isFire &&
                 !playerData.isSwordAnimate &&
                 playerData.isFireWalkAnimation)
        {
            _animator.SetLayerWeight(16, 1);

            _animator.SetBool(AnimatorParameters.isJumping.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
        }
        else if (!playerData.isFire &&
                 !playerData.isFireWalkAnimation && playerData.isWalking)
        {
            _animator.SetLayerWeight(16, 0);
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
        }
    }
    public virtual void SwordAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isPlayable && 
            playerData.isSwordAnimate)
        {
            _animator.SetBool(AnimatorParameters.isSword.ToString(), true);

            _animator.SetLayerWeight(17, 0);

            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);

            _animator.SetLayerWeight(0, 0);
        }
        else if (!playerData.isFire && 
                 PlayerManager.GetInstance.GetZValue() == 0 && 
                 PlayerManager.GetInstance.GetXValue() == 0 &&
                 !playerData.isSwordAnimate)
        {
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), true);

            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isSword.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);           
        }
    }
    public virtual void JumpAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isJumping && 
            playerData.isGround && 
            (PlayerManager.GetInstance.GetZValue() > 0 || PlayerManager.GetInstance.GetXValue() > 0) && 
            !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), true);
        }
        if (!playerData.isGround && 
            !playerData.isJumping && 
            (PlayerManager.GetInstance.GetZValue() > 0 || PlayerManager.GetInstance.GetZValue() < 0) && 
            !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(13, 1);
        }
        else if (!playerData.isGround && 
                 !playerData.isJumping && 
                 (PlayerManager.GetInstance.GetXValue() > 0) && 
                 !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(14, 1);
        }
        else if (!playerData.isGround && 
                 !playerData.isJumping && 
                 (PlayerManager.GetInstance.GetXValue() < 0) && 
                 !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(15, 1);
        }
        else
        {
            _animator.SetLayerWeight(13, 0);
            _animator.SetLayerWeight(14, 0);
            _animator.SetLayerWeight(15, 0);
        }
        if (playerData.isJumping && 
            PlayerManager.GetInstance.GetZValue() == 0 && 
            !playerData.isSwordAnimate)
        {
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), true);

            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
        }
        else if (playerData.isJumping && 
                 PlayerManager.GetInstance.GetZValue() > 0 && 
                 !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool(AnimatorParameters.isJumping.ToString(), true);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
        }
        else if (!playerData.isJumping && 
                 playerData.isWalking && 
                 !playerData.isFire && 
                 !playerData.isSwordAnimate &&
                 !playerData.isFireWalkAnimation &&
                 !playerData.isFireAnimation)
        {
            _animator.SetLayerWeight(1, 1);

            _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), false);
            _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
        }
        else if (!playerData.isJumping && 
                 !playerData.isWalking && 
                 PlayerManager.GetInstance.GetZValue() == 0 && 
                 PlayerManager.GetInstance.GetXValue() == 0 && 
                 !playerData.isSwordAnimate)
        {
            _animator.SetBool(AnimatorParameters.isJumping.ToString(), false);
            _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);

            _animator.SetLayerWeight(1, 0);
        }
    }
    public virtual void DeathAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isDying)
        {
            _animator.SetBool(AnimatorParameters.isDying.ToString(), true);
            _animator.SetLayerWeight(7, 0);
            _animator.SetLayerWeight(7, 1);
            _animator.SetLayerWeight(0, 0);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
            _animator.SetLayerWeight(3, 0);
            _animator.SetLayerWeight(4, 0);
            _animator.SetLayerWeight(5, 0);
            _animator.SetLayerWeight(6, 0);
            _animator.SetLayerWeight(8, 0);
            _animator.SetLayerWeight(9, 0);
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
    public virtual void RunAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isRunning && 
            !playerData.isJumping && 
            !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(12, 1);
            _animator.SetBool(AnimatorParameters.isRunning.ToString(), true);
        }
        else if (!playerData.isRunning && 
            !playerData.isSwordAnimate)
        {
            DisableRunAnimation(playerData, _animator);
        }
        else if (!playerData.isRunning && 
            playerData.isJumping && 
            !playerData.isSwordAnimate)
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
        if (playerData.isPicking && 
            !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(10, 1);
            _animator.SetBool(AnimatorParameters.isPickup.ToString(), true);
            StartCoroutine(DelayAnimation(playerData, _animator, 0.5f, 10, 0));
        }
    }
    public virtual void PickRotateAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData.isPickRotateCoin && 
            !playerData.isSwordAnimate)
        {
            _animator.SetLayerWeight(11, 1);
            _animator.SetBool(AnimatorParameters.isPickRotateCoin.ToString(), true);
            StartCoroutine(DelayAnimation(playerData, _animator, 0.5f, 11, 0));
        }
    }
    public virtual IEnumerator DelayAnimation(PlayerData playerData, Animator _animator, float delayValue, int layerOrder, float weightAmount)
    {
        yield return new WaitForSeconds(delayValue);
        _animator.SetBool(AnimatorParameters.isPickup.ToString(), false);
        _animator.SetBool(AnimatorParameters.isPickRotateCoin.ToString(), false);
        _animator.SetLayerWeight(layerOrder, weightAmount);
        playerData.isPicking = false;
        playerData.isPickRotateCoin = false;
    }
    public enum AnimatorParameters
    {
        isIdling,
        isWalking,
        isBackWalking,
        isLeftWalk,
        isRightWalk,
        isLeftWalking,
        isRightWalking,
        isFiring,
        isJumping,
        isDying,
        isWinning,
        isPickup,
        isPickRotateCoin,
        isRunning,
        isSword,
        isFireWalk
    }
}
