using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBox : MonoBehaviour
{
    [SerializeField]
    GameObject theLightning;

    [SerializeField]
    private int breakMagnitudeValue = 5;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
        {
            Instantiate(theLightning, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
