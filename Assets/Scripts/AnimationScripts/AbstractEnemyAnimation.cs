using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemyAnimation<T>:MonoBehaviour where T:MonoBehaviour
{
    public virtual void AnimationState(EnemyData _enemyData, Animator _animator, PlayerData _playerData, int _animationCount)
    {
        if (_playerData.isPlayable)
        {
            if (_enemyData.isDying)
            {
                _animator.SetBool("isDying", true);

                _animator.SetLayerWeight(2, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }
            else if (_enemyData.isWalking && !_enemyData.isAttacking)
            {
                _animator.SetBool("isWalking", true);

                _animator.SetLayerWeight(1, 1);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }
            else if (_enemyData.isAttacking && !_enemyData.isWalking)
            {
                _animator.SetBool("isAttacking", true);

                _animator.SetLayerWeight(4, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
            }
            else if (!_enemyData.isWalking && !_enemyData.isAttacking && !_enemyData.isFiring)
            {
                _animator.SetBool("isIdling", true);

                _animator.SetLayerWeight(0, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }
            else if (_enemyData.isFiring)
            {
                _animator.SetBool("isFiring", true);

                _animator.SetLayerWeight(3, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }
        }
        else
        {
            if (_animationCount == 0)
            {
                _animator.SetBool("isIdling", true);
                _animator.SetLayerWeight(0, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }
            
        }
    }
}
