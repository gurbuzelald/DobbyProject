using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] RectTransform _soundSettingsPanel;
    [SerializeField] RectTransform _sensivitySettingsPanel;

    [Header("Sensivity")]
    [SerializeField] Slider _sensivityX;
    [SerializeField] Slider _sensivityY;
    [SerializeField] TextMeshProUGUI _sensivityXText;
    [SerializeField] TextMeshProUGUI _sensivityYText;

    [Header("Data")]
    public PlayerData playerData;

    private void Awake()
    {
        PlayerPrefs.SetFloat("SensivityX", playerData.sensivityX);
        PlayerPrefs.SetFloat("SensivityY", playerData.sensivityY);        
    }
    private void OnEnable()
    {
        _sensivityX.value = PlayerPrefs.GetFloat("SensivityX");
        _sensivityY.value = PlayerPrefs.GetFloat("SensivityY");
    }
    private void Start()
    {
        _soundSettingsPanel.localScale = Vector3.zero;
        _sensivitySettingsPanel.localScale = Vector3.zero;
    }
    private void Update()
    {
        TransformSensivityValueToData();
    }
    void TransformSensivityValueToData()
    {
        playerData.sensivityX = _sensivityX.value;
        playerData.sensivityY = _sensivityY.value;

        _sensivityXText.text = playerData.sensivityX.ToString();
        _sensivityYText.text = playerData.sensivityY.ToString();
    }
    public void OpenSettings()
    {
        if (_soundSettingsPanel.localScale.x == 0)
        {
            _soundSettingsPanel.localScale = Vector3.one;
            _sensivitySettingsPanel.localScale = Vector3.one;
        }
        else
        {
            _soundSettingsPanel.localScale = Vector3.zero;
            _sensivitySettingsPanel.localScale = Vector3.zero;
        }
        
    }
}
