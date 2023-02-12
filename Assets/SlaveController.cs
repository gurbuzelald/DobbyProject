using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlaveController : AbstractSlaveController<SlaveController>
{
    public Transform randomTarget;
    public SlaveData slaveData;
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
            slaveData.isFiring = true;
        }
    }
    void Update()
    {
        if (PlayerManager.GetInstance._zValue < 0 || PlayerManager.GetInstance._zValue > 0)
        {
            gameObject.transform.Translate(0f, 0f, slaveData.slaveSpeed * Time.deltaTime);
            gameObject.transform.LookAt(randomTarget.position);
            slaveData.isFiring = false;
        }
        if (slaveData.isFiring)
        {
            StartCoroutine(DelayFiring());
        }

    }
    IEnumerator DelayFiring()
    {
        yield return new WaitForSeconds(2f);
        slaveData.isFiring = false;
    }

}
