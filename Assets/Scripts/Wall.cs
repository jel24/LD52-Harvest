using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Occupant
{
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] int destroyCost;

    public override void Action()
    {
        if (resourceManager.GetResource("gold") >= destroyCost)
        {
            resourceManager.SpendResource("gold", destroyCost);
            hex.ClearOccupant();
            Invoke("CleanUp", 1f);
            deathFX.Play();
        }

    }

    public override void RightAction()
    {
        
    }


}
