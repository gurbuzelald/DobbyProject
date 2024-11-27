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

        if (targetObject != null && PlayerData.isPlayable)
        {
            currentTransform.LookAt(targetObject.position);
            currentTransform.Translate(0f, 0f, speed * Time.deltaTime);
        }
    }

}
