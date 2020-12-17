using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // VARIABLES //

    public GameObject player; // Set player as the GameObject
    
    Vector3 offset = new Vector3(0.0f, 2.00f, -4.14f); // Set the camera offset

    private float rotatespeed = 150f; // Set speed for the rotation of the camera
    private bool isPressed = false; // Set bool is Q is pressed

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make camera follow player at start of levels
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.1f);

        // Check if Left or Right arrow keys pressed and isPressed is set to true
        if (Input.GetKey(KeyCode.Q) && isPressed) 
        {
            CameraRotation(); // Calling the CameraRotation funtion
            CameraMove();     // Calling the CameraMove funtion
        }
        else
        {
            transform.rotation = Quaternion.Euler(15, 0, 0); // Set camera rotatation and location to default
            isPressed = !isPressed;
        }
    }

    private void CameraMove()
    {
        // If LeftArrow key pressed, make camera move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotatespeed, 0));
        }

        // If RightArrow key pressed, make camera move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotatespeed, 0));
        }
    }

    private void CameraRotation()
    {
        // If the "E" key pressed, set camera rotation to 0
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(player.transform.position.x, 1.65f, player.transform.position.z);
        }
    }
}
