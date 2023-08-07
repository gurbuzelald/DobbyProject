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

    private GameObject _chooseCharacterButton;
    private GameObject _playButton;
    private GameObject _quitButton;
    private GameObject _continueButton;

    [Header("Sensivity")]
    [SerializeField] Slider _sensivityX;
    [SerializeField] Slider _sensivityY;
    [SerializeField] TextMeshProUGUI _sensivityXText;
    [SerializeField] TextMeshProUGUI _sensivityYText;

    [Header("Data")]
    public PlayerData playerData;

    private void Awake()
    {
        //Finding button objects with names.
        FindButtonObjects();

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
                _continueButton.GetComponent<RectTransform>().localScale = Vector3.one;
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
    public void ClickSettingButton()
    {
        if (_soundSettingsPanel.localScale.x == 0)
        {
            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            _soundSettingsPanel.localScale = Vector3.one;
            _sensivitySettingsPanel.localScale = Vector3.one;

            _chooseCharacterButton.GetComponent<RectTransform>().localScale = Vector3.zero;
            _playButton.GetComponent<RectTransform>().localScale = Vector3.zero;
            _quitButton.GetComponent<RectTransform>().localScale = Vector3.zero;
            _continueButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        else
        {
            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            _soundSettingsPanel.localScale = Vector3.zero;
            _sensivitySettingsPanel.localScale = Vector3.zero;

            _chooseCharacterButton.GetComponent<RectTransform>().localScale = Vector3.one;
            _playButton.GetComponent<RectTransform>().localScale = Vector3.one;
            _quitButton.GetComponent<RectTransform>().localScale = Vector3.one;
            if (playerData.currentMapName != PlayerData.MapNames.FirstMap)
            {
                _continueButton.GetComponent<RectTransform>().localScale = Vector3.one;
            }
        }
    }
    public void SetDefaulth()
    {
        _sensivityX.value = 10f;
        _sensivityY.value = 10f;
    }

    void FindButtonObjects()
    {
        _chooseCharacterButton = GameObject.Find("ChooseCharacterButton");
        _playButton = GameObject.Find("PlayButton");
        _quitButton = GameObject.Find("QuitButton");
        _continueButton = GameObject.Find("ContinueButton");
    }
}