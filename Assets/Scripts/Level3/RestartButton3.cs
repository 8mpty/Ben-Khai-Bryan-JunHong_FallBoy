using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart3()
    {
        // If in lose condition and restart lvl button is pressed
        // the lvl will be reloaded
        SceneManager.LoadScene("ThirdLevel");
    }
}
