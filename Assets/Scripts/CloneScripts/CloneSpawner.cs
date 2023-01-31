using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    public Transform firstTarget;
    public Transform secondTarget;
    public Transform thirdTarget;
    public Transform finishTarget;
    public Transform currentTarget;

    public CanvasGroup firstTargetCanvas;
    public CanvasGroup secondTargetCanvas;
    public CanvasGroup thirdTargetCanvas;
    public CanvasGroup finishTargetCanvas;

    public PlayerData cloneData;
    public PlayerData playerData;

    private void Start()
    {
        firstTargetCanvas.alpha = 0.25f;
        secondTargetCanvas.alpha = 0.25f;
        thirdTargetCanvas.alpha = 0.25f;
        finishTargetCanvas.alpha = 0.25f;
        for (int i = 0; i < cloneData.cloneTransforms.Length; i++)
        {
            GameObject obj = Instantiate(cloneData.cloneObjects[i], 
                                         cloneData.cloneTransforms[i].position, 
                                         Quaternion.identity, 
                                         gameObject.transform);
            if (PlayerManager.GetInstance.gameObject != null)
            {
                obj.transform.position = PlayerManager.GetInstance.PlayerRandomSpawn(playerData).position;
            }
        }
    }
}
