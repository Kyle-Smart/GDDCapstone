using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Teleport : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.tag == "Player") collision.transform.position = new Vector3(-8.86f, -3.6f, 0);
    }
}
