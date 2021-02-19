using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int enemyMovement = 5;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = Vector2.left * enemyMovement;
    }

    // Detects collision with other objects in the scene
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ObjectElement")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
