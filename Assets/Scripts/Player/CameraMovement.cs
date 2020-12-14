using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float rotatespeed = 150f;
    public GameObject player;
    
    Vector3 offset = new Vector3(0.0f, 2.00f, -4.14f);

    float speed = 1.0f;
    bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.1f);
        if(Input.GetKey(KeyCode.Q) && isPressed)
        {
            CameraRotation();
            CameraMove();
        }
        else
        {
            transform.rotation = Quaternion.Euler(15, 0, 0);
            isPressed = !isPressed;
        }
    }

    private void CameraMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -rotatespeed, 0));
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * rotatespeed, 0));
        }
    }

    private void CameraRotation()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(player.transform.position.x, 1.65f, player.transform.position.z);
        }
    }
}
