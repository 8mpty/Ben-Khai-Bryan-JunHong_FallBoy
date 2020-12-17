using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // VARIABLES //

    public GameObject platform;     // Set platform as Game Object
    private float spinspeed = 10f;  // Set spin speed of the BluePlane
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Make the BluePlatform rotate on its X Axis.
        transform.Rotate(new Vector3(spinspeed * Time.deltaTime, 0, 0));
    }
}
