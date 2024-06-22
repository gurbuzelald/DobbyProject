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
        if (PlayerManager.GetInstance.bulletAmountText.text == "0" && playerData.bulletPackAmount == 0)
        {
            if (fireButton)
            {
                fireButton.SetActive(false);
            }
            if (fire2Button)
            {
                fire2Button.SetActive(false);
            }

            //swordButton.SetActive(true);
        }
        else
        {
            if (fireButton)
            {
                fireButton.SetActive(true);
            }

            if (fire2Button)
            {
                fire2Button.SetActive(true);
            }
            //swordButton.SetActive(false);
        }
    }
    void RunMode()
    {
        if (playerData.isRunning && runButton)
        {
            runButton.SetActive(false);
            StartCoroutine(RunDelay());
        }
    }
    IEnumerator RunDelay()
    {
        yield return new WaitForSeconds(2f);

        runButton.SetActive(true);
    }
}
