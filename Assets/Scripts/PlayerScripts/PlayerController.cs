using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    private GameInput gameInput;
    
    public Vector2 movement;
    public Vector2 lookRotation;
    public static Vector2 fireDirection;
    public bool fire;
    public bool sword;
    public bool extraSpeed;
    public bool jump;
    public static bool skateBoard;
    public static bool run;

    public Vector2 characterStick;

    public Vector2 weaponStick; 

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

