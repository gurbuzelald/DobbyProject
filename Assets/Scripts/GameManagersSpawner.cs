using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManagersSpawner : MonoBehaviour
{
    [SerializeField] GameObject audioListener;
    [SerializeField] GameObject particleController;

    void Awake()
    {
        Instantiate(audioListener, gameObject.transform);
        Instantiate(particleController, gameObject.transform);
    }
}
