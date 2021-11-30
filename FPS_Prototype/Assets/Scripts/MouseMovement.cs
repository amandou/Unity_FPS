using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity = 200f;
    private float mouseRotationX = 0f;

    [SerializeField]
    private float mousePositionX;
    [SerializeField]
    private float mousePositionY;
    
    public Transform player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   
    }

    void FixedUpdate()
    {
        GetMouseAxis();
        RotationHandler();
    }

    void GetMouseAxis()
    {
        mousePositionX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mousePositionY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }

    void RotationHandler()
    {
        mouseRotationX -= mousePositionY;
        mouseRotationX = Mathf.Clamp(mouseRotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(mouseRotationX, 0f, 0f);
        player.Rotate(Vector3.up * mousePositionX);
    }

}
