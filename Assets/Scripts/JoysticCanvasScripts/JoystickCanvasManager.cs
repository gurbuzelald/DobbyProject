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

    public static bool isSwordable;

    private float buttonTimeFlow;

    void Start()
    {
        buttonTimeFlow = 0;

        isSwordable = false;

        if (GameObject.Find("Sword"))
        {
            swordButton = GameObject.Find("Sword");

            swordButton.SetActive(false);

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
        SwordingMode();
    }
    void FiringMode()
    {
        if (playerData && PlayerManager.GetInstance)
        {
            if (PlayerManager.GetInstance.bulletAmountText)
            {
                if (PlayerManager.GetInstance.bulletAmountText.text == "0" && PlayerData.bulletPackAmount == 0)
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

    void SwordingMode()
    {
        buttonTimeFlow += Time.deltaTime;

        if (isSwordable)
        {
            swordButton.SetActive(true);
        }
        else
        {
            swordButton.SetActive(false);
        }

        if (swordButton)
        {
            DelayGrowSwordButton();
        }


    }
    void DelayGrowSwordButton()
    {
        if (buttonTimeFlow > 1)
        {
            swordButton.transform.localScale = new Vector3(.92f, .92f, .92f);
            buttonTimeFlow = 0;
        }
        else
        {
            swordButton.transform.localScale = new Vector3(1, 1, 1);
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
