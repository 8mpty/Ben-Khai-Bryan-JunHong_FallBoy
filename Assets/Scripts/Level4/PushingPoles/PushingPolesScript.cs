using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingPolesScript : MonoBehaviour
{

    // VARIABLES //
    private float speed;       // Set Speed
    private float xlimit;      // Set the xlimit
    private float currentPos;  // Set the currentPos of the PushingPole
    private bool onLimit;      // Set the bool onLimit fo the PushingPole to hit


    void Start()
    {
        
    }

    void Update()
    {
        PolePush(); // Call PolePush Function
    }
    
    private void PolePush()
    {
        // Make the Pole move on its x Axis 
        currentPos = transform.position.x;
        xlimit = -0.10f;

        // If player's current Pos is lesser than the given xLimit and is  on the limit, Pole will move right else move left
        if (currentPos < xlimit && onLimit) 
        {
            MoveRight(); // Call MoveRight Funtion
        }
        else if(currentPos > -5f && !onLimit)
        {
            MoveLeft(); // Call MoveLeft Funtion
        }
        else
        {
            onLimit = !onLimit;
        }
    }

    private void MoveRight()
    {
        speed = Random.Range(10f, 20f); // Set random speed
        transform.Translate(Vector3.right * speed * Time.deltaTime); // Make Pole move right
    }

    private void MoveLeft()
    {
        speed = Random.Range(5f, 20f); // Set random speed
        transform.Translate(Vector3.left * speed * Time.deltaTime); // Make Pole move right
    }
}