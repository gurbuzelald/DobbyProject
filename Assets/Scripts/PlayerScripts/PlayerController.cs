using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    private GameInput gameInput;

    
    private static Vector2 movement;
    public static Vector2 GetMovement()
    {
        return movement;
    }


    private static Vector2 lookRotation;
    public static Vector2 GetLookRotation()
    { 
        return lookRotation;
    }


    private static Vector2 fireDirection;
    public static Vector2 GetFireDirection()
    {
        return fireDirection;
    }


    private static bool fire;
    public static bool GetFire()
    {
        return fire;
    }
    public static void SetFire(bool _fire)
    {
        fire = _fire;
    }

    private static bool sword;
    public static bool GetSword()
    {
        return sword;
    }

    private static bool extraSpeed;
    public static bool GetExtraSpeed()
    {
        return extraSpeed;
    }


    private static bool jump;
    public static bool GetJump()
    {
        return jump;
    }

    private static bool skateBoard;
    public static bool GetSkateBoard()
    {
        return skateBoard;
    }

    private static bool run;
    public static bool GetRun()
    {
        return run;
    }

    private static Vector2 characterStick;
    public static Vector2 GetCharacterStick()
    {
        return characterStick;
    }

    private static Vector2 weaponStick;
    public static Vector2 GetWeaponStick()
    {
        return weaponStick;
    }

    private void Awake() 
    {
        gameInput = new GameInput();        
    }
    private void OnEnable()
    {
        if (gameInput != null)
        {
            gameInput.Enable();
        }        
    }
    private void OnDisable()
    {
        if (gameInput != null)
        {
            gameInput.Disable();
        }
    }  
    void Update()
    {
        if (SceneController.Scenes.Game.ToString() == SceneController.CheckSceneName())
        {
            ControlStates();
        }
        else if (SceneController.Scenes.PickCharacter.ToString() == SceneController.CheckSceneName())
        {
            PickCharacter();
        }
        else if (SceneController.Scenes.PickWeapon.ToString() == SceneController.CheckSceneName())
        {
            PickWeapon();
        }       
        
    }
    public void ControlStates()
    {
        movement = gameInput.PlayerMain.Move.ReadValue<Vector2>();
        lookRotation = gameInput.PlayerMain.Look.ReadValue<Vector2>();
        fireDirection = gameInput.PlayerMain.FireDirection.ReadValue<Vector2>();
        fire = gameInput.PlayerMain.Fire.IsPressed();
        sword = gameInput.PlayerMain.Sword.IsPressed();
        jump = gameInput.PlayerMain.Jump.IsPressed();
        run = gameInput.PlayerMain.Run.IsPressed();       
    }
    void PickCharacter()
    {
        characterStick = gameInput.PickCharacterSceneButtons.CharacterMenuInput.ReadValue<Vector2>();
    }
    void PickWeapon()
    {
        weaponStick = gameInput.PickWeaponSceneButtons.WeaponMenuInput.ReadValue<Vector2>();
    }

    
}

