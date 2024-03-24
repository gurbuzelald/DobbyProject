using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy<T> : MonoBehaviour where T : MonoBehaviour
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
    public virtual void Movement(Transform targetObject, Transform initTransform, Transform currentTransform, float speed, PlayerData playerData, EnemyData enemyData)
    {

        if (targetObject != null && playerData.isPlayable)
        {
            currentTransform.LookAt(targetObject.position);
            currentTransform.Translate(0f, 0f, speed * Time.deltaTime);
        }
        else if (targetObject != null && playerData.isPlayable)
        {
            //currentTransform.LookAt(targetObject.position);
            //currentTransform.Translate(0f, 0f, (speed * Time.deltaTime) / 2f);
            //if (Vector3.Distance(initTransform.position, currentTransform.position) > 1f)
            //{
            //    speed *= -1;
            //}
            //currentTransform.Translate(0f, 0f, speed * Time.deltaTime);
        }
        /*if (!enemyData.isSpeedZero)
        {
            if (targetObject != null && playerData.isPlayable)
            {
                currentTransform.LookAt(targetObject.position);
                currentTransform.Translate(0f, 0f, speed * Time.deltaTime);
            }
            else if (targetObject != null && playerData.isPlayable)
            {
                //currentTransform.Translate(0f, 0f, (speed * Time.deltaTime) / 2f);
                //if (Vector3.Distance(initTransform.position, currentTransform.position) > 1f)
                //{
                //    speed *= -1;
                //}
                //currentTransform.Translate(0f, 0f, speed * Time.deltaTime);
            }
        }
        
        else if (!playerData.isPlayable || enemyData.isSpeedZero)
        {
            //currentTransform.Translate(0f, 0f, 0f);
        }*/
    }

}
