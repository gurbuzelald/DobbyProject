using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemyAnimation<T>:MonoBehaviour where T:MonoBehaviour
{
    public virtual void AnimationState(EnemyData _enemyData, Animator _animator,
        PlayerData _playerData, int _animationCount, int enemyIndex, int enemyDataID)
    {
        if (PlayerData.isPlayable)
        {
            if (_enemyData.enemyStats[enemyIndex].enemyDying[enemyDataID])
            {
                _animator.SetBool("isDying", true);

                _animator.SetLayerWeight(2, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }
            else if (_enemyData.enemyStats[enemyIndex].isWalking[enemyDataID] &&
                !_enemyData.enemyStats[enemyIndex].isAttacking[enemyDataID])
            {
                _animator.SetBool("isWalking", true);

                _animator.SetLayerWeight(1, 1);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }
            else if (_enemyData.enemyStats[enemyIndex].isAttacking[enemyDataID] &&
                !_enemyData.enemyStats[enemyIndex].isWalking[enemyDataID])
            {
                _animator.SetBool("isAttacking", true);

                _animator.SetLayerWeight(4, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
            }
            else if (!_enemyData.enemyStats[enemyIndex].isWalking[enemyDataID] &&
                !_enemyData.enemyStats[enemyIndex].isAttacking[enemyDataID] &&
                !_enemyData.enemyStats[enemyIndex].isFiring[enemyDataID])
            {
                _animator.SetBool("isIdling", true);

                _animator.SetLayerWeight(0, 1);
                _animator.SetLayerWeight(1, 0);
                _animator.SetLayerWeight(2, 0);
                _animator.SetLayerWeight(3, 0);
                _animator.SetLayerWeight(4, 0);
            }
            else if (_enemyData.enemyStats[enemyIndex].isFiring[enemyDataID])
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
