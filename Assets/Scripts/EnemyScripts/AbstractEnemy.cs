using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy<T> : MonoBehaviour where T : MonoBehaviour
{
    public virtual void Movement(Transform targetObject, Transform initTransform, Transform currentTransform, bool isActivateMagnet, float speed)
    {
        if (targetObject != null && isActivateMagnet)
        {
            currentTransform.LookAt(targetObject.position);
            currentTransform.Translate(0f, 0f, speed * Time.deltaTime);
        }
        else if (targetObject != null && !isActivateMagnet)
        {
            currentTransform.Translate(0f, 0f, (speed * Time.deltaTime)/2f);
            //if (Vector3.Distance(initTransform.position, currentTransform.position) > 1f)
            //{
            //    speed *= -1;
            //}
            //currentTransform.Translate(0f, 0f, speed * Time.deltaTime);
        }
    }

}
