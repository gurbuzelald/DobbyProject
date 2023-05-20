using System;
using System.IO;
using UnityEngine;
 
public class JsonReadAndWriteSystem : MonoBehaviour
{
    public PlayerCoinData playerCoinData;
 
    public void SaveToJson()
    {
        playerCoinData.avaliableCoinJson = playerCoinData.avaliableCoin.ToString();


        string json = JsonUtility.ToJson(playerCoinData, true);
        File.WriteAllText(Application.dataPath + "/PlayerCoinDataFile.json", json);
    }
 
    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/PlayerCoinDataFile.json");

        PlayerCoinData data = JsonUtility.FromJson<PlayerCoinData>(json);
        playerCoinData.avaliableCoin = data.avaliableCoin;
    }
}