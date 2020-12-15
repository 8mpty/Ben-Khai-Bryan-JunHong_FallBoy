using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody playerRb;
    public Animator animator;

    float speed = 5.0f;
    float jump = 7.5f;
    float gravityModifier = 2.0f;
    int spacePressed = 0;

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
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("isRun" , true);
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

        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && spacePressed < 2) // fixed jump :)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            animator.SetTrigger("triggJump");
            spacePressed += 1;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLineLvl4"))
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("GamePlatforms"))
        {
            spacePressed = 0;
        }
    }
}
