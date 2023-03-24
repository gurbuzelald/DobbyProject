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

    void Awake()
    {
        cloneSpawner = FindObjectOfType<CloneSpawner>();
        cloneSpawner.cloneData.currentTarget.position = cloneSpawner.cloneData.firstTarget.position;

        if (cloneSpawner.cloneData != null)
        {
            cloneSpawner.cloneData.particleCount = 0;
            cloneSpawner.cloneData.isCloneDancing = false;
            cloneSpawner.cloneData.isTouchFirst = true;
            cloneSpawner.cloneData.isTouchSecond = false;
        }
        cloneSpawner.cloneData.currentTarget.position = cloneSpawner.cloneData.firstTarget.position;

        _navmeshAgent = GetComponent<NavMeshAgent>();
        if (_navmeshAgent != null)
        {
            _navmeshAgent.speed = cloneSpawner.cloneData.cloneSpeed;
        }
    }
    void Update()
    {
        //Debug.Log(Vector3.Distance(gameObject.transform.position, _firstTarget.position));
        if (SceneController.playAgain == true)
        {
            Debug.Log("Test");
            //cloneSpawner.cloneData.currentTarget.position = cloneSpawner.cloneData.firstTarget.position;
        }
        OnTarget();
        DeadManage();
        CloneDestinationStates();

    }
    void CloneDestinationStates()
    {
        if (cloneSpawner.cloneData.isTouchFirst)
        {
            cloneSpawner.cloneData.currentTarget.position = cloneSpawner.cloneData.firstTarget.position;
        }
        if (cloneSpawner.cloneData.isTouchSecond)
        {
            cloneSpawner.cloneData.currentTarget.position = cloneSpawner.cloneData.secondTarget.position;

            _navmeshAgent.destination = new Vector3(cloneSpawner.cloneData.currentTarget.position.x, cloneSpawner.cloneData.currentTarget.position.y, cloneSpawner.cloneData.currentTarget.position.z);
        }
        if (cloneSpawner.cloneData.isTouchThird)
        {
            cloneSpawner.cloneData.currentTarget.position = cloneSpawner.cloneData.thirdTarget.position;

            _navmeshAgent.destination = new Vector3(cloneSpawner.cloneData.currentTarget.position.x, cloneSpawner.cloneData.currentTarget.position.y, cloneSpawner.cloneData.currentTarget.position.z);
        }
        if (cloneSpawner.cloneData.isTouchFinish)
        {
            cloneSpawner.cloneData.currentTarget.position = cloneSpawner.cloneData.finishTarget.position;

            _navmeshAgent.destination = new Vector3(cloneSpawner.cloneData.currentTarget.position.x, cloneSpawner.cloneData.currentTarget.position.y, cloneSpawner.cloneData.currentTarget.position.z);
        }
        _navmeshAgent.destination = cloneSpawner.cloneData.currentTarget.position;
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
        if (Vector3.Distance(gameObject.transform.position, cloneSpawner.cloneData.firstTarget.position) < 0.6f)
        {
            cloneSpawner.cloneData.isTouchFirst = false;
            cloneSpawner.cloneData.isTouchSecond = true;
            cloneSpawner.cloneData.isTouchThird = false;
            cloneSpawner.cloneData.isTouchFinish = false;


            cloneSpawner.firstTargetCanvas.alpha = 1;
        }
        if (Vector3.Distance(gameObject.transform.position, cloneSpawner.cloneData.secondTarget.position) < 0.6f)
        {
            cloneSpawner.cloneData.isTouchFirst = false;
            cloneSpawner.cloneData.isTouchSecond = false;
            cloneSpawner.cloneData.isTouchThird = true;
            cloneSpawner.cloneData.isTouchFinish = false;

            cloneSpawner.secondTargetCanvas.alpha = 1;
        }
        if (Vector3.Distance(gameObject.transform.position, cloneSpawner.cloneData.thirdTarget.position) < 0.6f)
        {
            cloneSpawner.cloneData.isTouchFirst = false;
            cloneSpawner.cloneData.isTouchSecond = false;
            cloneSpawner.cloneData.isTouchThird = false;
            cloneSpawner.cloneData.isTouchFinish = true;

            cloneSpawner.thirdTargetCanvas.alpha = 1;
        }
        if (Vector3.Distance(gameObject.transform.position, cloneSpawner.cloneData.finishTarget.position) < 0.6f || cloneSpawner.playerData.isLose)
        {
            cloneSpawner.cloneData.isTouchFirst = false;
            cloneSpawner.cloneData.isTouchSecond = false;
            cloneSpawner.cloneData.isTouchThird = false;
            cloneSpawner.playerData.isDying = true;

            cloneSpawner.finishTargetCanvas.alpha = 1;

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
