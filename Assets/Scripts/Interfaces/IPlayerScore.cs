using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IPlayerScore
{
    void DecreaseScore(int scoreDamageValue);
    void IncreaseScore(int scoreDamageValue);
    void ScoreTextGrowing(int r, int g, int b);
    void DelayScoreSizeBack();
}
