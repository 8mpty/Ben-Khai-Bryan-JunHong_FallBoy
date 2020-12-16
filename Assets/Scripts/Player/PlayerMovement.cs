using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody playerRb;
    public Animator animator;
    public Transform highSlope;

    private float speed = 5.0f;
    private float jump = 7.5f;
    private float gravity = 850f;

    private int spacePressed = 0;
    private int touchSwitch = 1;

    private bool switchBool = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //Physics.gravity *= gravityModifier;
        playerRb = GetComponent<Rigidbody>();
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

        if (touchSwitch == 0 && switchBool == true)
        {
            highSlope.GetComponent<Transform>().Rotate(-20f, 0, 0f);
            touchSwitch += 1;
        }
    }

    private void PlayerMove()
    {

        playerRb.AddForce(Vector3.down * Time.deltaTime * gravity);// Fixed gravity
        if (Input.GetKey(KeyCode.W))
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 90, 0);
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
            speed = 8.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }
    }

    private void PlayerAnimAndForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        animator.SetBool("isRun", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLineLvl4"))
        {
            SceneManager.LoadScene("WinScene");
        }

        if (other.gameObject.CompareTag("FinishLineLvl2"))
        {
            SceneManager.LoadScene("ThirdLevel");
        }

        if (other.gameObject.CompareTag("SlopeSwitch"))
        {
            touchSwitch -= 1;
            switchBool = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SlopeSwitch"))
        {
            touchSwitch = 0;
            switchBool = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("GamePlatforms"))
        {
            spacePressed = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("DropPlatform"))
        {
            spacePressed = 0;
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
