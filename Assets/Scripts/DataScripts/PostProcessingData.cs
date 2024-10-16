using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[CreateAssetMenu(fileName = "NewPostProcessingData", menuName = "PostProcessingData")]
public class PostProcessingData : ScriptableObject
{
    public PostProcessProfile[] postProcessingObjects;
}
