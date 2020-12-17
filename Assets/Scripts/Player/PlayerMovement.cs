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
        if (transform.position.y < -5 && SceneManager.GetActiveScene().name == "FirstLevel")//Restart First Level
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene");
        }

        if (transform.position.y < -5 && SceneManager.GetActiveScene().name == "SecondLevel")//Restart Second Level
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene2");
        }

        if (transform.position.y < -5 && SceneManager.GetActiveScene().name == "ThirdLevel")//Restart Third Level
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene3");
        }

        if (transform.position.y < -5 && SceneManager.GetActiveScene().name == "FourthLevel")//Restart Fourth Level
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene4");
        }

        if (touchSwitch == 0 && switchBool == true)//Enable the Slope to rotate
        {
            highSlope.GetComponent<Transform>().Rotate(-20f, 0, 0f);
            touchSwitch += 1;
        }
    }

    private void PlayerMove()
    {

        playerRb.AddForce(Vector3.down * Time.deltaTime * gravity);// Fixed gravity

        if (Input.GetKey(KeyCode.W))//Forward
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))//Left
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.S))//Back
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))//Right
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))//idle anim
        {
            animator.SetBool("isRun", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && spacePressed < 2) // fixed jump :)
        {
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            animator.SetTrigger("triggJump");
            spacePressed += 1;
        }

        //Sprint
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }
    }

    private void PlayerAnimAndForward()//Run anim
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        animator.SetBool("isRun", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FinishLineLvl4"))//Transition to Win Scene
        {
            SceneManager.LoadScene("WinScene");
        }

        if (other.gameObject.CompareTag("FinishLineLvl2"))//Transition to 3rd Level
        {
            SceneManager.LoadScene("ThirdLevel");
        }

        if (other.gameObject.CompareTag("SlopeSwitch"))//Toggle Switch
        {
            touchSwitch -= 1;
            switchBool = true;
        }
    }

    private void OnTriggerExit(Collider other)//Enable the switch to be toggled only once
    {
        if (other.gameObject.CompareTag("SlopeSwitch"))
        {
            touchSwitch = 0;
            switchBool = false;
        }
    }

    private void OnCollisionEnter(Collision collision)//Check Collision Condition for GamePlatforms
    {
        if(collision.gameObject.CompareTag("GamePlatforms"))
        {
            spacePressed = 0;
        }
    }

    private void OnCollisionStay(Collision collision)//Check Collision Condition for DropPlatforms
    {
        if (collision.gameObject.CompareTag("DropPlatform"))
        {
            spacePressed = 0;
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
