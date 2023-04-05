using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerTrigger
{
    void TriggerLadder(bool isTouch, bool isTouchExit, PlayerData _playerData);


    void TriggerBullet(Collider other, PlayerData _playerData, ref GameObject _healthBarObject, ref GameObject _topCanvasHealthBarObject, ref Transform _particleTransform);


    void PickUpCoin(SceneController.Tags value, Collider other, PlayerData _playerData, ref GameObject _coinObject, ref GameObject _cheeseObject, ref GameObject bulletAmountCanvas);

    void CheckWeaponCollect(Collider other, BulletData _bulletData);

    void DamageArrowDirection(ref GameObject _damageArrow);

    void BulletPackGrow(PlayerData _playerData, ref GameObject bulletAmountCanvas);

    void DestroyByWater(PlayerData _playerData);

    void DestroyByLava(PlayerData _playerData, ref Transform _particleTransform);

    void GettingPoisonDamage(PlayerData _playerData, ref GameObject _topCanvasHealthBarObject, ref GameObject _healthBarObject);

    IEnumerator DelayLevelUp(float delayWait, float delayDestroy, PlayerData _playerData, Collider other);


    IEnumerator DamageArrowIsLookAtEnemy(Collider other, GameObject _damageArrow);

    IEnumerator DelayDamageArrowDirection(GameObject _damageArrow);

    IEnumerator DelayDestroyCoinObject(GameObject coinObject);

    IEnumerator DelayTransformOneGiftBoxWarmText(Collider other);




    void CreateVictoryAnimation(PlayerData _playerData, ref Transform _jolleenTransform);
}
