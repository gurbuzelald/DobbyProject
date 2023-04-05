using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    public static bool triggerMirror;
    private void Awake()
    {
        triggerMirror = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Player.ToString()))
        {
            triggerMirror = true;
            _playerData.currentMirrorName = gameObject.name;
        }
    }
}
