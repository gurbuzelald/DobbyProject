using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public float playerSpeed;
    public float rotateSpeed;
    public float jumpForce;
    public bool isGround;
    public bool isWalking;
    public bool isBackWalking;
}