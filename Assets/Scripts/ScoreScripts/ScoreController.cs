using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : AbstractPlayer<ScoreController>
{
    public TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI avaliableCoinText;
    [SerializeField] TextMeshProUGUI enemyKillValueText;
    public static int _scoreAmount;
    private bool _scored;
    [SerializeField] PlayerCoinData playerCoinData;
    private JsonReadAndWriteSystem readWrite;

    private LevelUpController levelUpController;



    void Start()
    {
        readWrite = FindObjectOfType<JsonReadAndWriteSystem>();

        playerCoinData.avaliableCoin = PlayerPrefs.GetInt("AvaliableCoin");

        avaliableCoinText.text = playerCoinData.avaliableCoin.ToString();

        _scoreAmount = 0;

        if (_scoreText)
        {
            _scoreText.text = _scoreAmount.ToString();
        }        

        if (GameObject.Find("LevelUpController"))
        {
            levelUpController = GameObject.Find("LevelUpController").GetComponent<LevelUpController>();
        }

        if (playerCoinData.avaliableCoin < 0)
        {
            playerCoinData.avaliableCoin = 0;
        }
    }
    private void OnEnable()
    {

        if (gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>())
        {
            if (SceneController.CheckSceneName() != SceneController.Scenes.PickCharacter.ToString() ||
             SceneController.CheckSceneName() != SceneController.Scenes.PickWeapon.ToString())
            {
                if (levelUpController && _scoreText)
                {
                    _scoreText.text = _scoreAmount + "/" +
                                  levelUpController.levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount;
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
        if (enemyKillValueText && levelUpController)
        {
            enemyKillValueText.text = EnemyData.enemyDeathCount.ToString() + "/" +
                                     levelUpController.levelUpRequirements[LevelData.currentLevelUpRequirement].enemyKills;
        }
        readWrite.SaveCoinToJson();

        //Debug.Log(playerCoinData.avaliableCoin);
        if (SceneController.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            //_scoreAmount = 0;
            //PlayerPrefs.SetInt("ScoreAmount", 0);
        }
        else if (SceneController.playAgain)
        {
            playerCoinData.avaliableCoin -= _scoreAmount;
            //Buraya PlayerCoinData koyulacak. (Json icin)

            _scoreAmount = 0;
            if (_scoreText && levelUpController)
            {
                _scoreText.text = _scoreAmount + "/" +
                          levelUpController.levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount;
            }
            
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
        if (levelUpController && _scoreText)
        {
            _scoreText.text = _scoreAmount + "/" +
                          levelUpController.levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount;
        }
    }
    public int SetScore(int scoreAmount)
    {
        _scored = true;
        _scoreAmount += scoreAmount;
        playerCoinData.avaliableCoin += scoreAmount;

        PlayerPrefs.SetInt("ScoreAmount", _scoreAmount);
        PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

        if (avaliableCoinText
)
        {
            avaliableCoinText.text = playerCoinData.avaliableCoin.ToString();
        }

        if (levelUpController && _scoreText)
        {
            _scoreText.text = _scoreAmount + "/" +
                          levelUpController.levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount;
        }

        return _scoreAmount;
    }

    public void SetScoreWithLevelUp()
    {
        PlayerPrefs.SetInt("ScoreAmount", 0);
    }
}
