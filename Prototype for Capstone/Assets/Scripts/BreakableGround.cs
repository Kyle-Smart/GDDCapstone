using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableGround : MonoBehaviour
{
    private bool hasHit;
    // Start is called before the first frame update
    void Start()
    {
        hasHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Clock" && !hasHit)
        {
            hasHit = true;
            GameObject theClock = Instantiate(collision.gameObject, gameObject.transform);
            theClock.GetComponent<ClickAndDrag>().isEnabled = false;
            theClock.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            StartCoroutine(DestroyGround(theClock));
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DestroyGround(GameObject theClock)
    {
        theClock.GetComponent<Clock>().DetinateClock();
        yield return new WaitForSeconds(5.0f);
        
        Destroy(gameObject);
    }
}
