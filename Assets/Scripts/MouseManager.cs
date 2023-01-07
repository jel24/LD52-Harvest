using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] LayerMask layersToHit;
    [SerializeField] float deadZone;

    public bool modalOpen = false;

    Hex activeHex;
    Hex previousHex;

    float screenHeight, screenWidth;

    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        if (!modalOpen)
        {
            previousHex = activeHex;
            activeHex = CheckForHex();
            if (activeHex != previousHex)
            {
                if (activeHex) activeHex.PlayHoverFX();
                if (previousHex) previousHex.StopHoverFX();
            }
        }

    }

    public void Click(InputAction.CallbackContext context)
    {
        if (context.performed && activeHex)
        {
            activeHex.Action();
        }

    }

    public void RightClick(InputAction.CallbackContext context)
    {
        if (context.performed && activeHex)
        {
            activeHex.RightAction();
        }
    }

    Hex CheckForHex()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        if (mousePosition.x < screenWidth - deadZone)
        {
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit, 100f, layersToHit) && hit.collider)
            {
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
        return null;
    }
}
