using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PostProcessingLevelController : MonoBehaviour
{
    [SerializeField] PostProcessingData postProcessingData;
    [SerializeField] LevelData levelData;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.GetComponent<PostProcessVolume>().profile = postProcessingData.postProcessingObjects[LevelData.currentLevelCount];
    }

    // Update is called once per frame
    void Update()
    {
        if (levelData.isLevelUp && LevelData.levelCanUp)
        {
            gameObject.transform.GetComponent<PostProcessVolume>().profile = postProcessingData.postProcessingObjects[LevelData.currentLevelCount];
        }
    }
}
