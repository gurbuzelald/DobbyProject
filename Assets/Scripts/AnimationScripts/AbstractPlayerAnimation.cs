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

    public virtual void UpdateAnimations(PlayerData playerData, Animator _animator)
    {
        IdleAnimation(playerData,  _animator);
        WalkAnimation(playerData,  _animator);
        BackWalkAnimation(playerData,  _animator);
        LeftWalkAnimation(playerData,  _animator);
        RightWalkAnimation(playerData,  _animator);
        FireNonWalkAnimation(playerData,  _animator);
        DeathAnimation(playerData,  _animator);
        SwordAnimation(playerData,  _animator);
        JumpAnimation(playerData,  _animator);
        VictoryAnimation(playerData,  _animator);
        RunAnimation(playerData,  _animator);
        PickupAnimation(playerData,  _animator);
        PickRotateAnimation(playerData,  _animator);
        PickupAnimation(playerData,  _animator);
    }

    public virtual void StartAnimations(PlayerData playerData, Animator _animator)
    {
        _animator.SetLayerWeight(0, 1);
        _animator.SetLayerWeight(1, 0);
        _animator.SetLayerWeight(2, 0);
        _animator.SetLayerWeight(3, 0);
        _animator.SetLayerWeight(4, 0);
        _animator.SetLayerWeight(5, 0);
        _animator.SetLayerWeight(6, 0);
        _animator.SetLayerWeight(8, 0);
        _animator.SetLayerWeight(9, 0);
        _animator.SetLayerWeight(10, 0);
        _animator.SetLayerWeight(11, 0);
        _animator.SetLayerWeight(12, 0);
        _animator.SetLayerWeight(13, 0);
        _animator.SetLayerWeight(14, 0);
        _animator.SetLayerWeight(15, 0);
        _animator.SetLayerWeight(16, 0);
        _animator.SetLayerWeight(17, 0);
    }
    void IdleAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

            if (playerData.isIdling && !playerData.isWalking && PlayerManager.GetInstance.GetXValue() == 0 &&
            PlayerManager.GetInstance.GetZValue() == 0 && !playerData.isJumping &&
            !playerData.isDying && !playerData.isSwordAnimate && !playerData.isBackWalking)
            {
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), true);

                _animator.SetLayerWeight(0, 1);
            }
        }
    }
    void WalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

            if (playerData.isWalking &&
            !playerData.isSideWalking &&
            !playerData.isSwordAnimate)
            {
                _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);

                _animator.SetLayerWeight(1, 1);

                _animator.SetLayerWeight(5, 0);
                _animator.SetLayerWeight(6, 0);

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
        }
    }
    void BackWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

            if (playerData.isBackWalking && !playerData.isSwordAnimate &&
            !playerData.isSwordAnimate)
            {
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), true);

                _animator.SetLayerWeight(2, 1);
            }
            else
            {
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);

                _animator.SetLayerWeight(2, 0);

            }
        }
    }
    void LeftWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

            if ((PlayerManager.GetInstance.GetXValue() < -0.001f) &&
           !playerData.isRunning && !playerData.isSwordAnimate &&
           playerData.isSideWalking && !playerData.isWalking)
            {
                _animator.SetBool(AnimatorParameters.isLeftWalk.ToString(), true);

                _animator.SetLayerWeight(5, 1);

            }
            else if (PlayerManager.GetInstance.GetXValue() >= 0 ||
                     playerData.isJumping ||
                     playerData.isSwordAnimate)
            {
                _animator.SetLayerWeight(5, 0);
            }
        }
    }
    void RightWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

            if (PlayerManager.GetInstance.GetXValue() > 0.001f &&
            !playerData.isRunning && !playerData.isSwordAnimate &&
            playerData.isSideWalking && !playerData.isWalking)
            {
                _animator.SetBool(AnimatorParameters.isRightWalk.ToString(), true);

                _animator.SetLayerWeight(6, 1);

            }
            else if (PlayerManager.GetInstance.GetXValue() <= 0 ||
                    !playerData.isJumping ||
                    !playerData.isSwordAnimate)
            {
                _animator.SetLayerWeight(6, 0);
            }
        }
    }
    void FireNonWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

            if (playerData.isFire &&
            playerData.isPlayable &&
            !playerData.isBackWalking &&
            !playerData.isSwordAnimate &&
            !playerData.isSideWalking)
            {
                //_animator.SetBool(AnimatorParameters.isFireWalk.ToString(), false);

                _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
            }
        }
        FireAnimation(playerData, _animator);


        FireWalkAnimation(playerData, _animator);
    }

    void DeathAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying && !playerData.isWinning)
            {
                _animator.SetBool(AnimatorParameters.isDying.ToString(), true);
                _animator.SetLayerWeight(7, 1);
            }
        }
    }
    void SwordAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

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
    }
    void JumpAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

            float xValue = PlayerManager.GetInstance.GetXValue();
            float zValue = PlayerManager.GetInstance.GetZValue();

            bool isMoving = xValue != 0 || zValue != 0;
            bool isGrounded = playerData.isGround;
            bool isJumping = playerData.isJumping;
            bool isSwordAnimate = playerData.isSwordAnimate;

            // Zemin üzerinde zıplama ve hareket etme durumu
            if (isJumping && isGrounded && isMoving && !isSwordAnimate)
            {
                SetAnimatorLayer(_animator, 1, true);
                SetAnimatorParameters(_animator, false, true, false, false, false);
            }
            // Havada hareket etme durumu
            else if (!isGrounded && !isJumping && zValue != 0 && !isSwordAnimate)
            {
                SetAnimatorLayer(_animator, 13, true);
            }
            else if (!isGrounded && !isJumping && xValue > 0 && !isSwordAnimate)
            {
                SetAnimatorLayer(_animator, 14, true);
            }
            else if (!isGrounded && !isJumping && xValue < 0 && !isSwordAnimate)
            {
                SetAnimatorLayer(_animator, 15, true);
            }
            else
            {
                SetAnimatorLayer(_animator, 13, false);
                SetAnimatorLayer(_animator, 14, false);
                SetAnimatorLayer(_animator, 15, false);
            }

            // Zıplama durumu
            if (isJumping && zValue == 0 && !isSwordAnimate)
            {
                SetAnimatorParameters(_animator, false, true, false, false, false);
            }
            else if (isJumping && zValue > 0 && !isSwordAnimate)
            {
                SetAnimatorLayer(_animator, 1, true);
                SetAnimatorParameters(_animator, false, true, false, false, false);
            }
            // Yürüyüş durumu
            else if (!isJumping && playerData.isWalking && !playerData.isFire && !isSwordAnimate &&
                     !playerData.isFireWalkAnimation && !playerData.isFireAnimation)
            {
                SetAnimatorLayer(_animator, 1, true);
                SetAnimatorParameters(_animator, true, false, false, false, false);
            }
            // Durağan duruma geçiş
            else if (!isJumping && !playerData.isWalking && zValue == 0 && xValue == 0 && !isSwordAnimate)
            {
                SetAnimatorParameters(_animator, false, false, false, false, false);
                SetAnimatorLayer(_animator, 1, false);
            }
        }
    }
    void VictoryAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isWinning && !playerData.isDying)
            {
                _animator.SetBool(AnimatorParameters.isWinning.ToString(), true);
                _animator.SetLayerWeight(8, 1);
                _animator.SetLayerWeight(0, 0);
                //StartCoroutine(DelayAnimation(playerData, _animator, 3f, 8, 0));
            }
        }
    }
    void RunAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
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
    }

    

    void PickupAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isPicking &&
            !playerData.isSwordAnimate)
            {
                _animator.SetLayerWeight(10, 1);
                _animator.SetBool(AnimatorParameters.isPickup.ToString(), true);
                StartCoroutine(DelayAnimation(playerData, _animator, 0.5f, 10, 0));
            }
        }
    }
    void PickRotateAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isPickRotateCoin &&
            !playerData.isSwordAnimate)
            {
                _animator.SetLayerWeight(11, 1);
                _animator.SetBool(AnimatorParameters.isPickRotateCoin.ToString(), true);
                StartCoroutine(DelayAnimation(playerData, _animator, 0.5f, 11, 0));
            }
        }
    }

    void FireAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

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
    }

    void FireWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (playerData.isDying) return;

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
            else if ((!playerData.isFire ||
                     !playerData.isFireWalkAnimation) && playerData.isWalking)
            {
                _animator.SetLayerWeight(16, 0);
                _animator.SetLayerWeight(1, 1);

                _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);
                _animator.SetBool(AnimatorParameters.isJumping.ToString(), false);
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
                _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            }
            else
            {
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(16, 0);
                _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
            }
        }
    }



    //Helper
    void DisableRunAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            playerData.clickShiftCount = 0;
            playerData.isRunning = false;
            _animator.SetBool(AnimatorParameters.isRunning.ToString(), false);
            _animator.SetLayerWeight(12, 0);
        }
    }

    // Helper
    void SetAnimatorParameters(Animator _animator, bool isWalking, bool isJumping, bool isIdling, bool isFiring, bool isBackWalking)
    {
        _animator.SetBool(AnimatorParameters.isWalking.ToString(), isWalking);
        _animator.SetBool(AnimatorParameters.isJumping.ToString(), isJumping);
        _animator.SetBool(AnimatorParameters.isIdling.ToString(), isIdling);
        _animator.SetBool(AnimatorParameters.isFiring.ToString(), isFiring);
        _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), isBackWalking);
    }

    // Helper
    void SetAnimatorLayer(Animator _animator, int layerIndex, bool state)
    {
        _animator.SetLayerWeight(layerIndex, state ? 1 : 0);
    }

    //Helper
    IEnumerator DelayAnimation(PlayerData playerData, Animator _animator, float delayValue, int layerOrder, float weightAmount)
    {
        if (playerData)
        {
            yield return new WaitForSeconds(delayValue);
            _animator.SetBool(AnimatorParameters.isPickup.ToString(), false);
            _animator.SetBool(AnimatorParameters.isPickRotateCoin.ToString(), false);
            _animator.SetLayerWeight(layerOrder, weightAmount);
            playerData.isPicking = false;
            playerData.isPickRotateCoin = false;
        }
    }

    //Helper
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
