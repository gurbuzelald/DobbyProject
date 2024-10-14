using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerInitial
{
    void GetHandObjectsTransform(ref GameObject _coinObject, ref GameObject _cheeseObject);

    void GetWeaponTransform(BulletData _bulletData, ref GameObject _gunTransform);

    void GetSwordTransform(BulletData _bulletData, ref GameObject _swordTransform);

    void CreateStartPlayerStaff(PlayerData _playerData, ref Transform playerIconTransform, ref Transform _bulletsTransform,
                                               ref Transform _cameraWasherTransform, Transform healthBarTransform,
                                               ref GameObject _healthBarObject, ref GameObject bulletAmountCanvas);

    void DataStatesOnInitial(LevelData levelData, PlayerData _playerData, BulletData _bulletData, ref GameObject _healthBarObject,
                             ref GameObject _topCanvasHealthBarObject, ref GameObject bulletAmountCanvas);

    void CreateCharacterObject(PlayerData _playerData, ref GameObject characterObject);
}
