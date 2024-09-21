using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class EnemyAnimationController : AbstractEnemyAnimation<EnemyAnimationController>
{
    [Header("Animator")]
    [SerializeField] RuntimeAnimatorController[] runAnimatorControllers;
    private RuntimeAnimatorController runAnimatorController;
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


        if (_enemyManager)
        {
            if (runAnimatorControllers != null)
            {
                if (runAnimatorControllers[_enemyManager.enemyDataNumber] != null)
                {
                    runAnimatorController = runAnimatorControllers[_enemyManager.enemyDataNumber];
                }
                
            }          

            _animator = gameObject.transform.GetComponent<Animator>();

            if (_animator && runAnimatorController)
            {
                _animator.runtimeAnimatorController = runAnimatorController;
            }           
        }
        

    }
    void Update()
    {
        if (_animator && _animator)
        {
            AnimationState(_enemyData, _animator, _playerData, _animationCount);
        }              
        
    }
}
