using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{

    Occupant occupant;

    [SerializeField] GameObject lightObject;


    [SerializeField] ParticleSystem hoverFX;

    protected int fertility;
    protected int lightness;
    protected int warmth;
    
    public void Action()
    {
        Debug.Log("Clicked");
        if (occupant)
        {
            occupant.Action();
        }
        else
        {
            SetOccupant(Instantiate(lightObject).GetComponent<Occupant>());
        }
    }


    public bool CheckForOccupant()
    {
        return occupant != null;
    }

    public void SetOccupant(Occupant whichOccupant)
    {
        occupant = whichOccupant;
        occupant.SetHex(this);
        occupant.transform.position = transform.position;
        occupant.transform.parent = transform;
    }

    public Occupant GetOccupant()
    {
        return occupant;
    }

    public void ClearOccupant()
    {
        occupant = null;
    }

    public void IncreaseFertility(int howMuch)
    {
        fertility += howMuch;
    }

    public void IncreaseLightness(int howMuch)
    {
        lightness += howMuch;
    }

    public void IncreaseWarmth(int howMuch)
    {
        warmth += howMuch;
    }

    public void PlayHoverFX()
    {
        hoverFX.Play();
    }

    public void StopHoverFX()
    {
        hoverFX.Stop();
    }
}
