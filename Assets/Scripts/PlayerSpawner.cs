using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private void Awake()
    {
        if (playerData)
        {
            if (playerData.playerObject)
            {
                Instantiate(playerData.playerObject, gameObject.transform);
            }
        }
    }
}
