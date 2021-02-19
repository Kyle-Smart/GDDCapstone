using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    Sprite brokenSprite;

    private SpriteRenderer startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton = GetComponent<SpriteRenderer>();
    }

    //Once the button hits the ground, break
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Once the start button hits the ground change the sprite
        if (collision.transform.tag == "Ground")
        {
            startButton.sprite = brokenSprite;
        }
    }
}
