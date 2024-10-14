using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManagersSpawner : MonoBehaviour
{
    [SerializeField] GameObject audioListener;
    [SerializeField] GameObject particleController;

    void Start()
    {
        if (audioListener)
        {
            Instantiate(audioListener, gameObject.transform);
        }

        if (particleController)
        {
            Instantiate(particleController, gameObject.transform);
        }
    }
}
