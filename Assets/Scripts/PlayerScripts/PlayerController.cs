using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    private Player playerInput;
    public Vector2 movement;
    public Vector2 delta;
    public bool fire;

    private void Awake()
    {
        playerInput = new Player();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }  
    void Update()
    {
        movement = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        delta = playerInput.PlayerMain.Look.ReadValue<Vector2>();
        fire = playerInput.PlayerMain.Fire.IsPressed();
    }
}

