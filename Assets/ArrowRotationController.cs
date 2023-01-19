using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotationController : MonoBehaviour
{
    void Update()
    {
        ArrowRotation(PlayerManager.GetInstance._finishArea);
    }
    void ArrowRotation(Transform _finishArea)
    {
        if (gameObject != null)
        {
            //gameObject.transform.Rotate(0f, 200f * Time.deltaTime, 0f);
            //gameObject.transform.rotation = Quaternion.Euler(new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y + 90, gameObject.transform.rotation.z));
            gameObject.transform.LookAt(_finishArea); 
        }
    }
}
