using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneAnimationController : MonoBehaviour
{
    private Animator _animator;
    public static bool isWalking;
    public static bool isDying;
    private int _animationCount;
    void Start()
    {
        isDying = false;
        isWalking = true;
        _animationCount = 0;
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationState();
    }
    public void AnimationState()
    {
        if (!PlayerManager.isDestroyed)
        {
            if (isWalking)
            {
                _animator.SetBool("isWalking", true);
                //_animator.SetBool("isIdling", false);

                _animator.SetLayerWeight(1, 1);
            }
            else if (isDying)
            {
                _animator.SetBool("isDying", true);
                //_animator.SetBool("isIdling", false);

                _animator.SetLayerWeight(2, 1);
            }
            else
            {
                _animator.SetBool("isIdling", true);
                //_animator.SetBool("isWalking", false);

                _animator.SetLayerWeight(0, 1);
                _animator.SetLayerWeight(1, 0);
            }
        }
        else
        {
            _animationCount++;
            if (_animationCount == 0)
            {
                _animator.SetBool("isIdling", true);
            }
            //_animator.SetBool("isWalking", false);

            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
        }
    }
}

