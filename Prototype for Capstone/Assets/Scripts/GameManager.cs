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
    public GameObject TheDoorObject;

    public float PlayerHP;

    private Generator aGenerator;
    private bool generatorStatus;
    private PushDownButton aButton;
    private bool buttonStatus;
    private ActualUIDragAndDrop aText;
    private bool textStatus;
    public DropSlotTypeEnum.DropSlotType textAttachedTo;
    private Door theDoor;

    bool isPowered = false;
    bool isOpen = false;
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
        if(Generator != null)
        {
            aGenerator = Generator.GetComponent<Generator>();
        }

        if (Button != null)
        {
            aButton = Button.GetComponent<PushDownButton>();
        }

        if (MoveableText != null)
        {
            aText = MoveableText.GetComponent<ActualUIDragAndDrop>();
        }

        theDoor = TheDoorObject.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndSetStatusOfDoor();
    }

    private void CheckAndSetStatusOfDoor()
    {
        //Check in here if any of the objects are present then check their states
        if (Generator != null)
        {
            generatorStatus = aGenerator.IsGeneratorOn();
        }

        if (Button != null)
        {
            buttonStatus = aButton.IsButtonPressed();
        }

        //TODO: Get the moveable text script functioning
        if (MoveableText != null)
        {
            //textStatus = aText.IsTextActivated();

            textAttachedTo = aText.slotTextIsIn;
        }
        
        
        //Check here if the door is powered
        if (generatorStatus)
        {
            if (!theDoor.IsPowered())
            {
                theDoor.SetIsPowered(true);
            }
            else
            {
                theDoor.SetIsOpen(true);
            }
        } else if (!generatorStatus)
        {
            if (theDoor.IsOpen())
            {
                theDoor.SetIsOpen(false);
            }
            else
            {
                theDoor.SetIsPowered(false);
            }
        }

        //Check if the door can be opened
        if (buttonStatus)
        {
            if (!theDoor.IsPowered())
            {
                theDoor.SetIsPowered(true);
            }
            else
            {
                theDoor.SetIsOpen(true);
            }
        } else if (!buttonStatus)
        {
            if (theDoor.IsOpen())
            {
                theDoor.SetIsOpen(false);
            }
            else
            {
                theDoor.SetIsPowered(false);
            }
        }
    }
}
