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

    public virtual void RightAction()
    {
        hex.ClearOccupant();
        Invoke("CleanUp", 1f);
    }

    public void SetHex(Hex whichHex)
    {
        hex = whichHex;
    }

    public string GetName()
    {
        return occupantName;
    }

    void CleanUp()
    {
        Destroy(gameObject);
    }


}
