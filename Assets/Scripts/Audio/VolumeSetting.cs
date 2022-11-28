using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] Slider _playerSFXSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _enemySFXVolume;

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat(AudioManager.ExposedParameters.MusicVolume.ToString(), 1f);
        _playerSFXSlider.value = PlayerPrefs.GetFloat(AudioManager.ExposedParameters.PlayerSFXVolume.ToString(), 1f);
        _enemySFXVolume.value = PlayerPrefs.GetFloat(AudioManager.ExposedParameters.EnemySFXVolume.ToString(), 1f);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.ExposedParameters.MusicVolume.ToString(), _musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.ExposedParameters.PlayerSFXVolume.ToString(), _playerSFXSlider.value);
        PlayerPrefs.SetFloat(AudioManager.ExposedParameters.EnemySFXVolume.ToString(), _enemySFXVolume.value);
    }
    private void Update()
    {
        SetMusicVolume(_musicSlider.value);
        SetPlayerSFXVolume(_playerSFXSlider.value);
        SetEnemySFXVolume(_enemySFXVolume.value);
    }
    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat(ExposedParameters.MusicVolume.ToString(), Mathf.Log10(volume) * 20);
    }
    public void SetPlayerSFXVolume(float volume)
    {
        _audioMixer.SetFloat(ExposedParameters.PlayerSFXVolume.ToString(), Mathf.Log10(volume)*20);
    }
    public void SetEnemySFXVolume(float volume)
    {
        _audioMixer.SetFloat(ExposedParameters.EnemySFXVolume.ToString(), Mathf.Log10(volume) * 20);
    }

    public enum ExposedParameters
    {
        MusicVolume,
        PlayerSFXVolume,
        EnemySFXVolume
    }
}
