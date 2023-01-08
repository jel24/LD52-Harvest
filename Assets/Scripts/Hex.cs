using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hex : MonoBehaviour
{

    Occupant occupant;

    [SerializeField] GameObject lightObject;
    [SerializeField] SelectionManager selectionManager;
    [SerializeField] ResourceManager resourceManager;

    [SerializeField] TriggeredEvent cantAffordEvent;
    [SerializeField] TriggeredEvent tooDarkEvent;

    [SerializeField] ParticleSystem hoverFX;

    [SerializeField] TextMeshPro label;


    protected int lightness;

    protected int hexIndexX, hexIndexY;

    bool validHex = false;

    public void SetHexIndex(int x, int y, bool valid)
    {
        hexIndexX = x;
        hexIndexY = y;
        validHex = valid;
    }

    public int[] GetHexIndex()
    {
        return new int[] { hexIndexX, hexIndexY };
    }

    public void Action()
    {
        if (validHex)
        {
            if (occupant)
            {
                occupant.Action();
            }
            else
            {
                if (selectionManager.GetSelection())
                {
                    Occupant newOccupant = selectionManager.GetSelection().GetComponent<Occupant>();
                    Debug.Log(newOccupant.name + " found.");

                    if (newOccupant.CanAfford())
                    {
                        if (lightness >= newOccupant.lightRequirement)
                        {
                            newOccupant.Buy();
                            Occupant newObject = Instantiate(selectionManager.GetSelection()).GetComponent<Occupant>();
                            SetOccupant(newObject);
                        } else
                        {
                            tooDarkEvent.Trigger();
                        }

                    }
                    else
                    {
                        Debug.Log(newOccupant.name + " can't be purchased.");

                        cantAffordEvent.Trigger();
                    }


                }
                else
                {
                    Debug.Log("Nothing selected.");
                }

            }
        }
    }

    public void Mine()
    {
        if (occupant)
        {
            occupant.Mine();
        }
    }

    public void RightAction()
    {
        if (validHex)
        {
            if (occupant)
            {
                occupant.RightAction();
            }
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
    public void IncreaseLightness(int howMuch)
    {
        lightness += howMuch;
    }

    public void PlayHoverFX()
    {
        if (validHex)
        {
            hoverFX.Play();
            if (occupant)
            {
                label.text = occupant.occupantName;
            }
        }
    }

    public void ShowYield()
    {
        if (validHex)
        {
            if (occupant)
            {
                if (occupant.GetMineResource() != "nothing") {
                    label.text = occupant.GetMineValue() + " " + occupant.GetMineResource() + "/day";
                }
            }
        }
    }

    public void AddYield()
    {
        if (occupant)
        {
            resourceManager.AddYield(occupant.GetMineResource(), occupant.GetMineValue());
        }
    }

    public void StopHoverFX()
    {
        if (validHex)
        {
            hoverFX.Stop();
            label.text = "";
        }
    }
}
