using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy<T> : MonoBehaviour where T : MonoBehaviour
{
    public virtual void Movement(Transform targetObject, Transform initTransform, bool isActivateMagnet, float speed)
    {
        if (targetObject != null && isActivateMagnet)
        {
            initTransform.LookAt(targetObject.position);
            initTransform.Translate(0f, 0f, speed * Time.deltaTime);
        }
        else if (targetObject != null && !isActivateMagnet)
        {

        }
    }

}
