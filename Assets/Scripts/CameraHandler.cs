using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] Transform modelTransform;
    [SerializeField] float distance = 10;
    [SerializeField] float rotationSpeed = 90;
    [SerializeField] float zoomPower = 4;

    private Vector3 mousePosition;

    private void Start()
    {
        // Set the camera position in front of the model
        cam.transform.position = modelTransform.position;
        cam.transform.Translate(new Vector3(0, 0, -distance));
    }

    public void StartRotation()
    {
        // When we start moving our camera
        // We get the mouse position on the screen
        mousePosition = cam.ScreenToViewportPoint(Input.mousePosition);
    }

    public void Rotate()
    {
        // As long as the mouse button is pressed

        // We calculate the directional vector of the mouse
        Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        Vector3 direction = mousePosition - newPosition;
        mousePosition = newPosition;

        // We rotate the camera around the model
        cam.transform.position = modelTransform.position;
        cam.transform.Rotate(new Vector3(1, 0, 0), direction.y * rotationSpeed);
        cam.transform.Rotate(new Vector3(0, 1, 0), -direction.x * rotationSpeed, Space.World);
        
        // Then we move the camera backward from the model
        cam.transform.Translate(new Vector3(0, 0, -distance));
    }

    public void Zoom(float delta)
    {
        delta *= zoomPower;
        distance -= delta;
        cam.transform.Translate(new Vector3(0, 0, delta));
    }
}
