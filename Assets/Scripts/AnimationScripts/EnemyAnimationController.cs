using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : AbstractEnemyAnimation<EnemyAnimationController>
{
    [Header("Animator")]
    private Animator _animator;
    private int _animationCount;

    [Header("Data")]
    private EnemyData _enemyData;
    private PlayerData _playerData;
    private EnemyManager _enemyManager;

    void Start()
    {
        _playerData = gameObject.transform.parent.GetComponent<EnemyManager>().playerData;

        _enemyManager = gameObject.transform.parent.GetComponent<EnemyManager>();

        _enemyData = _enemyManager.enemyData;

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
