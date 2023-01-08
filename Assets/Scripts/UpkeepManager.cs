using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpkeepManager : MonoBehaviour
{

    [SerializeField] ResourceManager resourceManager;

    public void KingsBoon()
    {
        resourceManager.AddResource("food", 20);
        resourceManager.AddResource("gold", 100);

    }
}
