using UnityEngine;

public class EnemyAnimationController : AbstractEnemyAnimation<EnemyAnimationController>
{
    [Header("Animator")]
    [SerializeField] RuntimeAnimatorController[] runtimeAnimatorControllers;
    [SerializeField] RuntimeAnimatorController runAnimatorController;
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

        _enemyData.enemyStats[_enemyManager.GetEnemyIndex()].enemyDying[_enemyManager.enemyDataNumber] = false;
        _enemyData.enemyStats[_enemyManager.GetEnemyIndex()].isWalking[_enemyManager.enemyDataNumber] = true;
        _animationCount = 0;
        SetAnimator();
    }

    

    public void SetAnimator()
    {
        if (_enemyManager)
        {
            if (runtimeAnimatorControllers != null)
            {
                if (runtimeAnimatorControllers[_enemyManager.enemyDataNumber] != null)
                {
                    runAnimatorController = runtimeAnimatorControllers[_enemyManager.enemyDataNumber];
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
                _enemyManager.enemyDataNumber);
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

        _enemyManager.enemyData.enemyStats[_enemyManager.GetEnemyIndex()].enemyDying[_enemyManager.enemyDataNumber] = false;
    }
}
