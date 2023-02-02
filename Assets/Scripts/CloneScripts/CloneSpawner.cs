using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{ 
    public PlayerData cloneData;
    public PlayerData playerData;

    public CanvasGroup firstTargetCanvas;
    public CanvasGroup secondTargetCanvas;
    public CanvasGroup thirdTargetCanvas;
    public CanvasGroup finishTargetCanvas;

    private void Awake()
    {
        InitialCanvasGroups();
        CreateCloneObject();
    }
    void InitialCanvasGroups()
    {
        firstTargetCanvas.alpha = 0.25f;
        secondTargetCanvas.alpha = 0.25f;
        thirdTargetCanvas.alpha = 0.25f;
        finishTargetCanvas.alpha = 0.25f;
    }
    void CreateCloneObject()
    {
        for (int i = 0; i < cloneData.cloneTransforms.Length; i++)
        {
            GameObject obj = Instantiate(cloneData.cloneObjects[i],
                                         cloneData.cloneTransforms[i].position,
                                         Quaternion.identity,
                                         gameObject.transform);
            obj.transform.position = cloneData.cloneTransforms[0].position;

            //Debug.Log(obj.transform.position);
        }
    }
}
