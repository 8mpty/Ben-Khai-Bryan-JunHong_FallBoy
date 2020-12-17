using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //  VARIABLES  //
    public Rigidbody playerRb;       // Set rigidbody of player
    public Animator animator;        // Set Animator for player
    public Transform highSlope;      // Set to rotate the Slope on Level 4
                                     
    private float speed = 5.0f;      // Speed for player 
    private float jump = 7.5f;       // jump force of player
    private float gravity = 850f;    // Set gravity for player to land with force

    private int spacePressed = 0;    // Count amount of SpaceBar pressed
    private int touchSwitch = 1;     // Count if player touching on CubeSwitch on Level4

    private bool switchBool = false; // Boolean to enable or disable the CubeSwitch


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  // Get Animator commponent 
        playerRb = GetComponent<Rigidbody>(); // Get Rigidbody commponent 
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();    // Call PlayerMove Function
        LoseCondition(); // Call LoseCondition Function When met

        if (touchSwitch == 0 && switchBool == true) // Enable the Slope to rotate when bool is true
        {
            highSlope.GetComponent<Transform>().Rotate(-20f, 0, 0f);
            touchSwitch += 1;
        }
    }

    private void PlayerMove() // Player Movement Function
    {

        playerRb.AddForce(Vector3.down * Time.deltaTime * gravity); // Fixed gravity

        if (Input.GetKey(KeyCode.W)) // Player moving Forward and Animation
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A)) // Player moving Left and Animation
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.S)) // Player moving Backwards and Animation
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D)) // Player moving Right and Animation
        {
            PlayerAnimAndForward();
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        // Idle animation when key Released
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

        // LeftShift Sprint and speed of sprint
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 8.0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }
    }

    private void PlayerAnimAndForward()// Run animation and player run
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        animator.SetBool("isRun", true);
    }

    private void LoseCondition() // Losing Condition for Each Level
    {
        // Check if player is on Level1 and Restart First Level
        if (transform.position.y < -5 && SceneManager.GetActiveScene().name == "FirstLevel")
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene");
        }

        // Check if player is on Level2 and Restart Second Level
        if (transform.position.y < -5 && SceneManager.GetActiveScene().name == "SecondLevel")
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene2");
        }

        // Check if player is on Level3 and Restart Third Level
        if (transform.position.y < -5 && SceneManager.GetActiveScene().name == "ThirdLevel")
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene3");
        }

        // Check if player is on Level4 and Restart Fourth Level
        if (transform.position.y < -5 && SceneManager.GetActiveScene().name == "FourthLevel")
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene4");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Transition to 1st Level
        if (other.gameObject.CompareTag("FinishLineLvl1"))
        {
            SceneManager.LoadScene("SecondLevel");
        }

        // Transition to 3rd Level
        if (other.gameObject.CompareTag("FinishLineLvl2"))
        {
            SceneManager.LoadScene("ThirdLevel");
        }

        // Transition to 4th Level
        if (other.gameObject.CompareTag("FinishLineLvl3"))
        {
            SceneManager.LoadScene("FourthLevel");
        }

        // Transition to Win Scene
        if (other.gameObject.CompareTag("FinishLineLvl4"))
        {
            SceneManager.LoadScene("WinScene");
        }

        // Toggle Switch for CubeSwitch to ON or OFF
        if (other.gameObject.CompareTag("SlopeSwitch"))
        {
            touchSwitch -= 1;
            switchBool = true;
        }
    }

    private void OnTriggerExit(Collider other)// Enable the switch to be toggled only once
    {
        if (other.gameObject.CompareTag("SlopeSwitch"))
        {
            touchSwitch = 0;
            switchBool = false;
        }
    }

    private void OnCollisionEnter(Collision collision)// Check Collision Condition for GamePlatforms
    {
        if(collision.gameObject.CompareTag("GamePlatforms"))
        {
            spacePressed = 0;
        }
    }

    private void OnCollisionStay(Collision collision)// Check Collision Condition for DropPlatforms
    {
        if (collision.gameObject.CompareTag("DropPlatform"))
        {
            spacePressed = 0;
            Destroy(collision.gameObject, 0.5f);
        }
    }
}
