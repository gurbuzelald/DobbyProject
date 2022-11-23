using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public PlayerData _playerData;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (_playerData.isWalking && !_playerData.isBackWalking)
        {
            _animator.SetBool("isWalking", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isIdling", false);
            _animator.SetLayerWeight(1, 1);
        }
        else if (_playerData.isBackWalking && !_playerData.isWalking)
        {
            _animator.SetBool("isBackWalking", true);

            _animator.SetBool("isWalking", false);
            _animator.SetBool("isIdling", false);
            _animator.SetLayerWeight(1, 1);
        }
        else if (!_playerData.isBackWalking && !_playerData.isWalking)
        {
            _animator.SetBool("isIdling", true);

            _animator.SetBool("isBackWalking", false);
            _animator.SetBool("isWalking", false);
            _animator.SetLayerWeight(1, 0);
        }
    }
}