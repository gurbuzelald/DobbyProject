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
            if (PlayerData.isDying) return;

            if (PlayerData.isIdling && !PlayerData.isWalking && PlayerManager.GetXAndZValue().x == 0 &&
            PlayerManager.GetXAndZValue().z == 0 && !PlayerData.isJumping &&
            !PlayerData.isDying && !PlayerData.isSwordAnimate && !PlayerData.isBackWalking)
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
            if (PlayerData.isDying) return;

            if (PlayerData.isWalking &&
            !PlayerData.isSideWalking &&
            !PlayerData.isSwordAnimate)
            {
                _animator.SetBool(AnimatorParameters.isWalking.ToString(), true);

                _animator.SetLayerWeight(1, 1);

                _animator.SetLayerWeight(5, 0);
                _animator.SetLayerWeight(6, 0);

            }
            else if (PlayerData.isFire || PlayerData.isBackWalking || PlayerData.isJumping ||
                PlayerData.isSwordAnimate || PlayerData.isSideWalking ||
                PlayerData.isDying || PlayerData.isPlayable || PlayerData.isSideWalking || !PlayerData.isWalking)
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
            if (PlayerData.isDying) return;

            if (PlayerData.isBackWalking &&
                !PlayerData.isSwordAnimate &&
                !PlayerData.isSwordAnimate)
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
            if (PlayerData.isDying) return;

            if (!PlayerData.isRunning &&
                !PlayerData.isSwordAnimate &&
                 PlayerData.isSideWalking &&
                 PlayerManager.GetXAndZValue().x < 0)
            {
                _animator.SetBool(AnimatorParameters.isLeftWalk.ToString(), true);

                _animator.SetLayerWeight(5, 1);

            }
            else if (!PlayerData.isSideWalking ||
                    PlayerData.isJumping ||
                     PlayerData.isSwordAnimate ||
                     PlayerManager.GetXAndZValue().x >= 0)
            {
                _animator.SetLayerWeight(5, 0);
            }
        }
    }
    void RightWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (PlayerData.isDying) return;

            if (!PlayerData.isRunning &&
                !PlayerData.isSwordAnimate &&
                PlayerData.isSideWalking &&
                PlayerManager.GetXAndZValue().x > 0)
            {
                _animator.SetBool(AnimatorParameters.isRightWalk.ToString(), true);

                _animator.SetLayerWeight(6, 1);

            }
            else if (!PlayerData.isSideWalking ||
                    !PlayerData.isJumping ||
                    !PlayerData.isSwordAnimate ||
                    PlayerManager.GetXAndZValue().x <= 0)
            {
                _animator.SetLayerWeight(6, 0);
            }
        }
    }
    void FireNonWalkAnimation(PlayerData playerData, Animator _animator)
    {
        if (playerData)
        {
            if (PlayerData.isDying) return;

            if (PlayerData.isFire &&
            PlayerData.isPlayable &&
            !PlayerData.isBackWalking &&
            !PlayerData.isSwordAnimate &&
            !PlayerData.isSideWalking)
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
            if (PlayerData.isDying && !PlayerData.isWinning)
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
            if (PlayerData.isDying) return;

            if (PlayerData.isPlayable &&
            PlayerData.isSwordAnimate)
            {
                _animator.SetBool(AnimatorParameters.isSword.ToString(), true);

                _animator.SetLayerWeight(17, 0);

                _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);

                _animator.SetLayerWeight(0, 0);
            }
            else if (!PlayerData.isFire &&
                     PlayerManager.GetXAndZValue().z == 0 &&
                     PlayerManager.GetXAndZValue().x == 0 &&
                     !PlayerData.isSwordAnimate)
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
            if (PlayerData.isDying) return;

            float xValue = PlayerManager.GetXAndZValue().x;
            float zValue = PlayerManager.GetXAndZValue().z;

            bool isMoving = xValue != 0 || zValue != 0;
            bool isGrounded = PlayerData.isGround;
            bool isJumping = PlayerData.isJumping;
            bool isSwordAnimate = PlayerData.isSwordAnimate;
            bool isDying = PlayerData.isDying;

            // Zemin üzerinde zıplama ve hareket etme durumu
            if (isJumping && isGrounded && isMoving && !isSwordAnimate && !isDying)
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
            else if (!isJumping && PlayerData.isWalking && !PlayerData.isFire && !isSwordAnimate &&
                     !PlayerData.isFireWalkAnimation && !PlayerData.isFireAnimation)
            {
                SetAnimatorLayer(_animator, 1, true);
                SetAnimatorParameters(_animator, true, false, false, false, false);
            }
            // Durağan duruma geçiş
            else if (!isJumping && !PlayerData.isWalking && zValue == 0 && xValue == 0 && !isSwordAnimate)
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
            if (PlayerData.isWinning && !PlayerData.isDying)
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
            if (PlayerData.isRunning &&
                !PlayerData.isJumping &&
                !PlayerData.isSwordAnimate)
            {
                _animator.SetLayerWeight(12, 1);
                _animator.SetBool(AnimatorParameters.isRunning.ToString(), true);
            }
            else if (!PlayerData.isRunning &&
                !PlayerData.isSwordAnimate)
            {
                DisableRunAnimation(playerData, _animator);
            }
            else if (!PlayerData.isRunning &&
                PlayerData.isJumping &&
                !PlayerData.isSwordAnimate)
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
            if (PlayerData.isPicking &&
            !PlayerData.isSwordAnimate)
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
            if (PlayerData.isPickRotateCoin &&
            !PlayerData.isSwordAnimate)
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
            if (PlayerData.isDying) return;

            if (PlayerData.isFire &&
                PlayerData.isFireAnimation &&
                PlayerManager.GetXAndZValue().z == 0 &&
                PlayerManager.GetXAndZValue().x == 0 &&
                !PlayerData.isSwordAnimate &&
                !PlayerData.isSideWalking &&
                !PlayerData.isWalking &&
                !PlayerData.isBackWalking &&
                !PlayerData.isDying)
            {
                _animator.SetLayerWeight(17, 1);
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);

                _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
                _animator.SetBool(AnimatorParameters.isWalking.ToString(), false);
            }
            else if (((!PlayerData.isFire &&
                    !PlayerData.isFireAnimation) &&
                    (PlayerManager.GetXAndZValue().z != 0 ||
                    PlayerManager.GetXAndZValue().x != 0)) ||
                    PlayerData.isDying ||
                    PlayerManager.GetXAndZValue().x != 0 ||
                    PlayerManager.GetXAndZValue().z != 0)
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
            if (PlayerData.isDying) return;

            if (!PlayerData.isJumping &&
                 PlayerData.isWalking &&
                 PlayerData.isFire &&
                 !PlayerData.isSwordAnimate &&
                 PlayerData.isFireWalkAnimation)
            {
                _animator.SetLayerWeight(16, 1);

                _animator.SetBool(AnimatorParameters.isJumping.ToString(), false);
                _animator.SetBool(AnimatorParameters.isIdling.ToString(), false);
                _animator.SetBool(AnimatorParameters.isFiring.ToString(), false);
                _animator.SetBool(AnimatorParameters.isBackWalking.ToString(), false);
            }
            else if ((!PlayerData.isFire ||
                     !PlayerData.isFireWalkAnimation) && PlayerData.isWalking)
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
            PlayerData.clickShiftCount = 0;
            PlayerData.isRunning = false;
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
            PlayerData.isPicking = false;
            PlayerData.isPickRotateCoin = false;
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
