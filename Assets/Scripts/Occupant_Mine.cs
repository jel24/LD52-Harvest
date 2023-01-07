using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Occupant_Mine : Occupant
{
    [SerializeField] ParticleSystem deathFX;
    [SerializeField] int lightIncrease;

    void Start()
    {
        int[] index = hex.GetHexIndex();
        Hex[] hexes = hexManager.GetAdjacentHexes(index[0], index[1]);
        for (int i = 0; i < 6; i++)
        {
            hexes[i].IncreaseLightness(lightIncrease);
        }

    }

    public override void OnDayPass()
    {
        int[] index = hex.GetHexIndex();
        Hex[] hexes = hexManager.GetAdjacentHexes(index[0], index[1]);
        for (int i = 0; i < 6; i++)
        {
            hexes[i].Mine();
        }
    }
}
