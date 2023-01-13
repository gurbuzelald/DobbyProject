using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloneManager : MonoBehaviour
{
    [Header("Navmesh")]
    private NavMeshAgent _navmeshAgent;

    [Header("Destination Transform")]
    private CloneSpawner cloneSpawner;

    void Start()
    {
        cloneSpawner = FindObjectOfType<CloneSpawner>();
        if (cloneSpawner.cloneData != null)
        {
            cloneSpawner.cloneData.particleCount = 0;
            cloneSpawner.cloneData.isCloneDancing = false;
            cloneSpawner.cloneData.isTouchFirst = true;
            cloneSpawner.cloneData.isTouchMain = false;
        }
        cloneSpawner._currentTarget.position = cloneSpawner._firstTarget.position;

        _navmeshAgent = GetComponent<NavMeshAgent>();
        if (_navmeshAgent != null)
        {
            _navmeshAgent.speed = cloneSpawner.cloneData.cloneSpeed;
        }
    }
    void Update()
    {
        //Debug.Log(Vector3.Distance(gameObject.transform.position, _firstTarget.position));

        OnTarget();
        DeadManage();
        DestinationStates();

    }
    void DestinationStates()
    {
        if (cloneSpawner.cloneData.isTouchFirst)
        {
            cloneSpawner._currentTarget.position = cloneSpawner._firstTarget.position;
        }
        if (cloneSpawner.cloneData.isTouchMain)
        {
            cloneSpawner._currentTarget.position = cloneSpawner._secondTarget.position;

            _navmeshAgent.destination = new Vector3(cloneSpawner._currentTarget.position.x, cloneSpawner._currentTarget.position.y, cloneSpawner._currentTarget.position.z);
        }
        _navmeshAgent.destination = cloneSpawner._currentTarget.position;
    }
    void DeadManage()
    {
        if (cloneSpawner.playerData.isTouchFinish && cloneSpawner.cloneData.particleCount == 0)
        {
            cloneSpawner.cloneData.particleCount++;
            _navmeshAgent.speed = 0;
            cloneSpawner.cloneData.isCloneDying = true;
            cloneSpawner.cloneData.isCloneWalking = false;
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, gameObject.transform);
            Destroy(gameObject, 3f);
        }
        else if(!cloneSpawner.playerData.isTouchFinish && cloneSpawner.cloneData.particleCount == 0)
        {
            _navmeshAgent.speed = cloneSpawner.cloneData.cloneSpeed;
        }
    }
    public void OnTarget()
    {
        if (Vector3.Distance(gameObject.transform.position, cloneSpawner._firstTarget.position) < 0.6f)
        {
            cloneSpawner.cloneData.isTouchFirst = false;
            cloneSpawner.cloneData.isTouchMain = true;
        }
        if (Vector3.Distance(gameObject.transform.position, cloneSpawner._secondTarget.position) < 0.6f || cloneSpawner.playerData.isLose)
        {
            cloneSpawner.cloneData.isTouchFirst = false;
            cloneSpawner.cloneData.isTouchMain = false;

            _navmeshAgent.speed = 0;

            cloneSpawner.cloneData.isCloneDancing = true;
            cloneSpawner.cloneData.isCloneWalking = false;

            cloneSpawner.playerData.isPlayable = false;
            StartCoroutine(DelayLoadMenu());
        }
    }
    IEnumerator DelayLoadMenu()
    {
        if (cloneSpawner.cloneData.particleCount == 0)
        {
            cloneSpawner.cloneData.particleCount++;
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, PlayerManager.GetInstance.gameObject.transform);
        }
        yield return new WaitForSeconds(4f);
        SceneController.GetInstance.LoadMenuScene();
    }
}
