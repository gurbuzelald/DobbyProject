using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : AbstractPlayer<ScoreController>
{
    public TextMeshProUGUI _scoreText;
    public TextMeshProUGUI avaliableCoinText;
    public static int _scoreAmount;
    private bool _scored;
    [SerializeField] PlayerCoinData playerCoinData;
    void Start()
    {
        if (SceneController.GetInstance.CheckSceneName() != SceneController.Scenes.CharacterChoose.ToString())
        {
            _scoreText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
        }
    }
    void Update()
    {
        avaliableCoinText.text = playerCoinData.avaliableCoin.ToString();

        //Debug.Log(playerCoinData.avaliableCoin);
        if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            _scoreAmount = 0;
            PlayerPrefs.SetInt("ScoreAmount", 0);
            _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
        }
        else if (SceneController.playAgain)
        {
            _scoreAmount = 0;
            PlayerPrefs.SetInt("ScoreAmount", 0);
            _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
            SceneController.playAgain = false;
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
        playerCoinData.avaliableCoin += scoreAmount;
        avaliableCoinText.text = playerCoinData.avaliableCoin.ToString();
        return _scoreAmount;
    }
}
