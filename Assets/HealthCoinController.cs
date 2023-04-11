using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCoinController : MonoBehaviour
{
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0f, 0f, 20 * Time.deltaTime);
        if (gameObject)
        {
            StartCoroutine(DelayTransformObject(0.4f, 0.43f));
        }
    }
    IEnumerator DelayTransformObject(float minValue, float maxValue)
    {
        yield return new WaitForSeconds(0.3f);
        if (gameObject.transform.localScale.x == minValue)
        {
            gameObject.transform.localScale = new Vector3(maxValue, maxValue, maxValue);
        }
        yield return new WaitForSeconds(0.3f);
        if (gameObject.transform.localScale.x == maxValue)
        {
            gameObject.transform.localScale = new Vector3(minValue, minValue, minValue);
        }
    }
}
