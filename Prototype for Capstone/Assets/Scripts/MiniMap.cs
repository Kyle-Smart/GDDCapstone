using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMap : MonoBehaviour
{
    public Vector2 positionToTeleportTo;
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
        if (collision.gameObject.tag == "Player")
        {
            string currentLevel = SceneManager.GetActiveScene().name;
            if (currentLevel == "TutorialFour") collision.gameObject.transform.position = new Vector3(-5.53f, -4.59f, 0);
            else if (currentLevel == "Level3") collision.gameObject.transform.position = new Vector3(-11.5f, -0.57f, 0);
            else if (currentLevel == "Level5") collision.gameObject.transform.position = new Vector3(-13.6f, -0.55f, 0);
        }
    }
}
