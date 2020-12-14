using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweeperRotate : MonoBehaviour
{

    float SweeperSpeed = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * SweeperSpeed * Time.deltaTime);
    }
}
