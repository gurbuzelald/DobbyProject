using UnityEngine;

internal interface  IPlayerMovement
{
    void Run(PlayerData _playerData, Transform _particleTransform, float runTimeAmount, Rigidbody objectRigidbody, ObjectPool objectPool,
        PlayerData playerData);
    void Walk(PlayerData _playerData, ref Transform playerTransform, ref Animator characterAnimator);
    void Jump(PlayerData _playerData, ref Rigidbody playerRigidbody);
}
