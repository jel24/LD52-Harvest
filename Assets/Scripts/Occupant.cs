using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occupant : MonoBehaviour
{
    [SerializeField] string occupantName;
    protected Hex hex;


    public virtual void Action()
    {
    }

    public void SetHex(Hex whichHex)
    {
        hex = whichHex;
    }

    public string GetName()
    {
        return occupantName;
    }


}
