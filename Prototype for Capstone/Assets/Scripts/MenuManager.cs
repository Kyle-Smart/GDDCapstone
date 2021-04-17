using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;
    public static MenuManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    //Vars
    [SerializeField]
    GameObject startButtonObject;
    [SerializeField]
    Button UIStart;
    [SerializeField]
    GameObject controls;
    [SerializeField]
    GameObject door;
    [SerializeField]
    GameObject thePlayer;
    [SerializeField]
    public SoundManager.Sound sceneMusicToPlay;

    private float startButtonPosY = 1.043f;
    private float aboveScreenPosY = 7f;
    private float aboveScreenPosX = -6f;
    public AudioSource loopingSound;
    private SpriteRenderer controlsSpriteRenderer;

    //Start Method
    public void Start()
    {
        controlsSpriteRenderer = controls.GetComponent<SpriteRenderer>();
        loopingSound = SoundManager.Instance.PlayLoopingSound(sceneMusicToPlay);
    }

    //Once the start button is clicked, break it
    public void StartButton()
    {
        Instantiate(startButtonObject, new Vector3(0,startButtonPosY,0), Quaternion.identity);
        Destroy(UIStart.gameObject);
        if (SceneManager.GetActiveScene().name == "Main Menu") StartCoroutine(SpawnTheDoor());
        else StartCoroutine(EndGame());
    }

    //Once the controls button is clicked, either show or hide the controls
    public void ControlsButton()
    {
        if (controlsSpriteRenderer.color == Color.clear)
        {
            controlsSpriteRenderer.color = Color.white;
        } else
        {
            controlsSpriteRenderer.color = Color.clear;
        }
    }

    //Once the exit button is clicked, exit the game.
    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator SpawnTheDoor()
    {
        yield return new WaitForSeconds(3);
        door.GetComponent<SpriteRenderer>().color = Color.black;
        Instantiate(thePlayer, new Vector3(aboveScreenPosX, aboveScreenPosY, 0), Quaternion.identity);
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Credits");
    }
}
