﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRod : MonoBehaviour
{
    float rotateRod = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spins cylinder
        transform.Rotate(Vector3.up * rotateRod * Time.deltaTime);
    }
}
