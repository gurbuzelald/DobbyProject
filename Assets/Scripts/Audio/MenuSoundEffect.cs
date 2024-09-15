using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundEffect : AbstractPlayerSFX<MenuSoundEffect>
{
    public PlayerData playerData;
    public AudioData menuAudioData;
    [HideInInspector]
    public AudioSource audioSource;

    private void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnDisable()
    {
        audioSource = null;
    }
    public void MenuSoundEffectStatement(MenuSoundEffectTypes menuSoundEffectType)
    {
        if (MenuSoundEffectTypes.MenuClick == menuSoundEffectType || MenuSoundEffectTypes.MenuNotClick == menuSoundEffectType)
        {
            MenuSFX(menuSoundEffectType, menuAudioData);
        }
    }
    public enum MenuSoundEffectTypes
    {
        MenuClick,
        MenuNotClick
    }
}
