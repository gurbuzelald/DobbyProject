using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testController : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0.5f)
        {
            gameObject.transform.Translate(0f, 0f, 10f * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") < 0.5f)
        {
            gameObject.transform.Translate(0f, 0f, -10f * Time.deltaTime);
        }


        if (Input.GetAxis("Horizontal") > 0.5f)
        {
            gameObject.transform.Translate(10f * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0.5f)
        {
            gameObject.transform.Translate(-10f * Time.deltaTime, 0f, 0f);
        }
    }
}
