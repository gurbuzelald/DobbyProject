using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.LookAt(PlayerManager.GetInstance.gameObject.transform.GetChild(0).GetChild(9));
        if (PlayerManager.GetInstance._xValue != 0 || PlayerManager.GetInstance._zValue != 0)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y - 0.01f * Time.timeScale,
                                                        gameObject.transform.position.z + 0.01f * Time.timeScale);
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                           20f,
                                                           -50f);
        }
    }
}
