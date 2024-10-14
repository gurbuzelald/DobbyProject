using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject[] lights;
    //[SerializeField] float delayLevelUpLight = 1.2f;

    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;
    private void Awake()
    {

        /*lights[0].SetActive(true);
        for (int i = 1; i < lights.Length; i++)
        {
            lights[i].SetActive(false);
        }*/
    }
    void Update()
    {
       // LevelUpLight(playerData, delayLevelUpLight);
    }
    void LevelUpLight(PlayerData playerData, float delayLevelUpLight)
    {
        if (levelData.isLevelUp && LevelData.levelCanBeSkipped)
        {
            lights[1].SetActive(true);//Dark Light isActivated
            lights[0].SetActive(false);
            StartCoroutine(DelayLevelUpLightOn(delayLevelUpLight));
        }
    }
    IEnumerator DelayLevelUpLightOn(float delayLevelUpLight)
    {
        yield return new WaitForSeconds(delayLevelUpLight);
        lights[1].SetActive(false);
        lights[0].SetActive(true);
        levelData.isLevelUp = false;
        LevelData.levelCanBeSkipped = false;
    }
}
