using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRod : MonoBehaviour
{
    float rotateSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //PlayPlaneB
        transform.Rotate(new Vector3(rotateSpeed * Time.deltaTime, 0, 0));
    }
}
