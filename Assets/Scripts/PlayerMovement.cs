using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody playerRb;
    float speed 4.0f;


    // Start is called before the first frame update
    void Start()
    {
        PlayerMove();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerMove()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.forward * speed * Time.deltaTime;
        }
    }
}
