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

    private GameObject _pickWeaponButton;
    private RectTransform _pickCharacterButtonRectTransform;

    private GameObject _pickCharacterButton;
    private RectTransform _pickWeaponButtonRectTransform;

    private GameObject _playButton;
    private RectTransform _playButtonRectTransform;

    private GameObject _quitButton;
    private RectTransform _quitButtonRectTransform;

    private GameObject _continueButton;
    private RectTransform _continueButtonRectTransform;

    private GameObject _levelsButton;
    private RectTransform _levelsButtonRectTransform;   
    

    private GameObject _languageButton;
    private RectTransform _languageButtonRectTransform;

    [Header("Sensivity")]
    [SerializeField] Slider _sensivityX;
    [SerializeField] Slider _sensivityY;
    [SerializeField] TextMeshProUGUI _sensivityXText;
    [SerializeField] TextMeshProUGUI _sensivityYText;

    [Header("Data")]
    public PlayerData playerData;
    public LevelData levelData;

    private float settingButtonTimer;

    private void Awake()
    {
        settingButtonTimer = 0f;

        //Finding button objects with names.
        FindButtonObjects();

        //Sensivity Datas are transforming to preferences on awake
        PlayerPrefs.SetFloat("SensivityX", playerData.sensivityX);
        PlayerPrefs.SetFloat("SensivityY", playerData.sensivityY);

        _sensivityX.value = PlayerPrefs.GetFloat("SensivityX");
        _sensivityY.value = PlayerPrefs.GetFloat("SensivityY");
    }
    private void OnEnable()
    {
        //Sensivity preferences are transforming to sliders on enable
        
    }
    private void Start()
    {
        ButtonRectTrasforms();

        //Settings initial scales are zero
        if (SceneController.CheckSceneName() == SceneController.Scenes.End.ToString() ||
            SceneController.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            _soundSettingsPanel.localScale = Vector3.zero;
            _sensivitySettingsPanel.localScale = Vector3.zero;

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
        if (_pickWeaponButton)
        {
            _pickWeaponButtonRectTransform = _pickWeaponButton.GetComponent<RectTransform>();
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
        if (_levelsButton)
        {
            _levelsButtonRectTransform = _levelsButton.GetComponent<RectTransform>();
        }
        if (_languageButton)
        {
            _languageButtonRectTransform = _languageButton.GetComponent<RectTransform>();
        }
    }
    private void Update()
    {
        //Sensivity values are transforming to sensivity datas
        TransformSensivityValueToData();


        if (SceneController.Scenes.Menu.ToString() == SceneController.CheckSceneName())
        {
            DelaySettingButton();
        }
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
        if (_soundSettingsPanel.localScale.x == 0 && settingButtonTimer >= .5f)
        {
            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            _soundSettingsPanel.localScale = Vector3.one;
            _sensivitySettingsPanel.localScale = Vector3.one;

            _pickCharacterButtonRectTransform.localScale = Vector3.zero;
            _pickWeaponButtonRectTransform.localScale = Vector3.zero;
            _playButtonRectTransform.localScale = Vector3.zero;
            _quitButtonRectTransform.localScale = Vector3.zero;
            _continueButtonRectTransform.localScale = Vector3.zero;
            _levelsButtonRectTransform.localScale = Vector3.zero;
            _languageButtonRectTransform.localScale = Vector3.zero;
            settingButtonTimer = 0f;

            
        }
        else if(settingButtonTimer >= .5f && _soundSettingsPanel.localScale.x == 1)
        {
            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            _soundSettingsPanel.localScale = Vector3.zero;
            _sensivitySettingsPanel.localScale = Vector3.zero;

            _pickCharacterButtonRectTransform.localScale = Vector3.one;
            _pickWeaponButtonRectTransform.localScale = Vector3.one;
            _playButtonRectTransform.localScale = Vector3.one;
            _quitButtonRectTransform.localScale = Vector3.one;
            _levelsButtonRectTransform.localScale = Vector3.one;
            _languageButtonRectTransform.localScale = Vector3.one;
            
            if (levelData.currentLevel != LevelData.Levels.Level1)
            {
                _continueButtonRectTransform.localScale = Vector3.one;
            }

            settingButtonTimer = 0f;
        }
    }

    void DelaySettingButton()
    {
        settingButtonTimer += Time.deltaTime;
    }

    public void SetDefaulth()
    {
        _sensivityX.value = 10f;
        _sensivityY.value = 0f;
    }

    void FindButtonObjects()
    {
        _pickCharacterButton = GameObject.Find("PickCharacterButton");
        _pickWeaponButton = GameObject.Find("PickWeaponButton");
        _playButton = GameObject.Find("PlayButton");
        _quitButton = GameObject.Find("QuitButton");
        _continueButton = GameObject.Find("ContinueButton");
        _levelsButton = GameObject.Find("LevelsButton");
        _languageButton = GameObject.Find("LanguageButton");
    }
}