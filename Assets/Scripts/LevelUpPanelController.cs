using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanelController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    void Awake()
    {
        gameObject.transform.GetComponent<Image>().enabled = true;
        //gameObject.transform.GetComponent<CanvasGroup>().alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.isLevelUp)
        {
            gameObject.transform.GetComponent<CanvasGroup>().alpha = 1;
            gameObject.transform.GetComponent<Image>().enabled = true;
            gameObject.transform.GetComponent<CanvasGroup>().alpha -= 0.01f;
            if (gameObject.transform.GetComponent<CanvasGroup>().alpha == 0)
            {
                gameObject.transform.GetComponent<Image>().enabled = false;
            }
        }
        else if (gameObject.transform.GetComponent<Image>() && !playerData.isLevelUp)
        {
            gameObject.transform.GetComponent<CanvasGroup>().alpha -= 0.05f;
            if (gameObject.transform.GetComponent<CanvasGroup>().alpha == 0)
            {
                gameObject.transform.GetComponent<Image>().enabled = false;
            }
        }
    }
}
