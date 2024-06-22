using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI test;

    private float _time;
    private float _swordTime;
    private float _weaponTime;
    private float _enemySpawnTime;

    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] TextMeshProUGUI _warnTimeText;
    [SerializeField] TextMeshProUGUI _swordTimeText;

    [SerializeField] EnemyData enemyData;
    [SerializeField] LevelData levelData;
    [SerializeField] BulletData bulletData;
    public PlayerData playerData;

    public int initialTimeValue = 300;
    void Start()
    {
        _warnTimeText.transform.localScale = Vector3.zero;
        //_swordTimeText.transform.localScale = Vector3.zero;
        _timeText.text = "0";
        _time = 0;
        _swordTime = 0;
        _weaponTime = 0;
        _enemySpawnTime = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //test.text = _enemySpawnTime.ToString();

        GetTime(initialTimeValue);

        SwordTimer(playerData, _swordTimeText);


        WeaponTimer(playerData);
        EnemySpawnTimer(levelData.currentEnemySpawnDelay);
    }
    private void GetTime(int timeValue)
    {
        _time += Time.deltaTime;
        //Debug.Log(_time);
        _timeText.text = (((int)(timeValue - _time))).ToString();
        _warnTimeText.text = ((int)(timeValue - _time)).ToString();

        if ((int)_time > timeValue - 1)
        {
            StartCoroutine(PlayerManager.GetInstance.DelayDestroy(0));
        }
        if ((((int)(timeValue - _time))) <= 10)
        {
            _warnTimeText.transform.localScale = Vector3.one;
        }
        else
        {
            _warnTimeText.transform.localScale = Vector3.zero;
        }
        if (levelData.isLevelUp && LevelData.levelCanUp)
        {
            timeValue = initialTimeValue;
            _time = 0;
        }
    }
    public void SwordTimer(PlayerData playerData, TextMeshProUGUI _swordTimeText)
    {
        if (_swordTime <= 2)
        {
            _swordTimeText.text = ((int)_swordTime).ToString();
        }
        else
        {
            _swordTimeText.text = SwordTexts.Active.ToString();
        }
        playerData.isSwordTime = false;
        if (_swordTimeText.text == SwordTexts.Active.ToString())
        {
            playerData.isSwordTime = true;
            if (playerData.isSwording && playerData.isPlayable)
            {
                _swordTime = 0;
            }
        }
        _swordTime += Time.deltaTime;
    }
    public void WeaponTimer(PlayerData playerData)
    {
        if ((playerData.isFireNonWalk || playerData.isFireWalk) && _weaponTime >= bulletData.currentShootFrequency)
        {
            playerData.isFireTime = true;
            _weaponTime = 0;
        }
        else
        {
            playerData.isFireTime = false;
        }

        _weaponTime += Time.deltaTime;
    }

    public void EnemySpawnTimer(int enemSpawnDelayer)
    {
        if (_enemySpawnTime >= enemSpawnDelayer)
        {
            enemyData.isActivateCreateEnemy = true;


            _enemySpawnTime = 0;
        }

        _enemySpawnTime += Time.deltaTime;
    }
    enum SwordTexts
    {
        Active
    }
}
