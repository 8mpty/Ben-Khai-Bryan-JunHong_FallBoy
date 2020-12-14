using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlane : MonoBehaviour
{
    float speed = 5.0f;
    float xRightLimit = 30.0f;
    float xLeftLimit = -30.0f;

    bool isMoveRight = true;
    bool isMoveLeft = false;

    public GameObject PlayerGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveRight && !isMoveLeft)
        {
            if (transform.position.y >= xRightLimit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else
            {
                isMoveLeft = !isMoveLeft;
                isMoveRight = !isMoveRight;
            }
        }


        if (isMoveLeft && !isMoveRight)
        {
            if (transform.position.y <= xLeftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                isMoveLeft = !isMoveLeft;
                isMoveRight = !isMoveRight;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerGo.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerGo.transform.SetParent(null);
        }
    }
}
