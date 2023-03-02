using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : AbstractEnemyAnimation<EnemyAnimationController>
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
        AnimationState(_enemyData, _animator, _playerData, _animationCount);
    }
}
