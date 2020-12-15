using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerLevel2 : MonoBehaviour
{
    public Rigidbody playerRb;
    float speed = 3.5f;
    float jump = 3.5f;
    float gravityModifier = 2.0f;
    int spacePressed = 0;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        //Losing Condition
        if (transform.position.y < -5)
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene");
        }

        if (Input.GetKeyDown(KeyCode.Space)) // fixed jump :)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }

    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isRun", true);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 270, 0);
            animator.SetBool("isRun", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("isRun", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetBool("isRun", true);
        }

        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && spacePressed < 2) // fixed jump :)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            animator.SetTrigger("triggJump");
            spacePressed += 1;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLineLvl2"))
        {
            SceneManager.LoadScene("ThirdLevel");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GamePlatforms"))
        {
            Debug.Log("Touch plane");
            spacePressed = 0;
        }
    }
}
