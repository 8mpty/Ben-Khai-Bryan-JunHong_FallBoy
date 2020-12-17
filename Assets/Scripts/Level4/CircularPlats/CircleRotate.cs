using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour
{
    // VARIABLES //

    public GameObject Player;       // Set player as the Game Object
    private float spinspeed = 100f;  // Set speed for the spin of the Circular platform
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Pick Random and change speed accordingly 
        if (Random.Range(0, 2) < 1)
        {
            transform.Rotate(new Vector3(0, Random.Range(spinspeed , 150f) * Time.deltaTime, 0));
        }
        else
        {
            transform.Rotate(new Vector3(0, Random.Range(spinspeed, 200f) * Time.deltaTime, 0));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If player is colliding with the Rotating Cricle, player will be set to child of the Rotating Circle
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Remove player from the Rotating Circle parent
        Player.transform.parent = null;
    }
}
