using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    private float _time;
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] TextMeshProUGUI _warmTimeText;
    void Start()
    {
        _warmTimeText.transform.localScale = Vector3.zero;
        _timeText.text = "0";
        _time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetTime(90);
        
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
}
