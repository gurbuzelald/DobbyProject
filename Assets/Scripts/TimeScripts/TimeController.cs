using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI test;

    private float time;
    private float _weaponTime;

    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] TextMeshProUGUI _warnTimeText;

    [SerializeField] EnemyData enemyData;
    [SerializeField] LevelData levelData;
    [SerializeField] BulletData bulletData;
    public PlayerData playerData;

    public static int initialTimeValue = 500;


    void Start()
    {
        _warnTimeText.transform.localScale = Vector3.zero;
        _timeText.text = "0";
        time = 0;
        _weaponTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetTime(initialTimeValue);

        WeaponTimer(playerData);
    }
    private void GetTime(int timeValue)
    {
        if (!SceneController.pauseGame)
        {
            if (timeValue - time <= 0)
            {
                playerData.isPlayable = false;
                playerData.isDying = true;
                StartCoroutine(PlayerManager.GetInstance.DelayPlayerDestroy(4));
                _warnTimeText.text = "";
            }
            else
            {
                time += Time.deltaTime;
                //Debug.Log(_time);
                _timeText.text = (((int)(timeValue - time))).ToString();
                _warnTimeText.text = ((int)(timeValue - time)).ToString();

                if ((((int)(timeValue - time))) <= 10)
                {
                    _warnTimeText.transform.localScale = Vector3.one;
                }
                else
                {
                    _warnTimeText.transform.localScale = Vector3.zero;
                }
                if (LevelData.isLevelUp && LevelData.levelCanBeSkipped)
                {
                    timeValue = initialTimeValue;
                    time = 0;
                }
            }
        }        
    }
    public void WeaponTimer(PlayerData playerData)
    {
        if ((playerData.isFire || playerData.isFire) && _weaponTime >= bulletData.currentShootFrequency)
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

    enum SwordTexts
    {
        Active
    }
}
