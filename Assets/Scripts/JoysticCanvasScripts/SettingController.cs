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

    private GameObject _pickCharacterButton;
    private RectTransform _pickCharacterButtonRectTransform;

    private GameObject _playButton;
    private RectTransform _playButtonRectTransform;

    private GameObject _quitButton;
    private RectTransform _quitButtonRectTransform;

    private GameObject _continueButton;
    private RectTransform _continueButtonRectTransform;

    [Header("Sensivity")]
    [SerializeField] Slider _sensivityX;
    [SerializeField] Slider _sensivityY;
    [SerializeField] TextMeshProUGUI _sensivityXText;
    [SerializeField] TextMeshProUGUI _sensivityYText;

    [Header("Data")]
    public PlayerData playerData;
    public LevelData levelData;

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
        ButtonRectTrasforms();

        //Settings initial scales are zero
        if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.End.ToString() || SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            _soundSettingsPanel.localScale = Vector3.zero;
            _sensivitySettingsPanel.localScale = Vector3.zero;

            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 300,
                                                             gameObject.transform.localPosition.y,
                                                             gameObject.transform.localPosition.z);

            if (levelData.currentLevel != LevelData.Levels.Level1)
            {
                _continueButton.GetComponent<RectTransform>().localScale = Vector3.one;
            }
        }
    }
    void ButtonRectTrasforms()
    {
        if (_pickCharacterButton)
        {
            _pickCharacterButtonRectTransform = _pickCharacterButton.GetComponent<RectTransform>();
        }
        if (_playButton)
        {
            _playButtonRectTransform = _playButton.GetComponent<RectTransform>();
        }
        if (_quitButton)
        {
            _quitButtonRectTransform = _quitButton.GetComponent<RectTransform>();
        }
        if (_continueButton)
        {
            _continueButtonRectTransform = _continueButton.GetComponent<RectTransform>();
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

            _pickCharacterButtonRectTransform.localScale = Vector3.zero;
            _playButtonRectTransform.localScale = Vector3.zero;
            _quitButtonRectTransform.localScale = Vector3.zero;
            _continueButtonRectTransform.localScale = Vector3.zero;
        }
        else
        {
            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            _soundSettingsPanel.localScale = Vector3.zero;
            _sensivitySettingsPanel.localScale = Vector3.zero;

            _pickCharacterButtonRectTransform.localScale = Vector3.one;
            _playButtonRectTransform.localScale = Vector3.one;
            _quitButtonRectTransform.localScale = Vector3.one;
            if (levelData.currentLevel != LevelData.Levels.Level1)
            {
                _continueButtonRectTransform.localScale = Vector3.one;
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
        _pickCharacterButton = GameObject.Find("PickCharacterButton");
        _playButton = GameObject.Find("PlayButton");
        _quitButton = GameObject.Find("QuitButton");
        _continueButton = GameObject.Find("ContinueButton");
    }
}