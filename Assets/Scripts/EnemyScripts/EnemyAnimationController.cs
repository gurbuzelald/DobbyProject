using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [Header("Animator")]
    private Animator _animator;
    private int _animationCount;

    [Header("Data")]
    public EnemyData _enemyData;
    public PlayerData _playerData;

    void Start()
    {
        _enemyData.isDying = false;
        _enemyData.isWalking = true;
        _animationCount = 0;
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        AnimationState();
    }
    public void AnimationState()
    {
        if (!_playerData.isDestroyed)
        {
            if (_enemyData.isWalking && !_enemyData.isFiring)
            {
                _animator.SetBool("isWalking", true);

                _animator.SetLayerWeight(1, 1);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
            }
            else if (_enemyData.isDying && !_enemyData.isFiring)
            {
                _animator.SetBool("isDying", true);

                _animator.SetLayerWeight(2, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(3, 0);
            }
            else if (_enemyData.isFiring)
            {
                _animator.SetBool("isFiring", true);

                _animator.SetLayerWeight(3, 1);
                _animator.SetLayerWeight(1, 0);
            }
            else if(!_enemyData.isFiring)
            {
                _animator.SetBool("isIdling", true);

                _animator.SetLayerWeight(0, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
            }
        }
        else
        {
            _animationCount++;

            if (_animationCount == 0)
            {
                _animator.SetBool("isIdling", true);
            }
            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
            _animator.SetLayerWeight(2, 0);
        }
    }
}
