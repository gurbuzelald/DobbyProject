using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerCoinData", menuName = "Scriptable Objects/PlayerCoinData")]
[System.Serializable]
public class PlayerCoinData : ScriptableObject
{
    public int avaliableCoin;
    public string avaliableCoinJson;
}
