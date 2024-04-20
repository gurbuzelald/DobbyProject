using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : AbstractPlayer<AudioManager>
{
    [Header("Data")]
    public AudioData audioData;

    [Header("Audio Components")]
    public AudioMixer _audiomixer;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        SetStartMusic();
        LoadVolume();   
    }
    void SetStartMusic()
    {
        _audioSource = GetComponent<AudioSource>();
        if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            _audioSource.clip = audioData.menuMusic;
        }
        else if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.End.ToString())
        {
            _audioSource.clip = audioData.endMusic;
        }
        else if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Win.ToString())
        {
            _audioSource.clip = audioData.winMusic;
        }
        else
        {
            _audioSource.clip = audioData.gameMusic;
        }
        _audioSource.Play();
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
