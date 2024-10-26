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
    [SerializeField] LevelData levelData;

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
                    _scoreText.text = $"{_scoreAmount}/{levelData.levelUpRequirements[LevelData.currentLevelId].coinCollectAmount}";
                }
            }
        }
        
    }
    void Update()
    {
        // Update available coin text if the text component exists
        if (avaliableCoinText)
        {
            avaliableCoinText.text = playerCoinData.avaliableCoin.ToString();
        }

        // Update enemy kill value text if both components exist
        if (enemyKillValueText && levelUpController)
        {
            enemyKillValueText.text = $"{EnemyData.enemyDeathCount}/{levelData.levelUpRequirements[LevelData.currentLevelId].enemyKills}";
        }

        // Save coin data to JSON
        readWrite.SaveCoinToJson();

        // Check for scene-specific logic
        if (SceneController.CheckSceneName() == SceneController.Scenes.Menu.ToString())
        {
            // Optional: Reset score if needed, these lines are commented
            _scoreAmount = 0;
            PlayerPrefs.SetInt("ScoreAmount", 0);
        }
        else if (SceneController.playAgainForScore)
        {
            playerCoinData.avaliableCoin -= _scoreAmount; // Deduct score amount from available coin
            _scoreAmount = 0;

            // Update score text if the text component and level controller exist
            if (_scoreText && levelUpController)
            {
                _scoreText.text = $"0/{levelData.levelUpRequirements[LevelData.currentLevelId].coinCollectAmount}";
            }

            PlayerPrefs.SetInt("ScoreAmount", 0); // Reset score in PlayerPrefs
            SceneController.playAgainForScore = false; // Reset playAgain flag
        }

        // Reset scored flag if necessary
        if (_scored)
        {
            _scored = false;
        }

        // Update score text if both components exist
        if (_scoreText && levelUpController)
        {
            _scoreText.text = $"{_scoreAmount}/{levelData.levelUpRequirements[LevelData.currentLevelId].coinCollectAmount}";
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
                          levelData.levelUpRequirements[LevelData.currentLevelId].coinCollectAmount;
        }

        return _scoreAmount;
    }

    public void SetScoreWithLevelUp()
    {
        PlayerPrefs.SetInt("ScoreAmount", 0);
    }
}
