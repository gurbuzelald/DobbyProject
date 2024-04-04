using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : AbstractPlayer<ScoreController>
{
    public TextMeshProUGUI _scoreText;
    private TextMeshProUGUI avaliableCoinText;
    public static int _scoreAmount;
    private bool _scored;
    [SerializeField] PlayerCoinData playerCoinData;

    private JsonReadAndWriteSystem readWrite;
    void Start()
    {
        if (GameObject.Find("AvaliableCoinTextValue"))
        {
            avaliableCoinText = GameObject.Find("AvaliableCoinTextValue").transform.GetComponent<TextMeshProUGUI>();
        }           
        readWrite = FindObjectOfType<JsonReadAndWriteSystem>();
        
        if (SceneController.GetInstance.CheckSceneName() != SceneController.Scenes.CharacterChoose.ToString() ||
            SceneController.GetInstance.CheckSceneName() != SceneController.Scenes.WeaponChoose.ToString())
        {
            _scoreText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
        }
    }
    void Update()
    {
        if (avaliableCoinText)
        {
            avaliableCoinText.text = playerCoinData.avaliableCoin.ToString();
        }
        readWrite.SaveCoinToJson();

        //Debug.Log(playerCoinData.avaliableCoin);
        if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Menu.ToString() ||
            SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.CharacterChoose.ToString() ||
            SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.End.ToString() ||
            SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Win.ToString())
        {
            _scoreAmount = 0;
            PlayerPrefs.SetInt("ScoreAmount", 0);
        }
        else if (SceneController.playAgain)
        {
            playerCoinData.avaliableCoin -= PlayerPrefs.GetInt("ScoreAmount");
            //Buraya PlayerCoinData koyulacak. (Json i?in)

            _scoreAmount = 0;
            PlayerPrefs.SetInt("ScoreAmount", 0);
            SceneController.playAgain = false;
        }
        else
        {
            if (_scored)
            {
                _scored = false;
            }
        }
        _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
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
