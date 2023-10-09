using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTeleporter : MonoBehaviour
{
    [SerializeField] GameObject[] _mirrorObjects;
    [SerializeField] PlayerData _playerData;
    [SerializeField] LevelData levelData;
    void Update()
    {
        if (MirrorController.triggerMirror)
        {
            //Debug.Log(_playerData.currentMirrorName);
            if (levelData.currentMirrorName == "Mirror1")
            {
                GameObject triggerMirrorObject = GameObject.Find("Mirror2");
                PlayerManager.GetInstance.gameObject.transform.position = triggerMirrorObject.transform.GetChild(0).transform.position;
                MirrorController.triggerMirror = false;
            }
            if (levelData.currentMirrorName == "Mirror2")
            {
                GameObject triggerMirrorObject = GameObject.Find("Mirror1");
                PlayerManager.GetInstance.gameObject.transform.position = triggerMirrorObject.transform.GetChild(0).transform.position;
                MirrorController.triggerMirror = false;
            }
        }
    }
}
