using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private NavMeshAgent _navmeshAgent;
    [SerializeField] Transform _targetObject;
    [SerializeField] float _cloneSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(_targetObject.position);
        gameObject.transform.Translate(0f, 0f, _cloneSpeed * Time.deltaTime);
    }
}
