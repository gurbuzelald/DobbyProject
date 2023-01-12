using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : AbstractParticleController<ParticleController>
{
    public PlayerData playerData;

    public void CreateParticle(ParticleNames particleName, Transform particleTransform)
    {
        ParticleCreate(particleName, particleTransform, playerData);
    }
}
