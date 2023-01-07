using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SelectionManager")]

public class SelectionManager : ScriptableObject
{

    GameObject activeSelection;
    [SerializeField] TriggeredEvent updateSelectionEvent;

    public void SetSelection(GameObject whichObject)
    {
        activeSelection = whichObject;
        updateSelectionEvent.Trigger();
    }

    public GameObject GetSelection()
    {
        return activeSelection;
    }

    public void ClearSelection()
    {
        activeSelection = null;
        updateSelectionEvent.Trigger();

    }

}
