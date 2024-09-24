using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    private Player playerInput;
    
    public Vector2 movement;
    public Vector2 lookRotation;
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
        ControlStates();
        PickCharacter();
        WwaponCharacter();
    }
    public void ControlStates()
    {
        movement = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        lookRotation = playerInput.PlayerMain.Look.ReadValue<Vector2>();
        fire = playerInput.PlayerMain.Fire.IsPressed();
        sword = playerInput.PlayerMain.Sword.IsPressed();    
        extraSpeed = playerInput.PlayerMain.ExtraSpeed.IsPressed();
        jump = playerInput.PlayerMain.Jump.IsPressed();
        skateBoard = playerInput.PlayerMain.Skate.IsPressed();
        run = playerInput.PlayerMain.Run.IsPressed();       
    }
    void PickCharacter()
    {
        characterStick = playerInput.CharacterMenuInput.CharacterStick.ReadValue<Vector2>();
    }
    void WwaponCharacter()
    {
        weaponStick = playerInput.WeaponMenuInput.WeaponStick.ReadValue<Vector2>();
    }

    
}

