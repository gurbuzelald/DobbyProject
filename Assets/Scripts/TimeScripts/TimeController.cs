using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI test;

    private float _time;
    private float _swordTime;
    private float _weaponTime;
    private float _enemySpawnTime;
    public PlayerData playerData;
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] TextMeshProUGUI _warmTimeText;
    [SerializeField] TextMeshProUGUI _swordTimeText;
    [SerializeField] EnemyData enemyData;
    void Start()
    {
        _warmTimeText.transform.localScale = Vector3.zero;
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
        test.text = _enemySpawnTime.ToString();

        GetTime(900);
        SwordTimer(playerData, _swordTimeText);
        WeaponTimer(playerData);
        EnemySpawnTimer(playerData.currentEnemySpawnDelay);
    }
    private void GetTime(int timeValue)
    {
        _time += Time.deltaTime;
        //Debug.Log(_time);
        _timeText.text = (((int)(timeValue - _time))).ToString();
        _warmTimeText.text = ((int)(timeValue - _time)).ToString();

        if ((int)_time > timeValue - 1)
        {
            SceneController.GetInstance.LoadEndScene();
        }
        if ((((int)(timeValue - _time))) <= 10)
        {
            _warmTimeText.transform.localScale = Vector3.one;
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
        if (_swordTimeText.text == SwordTexts.Active.ToString() && 
            !playerData.isWalking && !playerData.isBackWalking && 
            !playerData.isClimbing && !playerData.isBackClimbing && 
            !playerData.isJumping && !playerData.isRunning && 
            !playerData.isSkateBoarding )
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
        if ((playerData.isFireNonWalk || playerData.isFireWalk) && _weaponTime >= 0f)
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
