using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator _animator;
    public EnemyData _enemyData;
    //public static bool isWalking;
    //public static bool isDying;
    private int _animationCount;
    void Start()
    {
        _enemyData.isDying = false;
        _enemyData.isWalking = true;
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
            if (_enemyData.isWalking)
            {
                _animator.SetBool("isWalking", true);
                //_animator.SetBool("isIdling", false);

                _animator.SetLayerWeight(1, 1);
                _animator.SetLayerWeight(2, 0);
            }
            else if (_enemyData.isDying)
            {
                _animator.SetBool("isDying", true);
                //_animator.SetBool("isIdling", false);

                _animator.SetLayerWeight(2, 1);
                _animator.SetLayerWeight(1, 0);

            }
            else
            {
                _animator.SetBool("isIdling", true);
                //_animator.SetBool("isWalking", false);

                _animator.SetLayerWeight(0, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
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
            _animator.SetLayerWeight(2, 0);
        }
    }
}
