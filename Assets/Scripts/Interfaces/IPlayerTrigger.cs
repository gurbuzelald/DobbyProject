using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal interface IPlayerTrigger
{
    void TriggerBullet(Collider other, PlayerData _playerData, 
                        ref GameObject _healthBarObject, 
                        ref GameObject _topCanvasHealthBarObject, 
                        ref Transform _particleTransform,
                        ref Slider healthBarSlider,
                        ref Slider topCanvasHealthBarSlider,
                        ref TextMeshProUGUI damageHealthText);


    void PickUpCoin(LevelData levelData,
                    string value, 
                    Collider other, 
                    PlayerData _playerData, 
                    ref GameObject _coinObject, 
                    ref GameObject _cheeseObject, 
                    ref GameObject bulletAmountCanvas,
                    ref TextMeshProUGUI bulletAmountText,
                    ref TextMeshProUGUI bulletPackAmountText,
                    ref EnvironmentObjectPool environmentObjectPool);

    void CheckWeaponCollect(Collider other, BulletData _bulletData);

    void CheckAllWeaponsLocked(BulletData bulletData);

    void DamageArrowDirection(ref GameObject _damageArrow);

    void SetBulletPackAndAmountTextSize(PlayerData _playerData, ref GameObject bulletAmountCanvas);

    void GettingPoisonDamage(PlayerData _playerData, ref Slider _topCanvasHealthBarSlider, ref Slider _healthBarSlider);

    void DelayLevelUp();


    IEnumerator DamageArrowIsLookAtEnemy(Collider other, GameObject _damageArrow);

    IEnumerator DelayDamageArrowDirection(GameObject _damageArrow);

    IEnumerator DelayDestroyCoinObject(GameObject coinObject);

    IEnumerator DelayTransformOneGiftBoxWarnText(Collider other);
}
