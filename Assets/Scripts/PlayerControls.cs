using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //jumping power for player object
        [Header("Default Jumping Power")]
        public float jumpPower = 6.5f;

    [Header("Boolean isGrounded")]
    public bool isGrounded = false; //instantiate is on ground
    //float posX = 0.0f; //position of object
    Rigidbody2D rb; //no value yet
    float posX = 0.0f; 


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>(); //rb = rigidbody2d component

        posX = transform.position.x; // get x coor of game object


    }
    void FixedUpdate()
    {
        // if space + isGrounded
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f)); // adds force to rb based on default jp, mass, gs
        }
        if (transform.position.x < posX)
        {
            GameOver();
        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            GameObject.Find("GameController").GetComponent<GameController>().IncrementScore();

            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
        if(collision.collider.tag == "Enemy")
        {
            GameOver();
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
     
        
                if(collision.collider.tag == "Ground")
                {
                    isGrounded = true; 
                }
        
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = false; 
        }
    }

    // Update is called once per frame
    
    
    void GameOver()
    {
        
        GameObject.Find("GameController").GetComponent<GameController>().GameOver(); 
    }
}
