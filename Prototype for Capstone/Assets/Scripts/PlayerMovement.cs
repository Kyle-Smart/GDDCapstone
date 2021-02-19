using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Vars
    const float maxSpeed = 10.0f;
    const float jumpingSpeed = 100.0f;
    Rigidbody2D player;
    bool grounded;
    bool isHit;

    [SerializeField]
    HealthBar theHPBar;
    [SerializeField]
    float knockBack;
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

    //This method handles the player walking by checking input on the input axis
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
    
    //This method handles player jumping by chekcing the input axis
    private void PlayerJump()
    {
        if (Input.GetAxis("Jump") > 0.5 && grounded)
        {
            grounded = false;
            player.velocity = Vector2.up * jumpingSpeed;
        }
    }
    
    //This method handles collisions with other objects in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        if (collision.gameObject.tag == "Enemy" && !isHit)
        {
            isHit = true;
            theHPBar.setSize(0.3f);
            player.AddForce(transform.right * -knockBack);
            player.AddForce(transform.up * knockBack);

            //To prevent the player from losing all their HP after one hit
            IEnumerator coroutine = HitCoolDown();
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator HitCoolDown()
    {
        yield return new WaitForSeconds(3);
        isHit = false;
    }
}
