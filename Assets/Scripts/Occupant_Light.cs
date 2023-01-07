using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Occupant_Light : Occupant
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
        hexes = hexManager.GetHexesInRange2(index[0], index[1]);
        for (int i = 0; i < 12; i++)
        {
            hexes[i].IncreaseLightness(lightIncrease);
        }
    }
}
