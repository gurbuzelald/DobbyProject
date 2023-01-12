using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CloneManager : MonoBehaviour
{
    [Header("Data")]
    public PlayerData cloneData;
    public PlayerData playerData;

    [Header("Navmesh")]
    private NavMeshAgent _navmeshAgent;

    [Header("Destination Transform")]
    private CloneSpawner cloneSpawner;

    void Start()
    {
        cloneSpawner = FindObjectOfType<CloneSpawner>();
        if (cloneData != null)
        {
            cloneData.particleCount = 0;
            cloneData.isCloneDancing = false;
            cloneData.isTouchFirst = true;
            cloneData.isTouchMain = false;
        }
        cloneSpawner._currentTarget.position = cloneSpawner._firstTarget.position;

        _navmeshAgent = GetComponent<NavMeshAgent>();
        if (_navmeshAgent != null)
        {
            _navmeshAgent.speed = cloneData.cloneSpeed;
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
        if (cloneData.isTouchFirst)
        {
            cloneSpawner._currentTarget.position = cloneSpawner._firstTarget.position;
        }
        if (cloneData.isTouchMain)
        {
            cloneSpawner._currentTarget.position = cloneSpawner._secondTarget.position;

            _navmeshAgent.destination = new Vector3(cloneSpawner._currentTarget.position.x, cloneSpawner._currentTarget.position.y, cloneSpawner._currentTarget.position.z);
        }
        _navmeshAgent.destination = cloneSpawner._currentTarget.position;
    }
    void DeadManage()
    {
        if (playerData.isTouchFinish && cloneData.particleCount == 0)
        {
            cloneData.particleCount++;
            _navmeshAgent.speed = 0;
            cloneData.isCloneDying = true;
            cloneData.isCloneWalking = false;
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, gameObject.transform);
            Destroy(gameObject, 3f);
        }
        else if(!playerData.isTouchFinish && cloneData.particleCount == 0)
        {
            _navmeshAgent.speed = cloneData.cloneSpeed;
        }
    }
    public void OnTarget()
    {
        if (Vector3.Distance(gameObject.transform.position, cloneSpawner._firstTarget.position) < 0.6f)
        {
            cloneData.isTouchFirst = false;
            cloneData.isTouchMain = true;
        }
        if (Vector3.Distance(gameObject.transform.position, cloneSpawner._secondTarget.position) < 0.6f || playerData.isLose)
        {
            cloneData.isTouchFirst = false;
            cloneData.isTouchMain = false;

            _navmeshAgent.speed = 0;

            cloneData.isCloneDancing = true;
            cloneData.isCloneWalking = false;

            playerData.isPlayable = false;
            StartCoroutine(DelayLoadMenu());
        }
    }
    IEnumerator DelayLoadMenu()
    {
        if (cloneData.particleCount == 0)
        {
            cloneData.particleCount++;
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, PlayerManager.GetInstance.gameObject.transform);
        }
        yield return new WaitForSeconds(4f);
        SceneController.GetInstance.LoadMenuScene();
    }
}
