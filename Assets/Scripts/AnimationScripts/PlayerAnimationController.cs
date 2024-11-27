using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AbstractPlayerAnimation<PlayerAnimationController>
{
    [Header("Animator")]
    private Animator _animator;

    [Header("Data")]
    private PlayerData playerData;

    private BulletManager bulletManager;

    [System.Obsolete]
    private void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();

        playerData = this.gameObject.transform.parent.transform.parent.GetComponent<PlayerManager>()._playerData;


        StartAnimations(playerData, _animator);
    }
    void OnEnable()
    {
        _animator = GetComponent<Animator>();

        if (_animator != null)
        {
            _animator.SetLayerWeight(8, 0);
        }
    }
    void Update()
    {
        AnimationStates();
    }
    public void AnimationStates()
    {
        UpdateAnimations(playerData, _animator);
    }
    public void SwordAnimationCompleted()
    {
        //bulletManager.SwordFire();
        PlayerData.isSwordAnimate = false;
        if (bulletManager)
        {
            if (bulletManager._currentSwordObject)
            {
                bulletManager._currentSwordObject.SetActive(false);
            }
        }        
    }
    public void SwordFireBulletParticle()
    {
        if (PlayerManager.GetInstance._playerData)
        {
            bulletManager.SwordFire(PlayerManager.GetInstance._bulletData.swordBulletDelay,
                                    PlayerManager.GetInstance._playerData.playerSwordBulletObjectPoolCount);
        }
        JoystickCanvasManager.isSwordable = false;
    }

    public void LoadEndScene()
    {
        Destroy(gameObject.transform.parent.gameObject);
        SceneController.LoadEndScene();
    }
}