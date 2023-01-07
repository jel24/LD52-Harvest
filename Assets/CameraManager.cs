using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] float panThreshold;
    [SerializeField] float panSpeed;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;


    float screenHeight, screenWidth;

    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }

    void FixedUpdate()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 panDirection = new Vector2(0f, 0f);
        if (mousePosition.x > screenWidth - panThreshold)
        {
            panDirection.x = panSpeed;
        } else if (mousePosition.x < panThreshold)
        {
            panDirection.x = -panSpeed;
        }
        if (mousePosition.y > screenHeight - panThreshold)
        {
            panDirection.y = panSpeed;
        }
        else if (mousePosition.y < panThreshold)
        {
            panDirection.y = -panSpeed;
        }
        if (panDirection.x != 0f || panDirection.y != 0f)
        {
            Pan(panDirection);
        }
    }

    void Pan(Vector2 direction)
    {
        Vector3 currentPosition = mainCamera.transform.position;

        Vector3 newPosition = mainCamera.transform.position;

        if (currentPosition.x + direction.x > minX && currentPosition.x + direction.x < maxX)
        {
            newPosition.x += direction.x;
        }

        if (currentPosition.z + direction.y > minY && currentPosition.z + direction.y < maxY)
        {
            newPosition.z += direction.y;
        }

        mainCamera.transform.position = newPosition;
    }

}
