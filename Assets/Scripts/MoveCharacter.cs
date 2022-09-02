using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCharacter : MonoBehaviour
{
    public float speed = 5f;
    public float speedHalved = 7.5f;
    public float speedOrigin = 10f;
    public bool isGrounded;
    public float jumpForce= 7f;
    public Vector3 jump;
    public GameObject winCanvas;
   
    
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);
    }
    private void Update()
    {
       
        if (isGrounded && (Input.GetButtonDown("Jump")))
        {
            {

                isGrounded = false;
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);


            }
        }
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); // set a float to control horizontal input
        float vertical = Input.GetAxis("Vertical"); // set a float to control vertical input
        PlayerMove(horizontal, vertical); // Call the move player function sending horizontal and vertical movements
       
    }

    private void PlayerMove(float h, float v)
    {
        if (h != 0f || v != 0f) // If horizontal or vertical are pressed then continue
        {
            if (h != 0f && v != 0f) // If horizontal AND vertical are pressed then continue
            {
                speed = speedHalved; // Modify the speed to adjust for moving on an angle
            }
            else // If only horizontal OR vertical are pressed individually then continue
            {
                speed = speedOrigin; // Keep speed to it's original value
            }

            Vector3 targetDirection = new Vector3(h, 0f, v); // Set a direction using Vector3 based on horizontal and vertical input
            rb.MovePosition(GetComponent<Rigidbody>().position + targetDirection * speed * Time.deltaTime); // Move the players position based on current location while adding the new targetDirection times speed
            RotatePlayer(targetDirection); // Call the rotate player function sending the targetDirection variable

        }
    }
    private void RotatePlayer(Vector3 dir)
    {
        rb.MoveRotation(Quaternion.LookRotation(dir)); // Rotate the player to look at the new targetDirection
    }
  
    

    private void OnCollisionStay(Collision collision)
    {
       
        isGrounded = true;
        if (collision.gameObject.tag == "Respawn")
        {
            SceneManager.LoadScene("Game");
        }
        if (collision.gameObject.tag == "Finish")
        {
            winCanvas.SetActive(true);
            Invoke("StartNewGame", 5);
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
       
            isGrounded = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other);
        }
    }
    void StartNewGame()
    {
        winCanvas.SetActive(false);
        SceneManager.LoadScene("Game");
    }

}