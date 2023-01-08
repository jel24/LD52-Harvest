using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Occupant_Farm : Occupant
{

    void Start() {
        hex.AddYield();
    }

    public override void OnMine()
    {
        Mine();
    }
}
