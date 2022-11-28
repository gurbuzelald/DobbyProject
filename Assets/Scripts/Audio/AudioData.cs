using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioMusicData", menuName = "AudioMusicData")]
public class AudioData : ScriptableObject
{
    public AudioClip gameMusic;
    public AudioClip menuMusic;
    public AudioClip endMusic;    
}
