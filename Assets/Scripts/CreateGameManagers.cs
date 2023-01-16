using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateGameManagers : MonoBehaviour
{
    [SerializeField] GameObject navmeshSurface;
    [SerializeField] GameObject audioListener;
    [SerializeField] GameObject particleController;

    void Awake()
    {
        Instantiate(navmeshSurface, gameObject.transform);
        Instantiate(audioListener, gameObject.transform);
        Instantiate(particleController, gameObject.transform);
    }
}
