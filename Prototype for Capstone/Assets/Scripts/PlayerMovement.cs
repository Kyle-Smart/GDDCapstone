using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Vars
    [SerializeField]
    const float maxSpeed = 10.0f;
    [SerializeField]
    const float jumpingSpeed = 10.0f;
    Rigidbody2D player;
    bool grounded;
    bool jumpTimerEnded;
    bool isHit;
    private Animator playerAnimator;

    [SerializeField]
    HealthBar theHPBar;
    [SerializeField]
    float knockBack;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        grounded = true;
        jumpTimerEnded = true;
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
            playerAnimator.SetBool("isWalking", true);
            if (Input.GetAxis("Horizontal") > 0.2) gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
            if (Input.GetAxis("Horizontal") < -0.2) gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        } else
        {
            player.velocity = new Vector2(0, player.velocity.y);
            playerAnimator.SetBool("isWalking", false);
        }
    }
    
    //This method handles player jumping by chekcing the input axis
    private void PlayerJump()
    {
        if (Input.GetAxis("Jump") > 0.5 && grounded && jumpTimerEnded)
        {
            playerAnimator.SetBool("isJumping", true);
            grounded = false;
            jumpTimerEnded = false;
            player.velocity = Vector2.up * jumpingSpeed;
            StartCoroutine(JumpCoolDown());
            StartCoroutine(EndJumpAnimation());
        }
    }
    
    //This method handles collisions with other objects in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "UIElement" || collision.gameObject.tag == "HPBar" || collision.gameObject.tag == "Lightning")
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
            StartCoroutine(HitCoolDown());
        }
    }

    //Timer for after the player takes damage
    private IEnumerator HitCoolDown()
    {
        yield return new WaitForSeconds(3);
        isHit = false;
    }

    //Timer for after the player jumps
    private IEnumerator JumpCoolDown()
    {
        yield return new WaitForSeconds(.5f);
        jumpTimerEnded = true;
    }

    //This handles ending the jump animation
    private IEnumerator EndJumpAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnimator.SetBool("isJumping", false);
    }
}
