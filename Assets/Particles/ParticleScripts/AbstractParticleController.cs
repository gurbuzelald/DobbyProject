using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractParticleController<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;

            //DontDestroyOnLoad(gameObject);
        }
    }
    public enum ParticleNames
    {
        Skateboard,
        Death,
        Touch,
        TouchBurning,
        Birth,
        Burn,
        DestroyCoin,
        DestroyRotateCoin,
        DestroyMushroomCoin,
        DestroyBulletCoin,
        DestroyHealthCoin,
        PlayerWalking,
        None
    }
}
