using UnityEngine;

public class EnemyAnimationController : AbstractEnemyAnimation<EnemyAnimationController>
{
    [Header("Animator")]
    //private RuntimeAnimatorController[] runtimeAnimatorControllers;
    [SerializeField] RuntimeAnimatorController runAnimatorController;
    public RuntimeAnimatorController exampleRunAnimatorController;
    private Animator _animator;
    private int _animationCount;

    [Header("Data")]
    private EnemyData _enemyData;
    private PlayerData _playerData;
    private EnemyManager _enemyManager;
    private EnemySpawner _enemySpawner;

    void Start()
    {
        _enemySpawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
        //runtimeAnimatorControllers = new RuntimeAnimatorController[gameObject.transform.parent.parent.childCount];

        _playerData = gameObject.transform.parent.GetComponent<EnemyManager>().playerData;

        _enemyManager = gameObject.transform.parent.GetComponent<EnemyManager>();

        _enemyData = _enemyManager.enemyData;

        _enemyData.enemyStats[_enemyManager.GetEnemyIndex()].enemyDying[_enemyManager.enemyChildID] = false;
        _enemyData.enemyStats[_enemyManager.GetEnemyIndex()].isWalking[_enemyManager.enemyChildID] = true;
        _animationCount = 0;
        SetAnimator();
    }

    

    public void SetAnimator()
    {
        if (_enemyManager)
        {

            /*for (int i = 0; i < gameObject.transform.parent.parent.childCount; i++)
            {
                runtimeAnimatorControllers[i] = Instantiate(exampleRunAnimatorController);
            }*/

            for (int i = 0; i < gameObject.transform.parent.parent.parent.childCount; i++)
            {
                if (gameObject.transform.parent.parent.name == "normalEnemyTransform")
                {
                    if (_enemySpawner.animatorStruct[0].runtimeAnimatorControllers != null)
                    {
                        if (_enemySpawner.animatorStruct[0].runtimeAnimatorControllers[_enemyManager.enemyChildID] != null)
                        {
                            runAnimatorController = _enemySpawner.animatorStruct[0].runtimeAnimatorControllers[_enemyManager.enemyChildID];
                        }

                    }
                }
                else if (gameObject.transform.parent.parent.name == "bossEnemyTransform")
                {
                    if (_enemySpawner.animatorStruct[1].runtimeAnimatorControllers != null)
                    {
                        if (_enemySpawner.animatorStruct[1].runtimeAnimatorControllers[_enemyManager.enemyChildID] != null)
                        {
                            runAnimatorController = _enemySpawner.animatorStruct[1].runtimeAnimatorControllers[_enemyManager.enemyChildID];
                        }

                    }
                }
                else if (gameObject.transform.parent.parent.name == "chestMonsterTransform")
                {
                    if (_enemySpawner.animatorStruct[2].runtimeAnimatorControllers != null)
                    {
                        if (_enemySpawner.animatorStruct[2].runtimeAnimatorControllers[_enemyManager.enemyChildID] != null)
                        {
                            runAnimatorController = _enemySpawner.animatorStruct[2].runtimeAnimatorControllers[_enemyManager.enemyChildID];
                        }

                    }
                }
                else if (gameObject.transform.parent.parent.name == "tazoTransform")
                {
                    if (_enemySpawner.animatorStruct[3].runtimeAnimatorControllers != null)
                    {
                        if (_enemySpawner.animatorStruct[3].runtimeAnimatorControllers[_enemyManager.enemyChildID] != null)
                        {
                            runAnimatorController = _enemySpawner.animatorStruct[3].runtimeAnimatorControllers[_enemyManager.enemyChildID];
                        }

                    }
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
        if (_animator)
        {
            AnimationState(_enemyData, _animator, _playerData,
                _animationCount, _enemyManager.GetEnemyIndex(),
                _enemyManager.enemyChildID);
        }              
        
    }
    public void FinishedAttackAnimation()
    {
        //Touch ParticleEffect
        GameObject particleObject = null;

        if (particleObject == null)
        {
            particleObject =
                PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(PlayerManager.GetInstance._playerData.playerTouchParticleObjectPoolCount);
            particleObject.transform.position = PlayerManager.GetInstance._particleTransform.position;

            StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 1f));
        }
        _playerData.isDecreaseHealth = false;

        _enemyManager.SetEnemyAttackDamage(ref _enemyManager.bulletData);
        _playerData.decreaseCounter = 0;
    }

    public void EnemySetActiveFalse()
    {
        MainEnemyData.enemyDeathCount++;

        gameObject.transform.parent.gameObject.SetActive(false);

        _enemyManager.enemyData.enemyStats[_enemyManager.GetEnemyIndex()].enemyDying[_enemyManager.enemyChildID] = false;
    }
}
