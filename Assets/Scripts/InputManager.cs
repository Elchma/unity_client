using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private CameraHandler cameraHandler;

    private void Update()
    {
        // Rotation
        if (Input.GetMouseButtonDown(0))
        {
            cameraHandler.StartRotation();
        }
        else if (Input.GetMouseButton(0))
        {
            cameraHandler.Rotate();
        }

        // Zoom
        if (Input.mouseScrollDelta.y != 0)
        {
            cameraHandler.Zoom(Input.mouseScrollDelta.y);
        }
    }
}
