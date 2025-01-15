using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : AbstractPlayerSFX<AudioManager>
{
    [Header("Data")]
    public AudioData audioData;
    public LevelData _levelData;

    [Header("Audio Components")]
    public AudioMixer _audiomixer;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentMusic();
        LoadVolume();   
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
        for (int i = 0; i < levelData.levels.Length; i++)
        {
            if (levelData.currentLevelId == levelData.levels[i].id)
            {
                audioData.currentGameMusic = audioData.levelsGameMusic[i];
                return; // Exit once the matching level is found
            }
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
        float _musicVolume = PlayerPrefs.GetFloat(ExposedParameters.MusicVolume.ToString(), 1f);
        float _playerSfxVolume = PlayerPrefs.GetFloat(ExposedParameters.PlayerSFXVolume.ToString(), 1f);
        float _enemySFXVolume = PlayerPrefs.GetFloat(ExposedParameters.EnemySFXVolume.ToString(), 1f);
        float _menuSFXVolume = PlayerPrefs.GetFloat(ExposedParameters.MenuSFXVolume.ToString(), 1f);

        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.MusicVolume.ToString(), Mathf.Log10(_musicVolume)*20f);
        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.PlayerSFXVolume.ToString(), Mathf.Log10(_playerSfxVolume)*20);
        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.EnemySFXVolume.ToString(), Mathf.Log10(_enemySFXVolume)*20f);
        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.MenuSFXVolume.ToString(), Mathf.Log10(_menuSFXVolume)*20f);
    }
}
