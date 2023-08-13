using UnityEngine;

internal interface  IPlayerMovement
{
    void SkateBoard(PlayerData _playerData, Transform _particleTransform, ref Transform playerTransform);
    void Run(PlayerData _playerData, Transform _particleTransform, float runTimeAmount, Rigidbody objectRigidbody);
    void Walk(PlayerData _playerData, ref Transform playerTransform, ref Animator characterAnimator);
    void Climb(PlayerData _playerData, ref Transform playerTransform);
    void Jump(PlayerData _playerData, ref Rigidbody playerRigidbody);
    void SideWalk(PlayerData _playerData, ref Transform playerTransform);
    void SpeedSettings(PlayerData _playerData, float _initPlayerSpeed);
}
