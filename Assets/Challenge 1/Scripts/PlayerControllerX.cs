using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float verticalInput;
    public float horizontalInput;
    
    private bool isEPressed;
    private bool isFPressed;

    // Update is called once per frame
    
    // I Get the user's input in Update() and apply the movement and rotation in FixedUpdate() to ensure smooth and consistent movement.
    private void Update()
    {
        // Get the user's input for movement and rotation
        verticalInput = Input.GetAxis("Vertical"); // For forward/backward movement
        horizontalInput = Input.GetAxis("Horizontal"); // For left/right movement
        
        if(Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            isEPressed = false;
        }
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            isFPressed = true;
        }
        else if(Input.GetKeyUp(KeyCode.F))
        {
            isFPressed = false;
        }
    }

    private void FixedUpdate()
    {
        // Move the plane forward/backward
        transform.Translate(Vector3.forward * (speed * Time.deltaTime * verticalInput));

        // Move the plane right/left
        transform.Translate(Vector3.right * (speed * Time.deltaTime * horizontalInput));

        // Tilt the plane only when pressing E (tilt up) or F (tilt down)
        if (isEPressed)
        {
            transform.Rotate(Vector3.right * (-rotationSpeed * Time.deltaTime)); // Tilt up (E key)
        }
        else if (isFPressed)
        {
            transform.Rotate(Vector3.right * (rotationSpeed * Time.deltaTime)); // Tilt down (F key)
        }
    }
}