using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Vars
    const float maxSpeed = 40.0f;
    const float jumpingSpeed = 100.0f;
    float currentMovementHorizontal = 0.0f;
    float currentMovementVertical = 0.0f;
    float currentDirection = 0.0f;
    float jumpingInput = 0.0f;
    Rigidbody2D player;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerWalking();
        PlayerJump();
    }

    private void PlayerWalking()
    {
        if (Input.GetAxis("Horizontal") > 0.2 || Input.GetAxis("Horizontal") < -0.2)
        {
            player.velocity = new Vector2(Input.GetAxis("Horizontal") * maxSpeed, player.velocity.y);
        } else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
    }
    
    private void PlayerJump()
    {
        if (Input.GetAxis("Jump") > 0.5 && grounded)
        {
            grounded = false;
            player.velocity = Vector2.up * jumpingSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
