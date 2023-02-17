using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveController : AbstractSlaveController<SlaveController>
{
    public Transform randomTarget;
    public SlaveData slaveData;
    public PlayerData playerData;
    public int slaveTransformValue;

    private void Start()
    {
        slaveTransformValue = UnityEngine.Random.Range(0, PlayerManager.GetInstance._slaveTransforms.Length);
        slaveData.slaveSpeed = UnityEngine.Random.Range(1.95f, 2);

        //Debug.Log(slaveTransformValue);

        for (int i = 0; i < PlayerManager.GetInstance._slaveTransforms.Length; i++)
        {
            randomTarget = PlayerManager.GetInstance._slaveTransforms[slaveTransformValue];
        }
        //TargetTransform(randomTarget, slaveTransformValue);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Gameobject is going too down some times, this code solve that stuation.
        if (playerData.isGround)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    PlayerManager.GetInstance.gameObject.transform.position.y,
                                                    gameObject.transform.position.z);
        }        


        if (other.CompareTag(SceneController.Tags.EnemyBullet.ToString()) || other.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
           // Destroy(gameObject);
        }
        if (other.CompareTag(SceneController.Tags.EnemyBullet.ToString()))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag(SceneController.Tags.Enemy.ToString())) 
        {
            randomTarget.position = other.gameObject.transform.position;
            slaveData.isSwording = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            randomTarget = PlayerManager.GetInstance._slaveTransforms[slaveTransformValue];
            slaveData.isSwording = false;
        }
    }
    void Update()
    {
        if (playerData.isWalking ||playerData.isBackWalking || playerData.isLockedWalking)
        {//Walk and LookAt Function
            SlaveWalking();
            StartCoroutine(DelayLookAt(gameObject, randomTarget, slaveData.delayLookAt));
        }
        else if (slaveData.isSwording)
        {//Swording
            StartCoroutine(DelaySwording(gameObject, slaveData, 2f, 3f));
        }//Firing and Swording can not able go together

    }
    void SlaveWalking()
    {
        gameObject.transform.Translate(0f, 0f, slaveData.slaveSpeed * Time.deltaTime);
        slaveData.isSwording = false;//If player is walking, slave can not able fire
    }   
}
