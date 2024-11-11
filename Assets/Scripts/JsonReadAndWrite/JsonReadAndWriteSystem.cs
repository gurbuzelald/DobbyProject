using System;
using System.IO;
using UnityEngine;
 
public class JsonReadAndWriteSystem : MonoBehaviour
{
    public PlayerCoinData playerCoinData;
    public PlayerData playerData;

    private PlayerCoinData data;


    public void SaveCoinToJson()
    {
        playerCoinData.avaliableCoin = PlayerPrefs.GetInt("AvaliableCoin");

        playerCoinData.avaliableCoinJson = playerCoinData.avaliableCoin.ToString();


        string json = JsonUtility.ToJson(playerCoinData, true);
        File.WriteAllText(Application.dataPath + "/PlayerCoinDataFile.json", json);
    }
    public void SavePlayerDataToJson()
    {
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(Application.dataPath + "/PlayerDataFile.json", json);
    }

    public void LoadFromJson()
    {
        //string json = File.ReadAllText(Application.dataPath + "/PlayerCoinDataFile.json");

        /*if (json != null)
        {
            
        }*/
        //data = JsonUtility.FromJson<PlayerCoinData>(json);
        data = playerCoinData;
        if (data)
        {
            playerCoinData.avaliableCoin += Convert.ToInt32(playerCoinData.avaliableCoinJson);
        }

    }
}