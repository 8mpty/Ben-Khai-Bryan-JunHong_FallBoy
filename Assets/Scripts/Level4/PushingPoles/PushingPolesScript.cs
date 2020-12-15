using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingPolesScript : MonoBehaviour
{

    private float speed;

    float xlimit;
    float currentPos;
    bool onLimit;


    void Start()
    {
        
    }

    void Update()
    {
        PolePush();
    }
    
    private void PolePush()
    {
        currentPos = transform.position.x;
        xlimit = -0.10f;
        if(currentPos < xlimit && onLimit)
        {
            MoveRight();
        }
        else if(currentPos > -5f && !onLimit)
        {
            MoveLeft();
        }
        else
        {
            onLimit = !onLimit;
        }
    }

    private void MoveRight()
    {
        speed = Random.Range(10f, 20f);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void MoveLeft()
    {
        speed = Random.Range(5f, 20f);
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}