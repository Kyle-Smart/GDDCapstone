using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public DropSlot Bomb;
    [SerializeField]
    public GameObject Generator;
    [SerializeField]
    public GameObject Button;
    [SerializeField]
    public GameObject MoveableText;
    [SerializeField]
    public GameObject TheDoor;

    public float PlayerHP;

    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check in here if any of the objects are present then check their states
    }
}
