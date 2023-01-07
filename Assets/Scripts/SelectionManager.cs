using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SelectionManager")]

public class SelectionManager : ScriptableObject
{

    GameObject activeSelection;

    public void SetSelection(GameObject whichObject)
    {
        activeSelection = whichObject;
    }

    public GameObject GetSelection()
    {
        return activeSelection;
    }


}
