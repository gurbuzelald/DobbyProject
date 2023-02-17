using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstractSlaveController<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }
            return _instance;
        }

    }
    public virtual IEnumerator DelaySwording(GameObject destroyObject, SlaveData slaveData, float delaySwordFalse, float delayDestroying)
    {
        yield return new WaitForSeconds(delaySwordFalse);
        slaveData.isSwording = false;
        yield return new WaitForSeconds(delayDestroying);
        Destroy(destroyObject);
    }
    public virtual IEnumerator DelayLookAt(GameObject lookObject,Transform randomTarget, float delay)
    {
        yield return new WaitForSeconds(delay);
        lookObject.transform.LookAt(randomTarget.position);
    }
}
