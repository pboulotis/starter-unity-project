using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public int Speed = 80;             // used for the movement speed
    public float RotationSpeed = 2.0f; // much lower than the movement speed because we want a less mouse-sensitive camera 

    private float xRotValue; 
    private float yRotValue;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;           // We want the camera to look where the cursor is aiming at 
    }

    void Update()
    {
        float xValue = 0.0f;
        float zValue = 0.0f;
      
        xRotValue += RotationSpeed * Input.GetAxis("Mouse X");  
        yRotValue -= RotationSpeed * Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.D))
        {
            xValue = Speed * Time.deltaTime; // right movement
        }

        if (Input.GetKey(KeyCode.A))
        {
            xValue = -Speed * Time.deltaTime; // left movement
        }

        if (Input.GetKey(KeyCode.W))
        {
            zValue = Speed * Time.deltaTime; // forward movement
        }
        if (Input.GetKey(KeyCode.S))
        {
            zValue = -Speed * Time.deltaTime; // backwards movement
        }
        transform.eulerAngles = new Vector3(yRotValue, xRotValue, 0.0f);// Mouse rotation
        transform.position += transform.forward * zValue;               // Zoom in and out 
        transform.position += transform.right * xValue;                 // Right and Left movement
        
    }
}
