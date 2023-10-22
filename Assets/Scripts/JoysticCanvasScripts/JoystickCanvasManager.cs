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
        swordButton = GameObject.Find("Sword");
        fireButton = GameObject.Find("Fire");
        fire2Button = GameObject.Find("Fire2");
        runButton = GameObject.Find("Run");
        fireButton.SetActive(true);
        fire2Button.SetActive(true);
        runButton.SetActive(true);
        //swordButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FiringMode();
        RunMode();
    }
    void FiringMode()
    {
        if (PlayerManager.GetInstance.bulletAmountText.text == "0")
        {
            fireButton.SetActive(false);
            fire2Button.SetActive(false);
            //swordButton.SetActive(true);
        }
        else
        {
            fireButton.SetActive(true);
            fire2Button.SetActive(true);
            //swordButton.SetActive(false);
        }
    }
    void RunMode()
    {
        if (playerData.isRunning)
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
