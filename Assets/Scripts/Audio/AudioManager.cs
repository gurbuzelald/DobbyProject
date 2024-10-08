using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : AbstractPlayer<AudioManager>
{
    [Header("Data")]
    public AudioData audioData;
    public LevelData _levelData;

    [Header("Audio Components")]
    public AudioMixer _audiomixer;
    private AudioSource _audioSource;

    public static float buttonDelayTimer;

    // Start is called before the first frame update
    void Start()
    {
        //buttonDelayTimer = 0;

        SetCurrentMusic();
        LoadVolume();   
    }


    private void Update()
    {
        DelayButton();//This Code Writen for ButtonController's Button Delay
    }

    void DelayButton()
    {
        buttonDelayTimer += Time.deltaTime;
    }

    public void SetCurrentMusic()
    {
        if (audioData && _levelData)
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource)
            {
                if (SceneController.CheckSceneName() == SceneController.Scenes.Menu.ToString())
                {
                    _audioSource.clip = audioData.menuMusic;
                    _audioSource.Play();
                }
                if (SceneController.CheckSceneName() == SceneController.Scenes.End.ToString())
                {
                    _audioSource.clip = audioData.endMusic;
                    _audioSource.Play();
                }
                if (SceneController.CheckSceneName() == SceneController.Scenes.Win.ToString())
                {
                    _audioSource.clip = audioData.winMusic;
                    _audioSource.Play();
                }
                if (SceneController.CheckSceneName() == SceneController.Scenes.Game.ToString())
                {
                    SetCurrentGameLevelMusic(_levelData);
                    _audioSource.Stop();
                    _audioSource.clip = audioData.currentGameMusic;
                    _audioSource.Play();
                }
            }
        }  
    }

    void SetCurrentGameLevelMusic(LevelData levelData)
    {
        switch (levelData.currentLevel)
        {
            case LevelData.Levels.Level1:
                audioData.currentGameMusic = audioData.level1GameMusic;
                break;
            case LevelData.Levels.Level2:
                audioData.currentGameMusic = audioData.level2GameMusic;
                break;
            case LevelData.Levels.Level3:
                audioData.currentGameMusic = audioData.level3GameMusic;
                break;
            case LevelData.Levels.Level4:
                audioData.currentGameMusic = audioData.level4GameMusic;
                break;
            case LevelData.Levels.Level5:
                audioData.currentGameMusic = audioData.level5GameMusic;
                break;
            case LevelData.Levels.Level6:
                audioData.currentGameMusic = audioData.level6GameMusic;
                break;
            case LevelData.Levels.Level7:
                audioData.currentGameMusic = audioData.level7GameMusic;
                break;
            case LevelData.Levels.Level8:
                audioData.currentGameMusic = audioData.level8GameMusic;
                break;
            case LevelData.Levels.Level9:
                audioData.currentGameMusic = audioData.level9GameMusic;
                break;
            case LevelData.Levels.Level10:
                audioData.currentGameMusic = audioData.level10GameMusic;
                break;
        }
            

    }
    public enum ExposedParameters
    {
        MusicVolume,
        PlayerSFXVolume,
        EnemySFXVolume,
        MenuSFXVolume
    }
    void LoadVolume()
    {
        float _musicVolume = PlayerPrefs.GetFloat(ExposedParameters.MusicVolume.ToString(), 0f);
        float _playerSfxVolume = PlayerPrefs.GetFloat(ExposedParameters.PlayerSFXVolume.ToString(), 1f);
        float _enemySFXVolume = PlayerPrefs.GetFloat(ExposedParameters.EnemySFXVolume.ToString(), 1f);
        float _menuSFXVolume = PlayerPrefs.GetFloat(ExposedParameters.MenuSFXVolume.ToString(), 1f);

        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.MusicVolume.ToString(), Mathf.Log10(_musicVolume)*20f);
        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.PlayerSFXVolume.ToString(), Mathf.Log10(_playerSfxVolume)*20);
        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.EnemySFXVolume.ToString(), Mathf.Log10(_enemySFXVolume)*20f);
        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.MenuSFXVolume.ToString(), Mathf.Log10(_menuSFXVolume)*20f);
    }
}
