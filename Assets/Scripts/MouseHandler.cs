using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    [SerializeField] private RequestManager requestManager;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform modelTransform;
    [SerializeField] private float distance = 10;
    [SerializeField] private float rotationSpeed = 90;
    [SerializeField] private float zoomPower = 4;
    [SerializeField] private bool popupActive = false;

    private Vector3 mousePosition;

    private void Start()
    {
        // Set the camera position in front of the model
        cam.transform.position = modelTransform.position;
        cam.transform.Translate(new Vector3(0, 0, -distance));
    }

    private void Update()
    {
        if (SendCoordinatePopup.Instance.IsActive())
            return;

        // Rotation
        if (Input.GetMouseButtonDown(0))
        {
            StartCameraRotation();
        }
        else if (Input.GetMouseButton(0))
        {
            RotateCamera();
        }
        
        // Collision
        if (Input.GetMouseButtonDown(1))
        {
            SetCollisionPoint();
        }

        // Zoom
        if (Input.mouseScrollDelta.y != 0)
        {
            Zoom(Input.mouseScrollDelta.y);
        }
    }

    public void StartCameraRotation()
    {
        // When we start moving our camera
        // We get the mouse position on the screen
        mousePosition = cam.ScreenToViewportPoint(Input.mousePosition);
    }

    public void RotateCamera()
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

    public void SetCollisionPoint()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Vector3 hitPosition = hit.point;
            requestManager.SendCollisionPoint(hitPosition);
        }
    }

    public void Zoom(float delta)
    {
        delta *= zoomPower;
        distance -= delta;
        cam.transform.Translate(new Vector3(0, 0, delta));
    }
}
