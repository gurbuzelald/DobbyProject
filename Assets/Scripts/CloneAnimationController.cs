using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneAnimationController : MonoBehaviour
{
    [Header("Animator")]
    private Animator _animator;

    [Header("Data")]
    public PlayerData _playerData;
    public PlayerData _cloneData;

    void Start()
    {
        _cloneData.isCloneDying = false;
        _cloneData.isCloneWalking = true;
        _cloneData.idlingCount = 0;
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
            if (_cloneData.isCloneWalking)
            {
                _animator.SetBool("isWalking", true);

                _animator.SetLayerWeight(1, 1);
            }
            if (_cloneData.isCloneDying)
            {
                //_animator.SetBool("isDying", true);

                //_animator.SetLayerWeight(2, 1);
            }
            if (_cloneData.isDancing)
            {
                _animator.SetLayerWeight(2, 1);

                _animator.SetBool("isDancing", true);
            }
            if(_cloneData.isCloneDying)
            {
                _animator.SetLayerWeight(1, 0);
                _animator.SetBool("isDying", true);

                //_animator.SetLayerWeight(0, 1);
                //_animator.SetBool("isIdling", true);
            }
        }
        else
        {
            _cloneData.idlingCount++;

            if (_cloneData.idlingCount == 0)
            {
                _animator.SetBool("isIdling", true);
            }
            _animator.SetLayerWeight(0, 1);
            _animator.SetLayerWeight(1, 0);
        }
    }
}

