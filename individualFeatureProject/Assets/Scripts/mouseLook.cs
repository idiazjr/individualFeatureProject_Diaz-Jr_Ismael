using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mouseLook : MonoBehaviour
{
    private PlayerInput controls;
    private float mouseSensativity = 100f;
    private Vector2 MouseLook;
    private float xRoation;
    public Transform playerBody;

    private void Awake()
    {
        playerBody = transform.parent;

        controls = new PlayerInput();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Look();
    }

    //Code to let the player look and locks at 90 degrees looking up and down
    private void Look()
    {
        MouseLook = controls.Movement.Look.ReadValue<Vector2>();

        float mouseX = MouseLook.x * mouseSensativity * Time.deltaTime;
        float mouseY = MouseLook.y * mouseSensativity * Time.deltaTime;

        //prevents from free rotation and allows a lock on camera of 90 degrees
        xRoation -= mouseY;
        xRoation = Mathf.Clamp(xRoation, -90f, 90);

        //allows us to get local rotation
        transform.localRotation = Quaternion.Euler(xRoation, 0, 0);

        //allows us to rotate on horizontal 
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
