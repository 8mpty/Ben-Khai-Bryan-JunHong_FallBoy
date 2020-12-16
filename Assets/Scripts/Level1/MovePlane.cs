using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour
{
    public GameObject playerGO;

    float zUpperLimit = 54.0f;
    float zLowerLimit = 0.0f;
    float moveSpeed = 5.0f;

    bool isMoveFwd = false;
    bool isMoveBack = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveBack && !isMoveFwd)
        {
            if (transform.position.z >= zLowerLimit)
            {
                transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
            }
            else
            {
                isMoveBack = !isMoveBack;
                isMoveFwd = !isMoveFwd;
            }
        }
        if (isMoveFwd && !isMoveBack)
        {
            if (transform.position.z <= zUpperLimit)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
            }
            else
            {
                isMoveBack = !isMoveBack;
                isMoveFwd = !isMoveFwd;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayPlaneF")
        {

        }
    }
}
