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

    [SerializeField] RectTransform _chooseCharacterButton;
    [SerializeField] RectTransform _playButton;
    [SerializeField] RectTransform _quitButton;
    [SerializeField] RectTransform _continueButton;

    [Header("Sensivity")]
    [SerializeField] Slider _sensivityX;
    [SerializeField] Slider _sensivityY;
    [SerializeField] TextMeshProUGUI _sensivityXText;
    [SerializeField] TextMeshProUGUI _sensivityYText;

    [Header("Data")]
    public PlayerData playerData;

    private void Awake()
    {
        //Sensivity Datas are transforming to preferences on awake
        PlayerPrefs.SetFloat("SensivityX", playerData.sensivityX);
        PlayerPrefs.SetFloat("SensivityY", playerData.sensivityY);        
    }

    private void OnEnable()
    {
        //Sensivity preferences are transforming to sliders on enable
        _sensivityX.value = PlayerPrefs.GetFloat("SensivityX");
        _sensivityY.value = PlayerPrefs.GetFloat("SensivityY");
    }
    private void Start()
    {
        //Settings initial scales are zero
        if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.End.ToString() || SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            _soundSettingsPanel.localScale = Vector3.zero;
            _sensivitySettingsPanel.localScale = Vector3.zero;

            if (playerData.currentMapName != PlayerData.MapNames.FirstMap)
            {
                _continueButton.localScale = Vector3.one;
            }
        }        
    }
    private void Update()
    {
        //Sensivity values are transforming to sensivity datas
        TransformSensivityValueToData();
    }
    void TransformSensivityValueToData()
    {
        playerData.sensivityX = _sensivityX.value;
        playerData.sensivityY = _sensivityY.value;

        _sensivityXText.text = playerData.sensivityX.ToString();
        _sensivityYText.text = playerData.sensivityY.ToString();
    }
    public void ClickSettingButon()
    {
        if (_soundSettingsPanel.localScale.x == 0)
        {
            _soundSettingsPanel.localScale = Vector3.one;
            _sensivitySettingsPanel.localScale = Vector3.one;

            _chooseCharacterButton.localScale = Vector3.zero;
            _playButton.localScale = Vector3.zero;
            _quitButton.localScale = Vector3.zero;
            _continueButton.localScale = Vector3.zero;
        }
        else
        {
            _soundSettingsPanel.localScale = Vector3.zero;
            _sensivitySettingsPanel.localScale = Vector3.zero;

            _chooseCharacterButton.localScale = Vector3.one;
            _playButton.localScale = Vector3.one;
            _quitButton.localScale = Vector3.one;
            if (playerData.currentMapName != PlayerData.MapNames.FirstMap)
            {
                _continueButton.localScale = Vector3.one;
            }
        }
    }
    public void SetDefaulth()
    {
        _sensivityX.value = 10f;
        _sensivityY.value = 10f;
    }
}
