using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : AbstractSingleton<AudioManager>
{
    [Header("Data")]
    public AudioData _audioData;

    [Header("Audio Components")]
    public AudioMixer _audiomixer;
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            _audioSource.clip = _audioData.menuMusic;
        }
        else if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.End.ToString())
        {
            _audioSource.clip = _audioData.endMusic;
        }
        else
        {
            _audioSource.clip = _audioData.gameMusic;
        }
        _audioSource.Play();

        LoadVolume();   
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void GetPlayerSFX(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }
    public void GetEnemySFX(AudioClip audioClip)
    {
        _audioSource.PlayOneShot(audioClip);
    }

    public enum ExposedParameters
    {
        MusicVolume,
        PlayerSFXVolume,
        EnemySFXVolume
    }
    void LoadVolume()
    {
        float _musicVolume = PlayerPrefs.GetFloat(ExposedParameters.MusicVolume.ToString(), 0f);
        float _playerSfxVolume = PlayerPrefs.GetFloat(ExposedParameters.PlayerSFXVolume.ToString(), 1f);
        float _enemySFXVolume = PlayerPrefs.GetFloat(ExposedParameters.EnemySFXVolume.ToString(), 1f);

        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.MusicVolume.ToString(), Mathf.Log10(_musicVolume)*20f);
        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.PlayerSFXVolume.ToString(), Mathf.Log10(_playerSfxVolume)*20);
        _audiomixer.SetFloat(VolumeSetting.ExposedParameters.EnemySFXVolume.ToString(), Mathf.Log10(_enemySFXVolume)*20f);
    }
}
