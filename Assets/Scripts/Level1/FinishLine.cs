﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // If touching win object, loads second lvl
        if (other.gameObject.tag == "FinishLineLvl1")
        {
            SceneManager.LoadScene("SecondLevel");
        }
    }
}
