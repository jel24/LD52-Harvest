using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionUIManager : MonoBehaviour
{

    [SerializeField] SelectionManager selectionManager;

    public void ClickButton(GameObject prefab)
    {
        selectionManager.SetSelection(prefab);
        Debug.Log("Setting selection to " + prefab.name);
    }


}
