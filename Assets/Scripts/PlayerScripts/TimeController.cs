using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    private float _time;
    private float _swordTime;
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] TextMeshProUGUI _warmTimeText;
    //[SerializeField] TextMeshProUGUI _swordTimeText;
    void Start()
    {
        _warmTimeText.transform.localScale = Vector3.zero;
        //_swordTimeText.transform.localScale = Vector3.zero;
        _timeText.text = "0";
        _time = 0;
        _swordTime = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetTime(900);
        
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
    public void SwordTimer()
    {
        _swordTime += Time.deltaTime;
        if (_swordTime == 3)
        {
            //_swordTimeText.transform.localScale = Vector3.zero;
        }
        if (true)
        {

        }
    }
}
