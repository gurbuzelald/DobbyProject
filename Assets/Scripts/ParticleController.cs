using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : AbstractSingleton<ParticleController>
{
    public PlayerData playerData;
    public void CreateParticle(ParticleNames particleName, Transform particleTransform)
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
        if (particleName == ParticleNames.Birth)
        {
            GameObject particleObject = Instantiate(playerData.birthParticle.gameObject, particleTransform);
            particleObject.transform.position = particleTransform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(DelayStopParticle(2f, particleObject));
        }
        if (particleName == ParticleNames.Fire)
        {
            GameObject particleObject = Instantiate(playerData.firingParticle.gameObject, particleTransform);
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
        Birth,
        Fire
    }
    public IEnumerator DelayStopParticle(float value, GameObject particleObject)
    {
        yield return new WaitForSeconds(value);

        Destroy(particleObject);
    }
}
