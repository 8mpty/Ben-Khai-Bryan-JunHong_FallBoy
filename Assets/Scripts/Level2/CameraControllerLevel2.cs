using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerLevel2 : MonoBehaviour
{
    public GameObject player;

    Vector3 offset = new Vector3(0.0f, 0.75f, -2.5f);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, 0.1f);
    }
}
