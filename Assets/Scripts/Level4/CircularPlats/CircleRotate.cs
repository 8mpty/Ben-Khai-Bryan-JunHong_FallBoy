using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotate : MonoBehaviour
{
    public float spinspeed = 100f;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, spinspeed * Time.deltaTime, 0));
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.transform.parent = transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Player.transform.parent = null;
    }
}
