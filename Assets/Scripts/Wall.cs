using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Occupant
{
    [SerializeField] ParticleSystem deathFX;

    public override void Action()
    {
        hex.ClearOccupant();
        Invoke("CleanUp", 1f);
        deathFX.Play();
    }


}
