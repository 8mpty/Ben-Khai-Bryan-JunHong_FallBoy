using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform1 : MonoBehaviour
{
    // VARIABLES //

    public GameObject platform;     // Set platform as Game Object
    private float spinspeed = 15f;  // Set spin speed of the RedPlane
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make the BluePlatform rotate on its Z Axis.
        transform.Rotate(new Vector3(0,0, spinspeed * Time.deltaTime));
    }
}
