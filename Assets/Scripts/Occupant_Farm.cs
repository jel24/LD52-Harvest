using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Occupant_Farm : Occupant
{

    [SerializeField] int farmValue = 0;
    [SerializeField] string farmResource = "nothing";

    void Start() {
        hex.AddYield();
    }

    public override void OnMine()
    {
        resourceManager.AddResource(farmResource, farmValue);
    }
}
