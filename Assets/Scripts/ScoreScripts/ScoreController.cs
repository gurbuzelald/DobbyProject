using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : AbstractPlayer<ScoreController>
{
    public TextMeshProUGUI _scoreText;
    private TextMeshProUGUI avaliableCoinText;
    private TextMeshProUGUI enemyKillValueText;
    public static int _scoreAmount;
    private bool _scored;
    [SerializeField] PlayerCoinData playerCoinData;
    private JsonReadAndWriteSystem readWrite;

    private LevelUpController levelUpController;



    void Start()
    {
        if (GameObject.Find("LevelUpController"))
        {
            levelUpController = GameObject.Find("LevelUpController").GetComponent<LevelUpController>();
        }

        if (playerCoinData.avaliableCoin < 0)
        {
            playerCoinData.avaliableCoin = 0;
        }
        if (GameObject.Find("AvaliableCoinTextValue"))
        {
            avaliableCoinText = GameObject.Find("AvaliableCoinTextValue").transform.GetComponent<TextMeshProUGUI>();
        }
        if (GameObject.Find("EnemyKillValueText"))
        {
            enemyKillValueText = GameObject.Find("EnemyKillValueText").transform.GetComponent<TextMeshProUGUI>();
        }
        readWrite = FindObjectOfType<JsonReadAndWriteSystem>();
        
        
    }
    private void OnEnable()
    {

        if (gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>())
        {
            if (SceneController.GetInstance.CheckSceneName() != SceneController.Scenes.PickCharacter.ToString() ||
             SceneController.GetInstance.CheckSceneName() != SceneController.Scenes.PickWeapon.ToString())
            {

                _scoreText = gameObject.transform.GetChild(0).gameObject.transform.GetComponent<TextMeshProUGUI>();
                if (levelUpController)
                {
                    _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString() + "/" +
                                  levelUpController.levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount;
                }
                else
                {
                    _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
                }
                
            }
        }
        
    }
    void Update()
    {
        if (avaliableCoinText)
        {
            avaliableCoinText.text = playerCoinData.avaliableCoin.ToString();
        }
        if (enemyKillValueText)
        {
            enemyKillValueText.text = EnemyData.enemyDeathCount.ToString() + "/" +
                                     levelUpController.levelUpRequirements[LevelData.currentLevelUpRequirement].enemyKills; ;
        }
        readWrite.SaveCoinToJson();

        //Debug.Log(playerCoinData.avaliableCoin);
        if (SceneController.GetInstance.CheckSceneName() == SceneController.Scenes.Menu.ToString())
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
        if (levelUpController)
        {
            _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString() + "/" +
                          levelUpController.levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount;
        }
        else
        {
            _scoreText.text = PlayerPrefs.GetInt("ScoreAmount").ToString();
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

    public void SetScoreWithLevelUp()
    {
        PlayerPrefs.SetInt("ScoreAmount", 0);
    }
}
