using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickCanvasManager : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    private GameObject swordButton;
    private GameObject fireButton;
    private GameObject fire2Button;
    private GameObject runButton;

    void Start()
    {
        if (GameObject.Find("Sword"))
        {
            swordButton = GameObject.Find("Sword");

            //swordButton.SetActive(false);

        }
        if (GameObject.Find("Fire"))
        {
            fireButton = GameObject.Find("Fire");

            fireButton.SetActive(true);

        }
        if (GameObject.Find("Fire2"))
        {
            fire2Button = GameObject.Find("Fire2");

            fire2Button.SetActive(true);
        }
        if (GameObject.Find("Run"))
        {
            runButton = GameObject.Find("Run");

            runButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FiringMode();
        RunMode();
    }
    void FiringMode()
    {
        if (playerData)
        {
            if (PlayerManager.GetInstance.bulletAmountText)
            {
                if (PlayerManager.GetInstance.bulletAmountText.text == "0" && playerData.bulletPackAmount == 0)
                {
                    if (fireButton)
                    {
                        fireButton.SetActive(false);
                    }
                }
                else
                {
                    if (fireButton)
                    {
                        fireButton.SetActive(true);
                    }
                }
            }           
        }        
    }
    void RunMode()
    {
        if (PlayerData.isRunning && runButton)
        {
            runButton.SetActive(false);
            Invoke("RunDelay", 2);
        }
    }
    void RunDelay()
    {
        runButton.SetActive(true);
    }
}
