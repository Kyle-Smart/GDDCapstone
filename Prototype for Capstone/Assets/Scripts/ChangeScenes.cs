using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField]
    string sceneToChangeTo;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToChangeTo);
        } else if (collision.gameObject.tag == "StartButton")
        {
            Destroy(collision.gameObject);
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
