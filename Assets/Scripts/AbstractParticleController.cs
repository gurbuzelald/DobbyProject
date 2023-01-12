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

            DontDestroyOnLoad(gameObject);
        }
    }
    public virtual void ParticleCreate(ParticleNames particleName, Transform particleTransform, PlayerData playerData)
    {
        if (particleName == ParticleNames.Skateboard)
        {
            GameObject particleObject = Instantiate(playerData.skateboardParticle.gameObject, particleTransform);
            particleObject.transform.position = particleTransform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            Destroy(particleObject, 0.5f);
        }
        if (particleName == ParticleNames.Death)
        {
            GameObject particleObject = Instantiate(playerData.deathParticle.gameObject, particleTransform);
            particleObject.transform.position = particleTransform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            Destroy(particleObject, 5f);
        }
        if (particleName == ParticleNames.Touch)
        {
            GameObject particleObject = Instantiate(playerData.touchParticle.gameObject, particleTransform);
            particleObject.transform.position = particleTransform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            Destroy(particleObject, 0.5f);
        }
        if (particleName == ParticleNames.TouchBurning)
        {
            GameObject particleObject = Instantiate(playerData.burningTouchParticle.gameObject, particleTransform);
            particleObject.transform.position = particleTransform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(DelayStopParticle(3f, particleObject));
        }
        if (particleName == ParticleNames.Birth)
        {
            GameObject particleObject = Instantiate(playerData.birthParticle.gameObject, particleTransform);
            particleObject.transform.position = particleTransform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(DelayStopParticle(2f, particleObject));
        }
        if (particleName == ParticleNames.Burn)
        {
            GameObject particleObject = Instantiate(playerData.burningParticle.gameObject, particleTransform);
            particleObject.transform.position = particleTransform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(DelayStopParticle(3f, particleObject));
        }
    }
    public enum ParticleNames
    {
        Skateboard,
        Death,
        Touch,
        TouchBurning,
        Birth,
        Burn
    }
    IEnumerator DelayStopParticle(float value, GameObject particleObject)
    {
        yield return new WaitForSeconds(value);

        Destroy(particleObject);
    }

}
