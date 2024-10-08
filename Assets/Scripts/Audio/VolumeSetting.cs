using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
    [Header("Audio Components")]
    [SerializeField] AudioMixer _audioMixer;

    [Header("Sliders")]
    [SerializeField] Slider _playerSFXSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _enemySFXSliderVolume;
    [SerializeField] Slider _menuSFXSliderVolume;

    private void OnEnable()
    {
        _musicSlider.value = PlayerPrefs.GetFloat(AudioManager.ExposedParameters.MusicVolume.ToString(), 1f);
        _playerSFXSlider.value = PlayerPrefs.GetFloat(AudioManager.ExposedParameters.PlayerSFXVolume.ToString(), 1f);
        _enemySFXSliderVolume.value = PlayerPrefs.GetFloat(AudioManager.ExposedParameters.EnemySFXVolume.ToString(), 1f);
        _menuSFXSliderVolume.value = PlayerPrefs.GetFloat(AudioManager.ExposedParameters.MenuSFXVolume.ToString(), 1f);
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.ExposedParameters.MusicVolume.ToString(), _musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.ExposedParameters.PlayerSFXVolume.ToString(), _playerSFXSlider.value);
        PlayerPrefs.SetFloat(AudioManager.ExposedParameters.EnemySFXVolume.ToString(), _enemySFXSliderVolume.value);
        PlayerPrefs.SetFloat(AudioManager.ExposedParameters.MenuSFXVolume.ToString(), _menuSFXSliderVolume.value);
    }
    private void Update()
    {
        SetMusicVolume(_musicSlider.value);
        SetPlayerSFXVolume(_playerSFXSlider.value);
        SetEnemySFXVolume(_enemySFXSliderVolume.value);
        SetMenuSFXVolume(_menuSFXSliderVolume.value);
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
    public void SetMenuSFXVolume(float volume)
    {
        _audioMixer.SetFloat(ExposedParameters.MenuSFXVolume.ToString(), Mathf.Log10(volume) * 20);
    }

    public enum ExposedParameters
    {
        MusicVolume,
        PlayerSFXVolume,
        EnemySFXVolume,
        MenuSFXVolume
    }
}
