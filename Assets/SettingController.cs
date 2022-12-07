using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingController : MonoBehaviour
{
    [SerializeField] RectTransform _musicSlader;
    [SerializeField] RectTransform _playerSFX;
    [SerializeField] RectTransform _enemySFX;

    private void Start()
    {
        _musicSlader.localScale = Vector3.zero;
        _playerSFX.localScale = Vector3.zero;
        _enemySFX.localScale = Vector3.zero;
    }
    public void OpenSettings()
    {
        if (_musicSlader.localScale.x == 0)
        {
            _musicSlader.localScale = Vector3.one;
            _playerSFX.localScale = Vector3.one;
            _enemySFX.localScale = Vector3.one;
        }
        else
        {
            _musicSlader.localScale = Vector3.zero;
            _playerSFX.localScale = Vector3.zero;
            _enemySFX.localScale = Vector3.zero;
        }
        
    }
}
