using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    private NavMeshAgent _navmeshAgent;
    [SerializeField] Transform _targetObject;
    // Start is called before the first frame update
    void Start()
    {
        _navmeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _navmeshAgent.SetDestination(_targetObject.position);
    }
}
