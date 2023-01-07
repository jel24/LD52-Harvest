using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layersToHit;

    Hex activeHex;
    Hex previousHex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        previousHex = activeHex;
        activeHex = CheckForHex();
        if (activeHex != previousHex)
        {
            if (activeHex) activeHex.PlayHoverFX();
            if (previousHex) previousHex.StopHoverFX();
        }
    }

    public void Click(InputAction.CallbackContext context)
    {
        if (context.performed && activeHex)
        {
            activeHex.Action();
        }

    }

    Hex CheckForHex()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit, 100f, layersToHit) && hit.collider)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Hex")
            {
                return hit.collider.gameObject.GetComponent<Hex>();
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }
}
