using UnityEngine;

internal interface  IPlayerMovement
{
    void SkateBoard(PlayerData _playerData, Transform _particleTransform);
    void Run(PlayerData _playerData, Transform _particleTransform, float runTimeAmount);
    void Walk(PlayerData _playerData);
    void Climb(PlayerData _playerData);
    void Jump(PlayerData _playerData);
    void SideWalk(PlayerData _playerData);
    void SpeedSettings(PlayerData _playerData, float _initPlayerSpeed);
}
