using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : AbstractSingleton<ScoreController>
{
    public TextMeshProUGUI _scoreText;
    public static int _scoreAmount;
    private bool _scored;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
        //_scored = false;
        //_scoreText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneLoadController.GetInstance.CheckSceneName() == SceneLoadController.Scenes.Menu.ToString())
        {
            _scoreAmount = 0;
            PlayerPrefs.SetInt("ScoreAmount", 0);
            _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
        }
        else if (SceneLoadController.GetInstance.playAgain)
        {
            _scoreAmount = 0;
            PlayerPrefs.SetInt("ScoreAmount", 0);
            _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
        }
        else
        {
            if (_scored)
            {
                _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
                _scored = false;
            }
        }
    }
    public int SetScore(int scoreAmount)
    {
        _scored = true;
        _scoreAmount += scoreAmount;
        PlayerPrefs.SetInt("ScoreAmount", _scoreAmount);
        return _scoreAmount;
    }
}
