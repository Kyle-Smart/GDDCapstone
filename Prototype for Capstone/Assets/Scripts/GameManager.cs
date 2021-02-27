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
    [SerializeField]
    public GameObject DoorPoweredIndicator;

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

        if (MoveableText != null)
        {
            textAttachedTo = aText.slotTextIsIn;
        }
       

        //The draggable text is checked in the corrosponding things to attach to
        //EX: The Generator, the Button, and the Door handle the interaction and set powered or open true there
        if (generatorStatus && buttonStatus)
        {
            theDoor.SetIsOpen(true);
            theDoor.SetIsPowered(true);
        } else if (generatorStatus || buttonStatus)
        {
            theDoor.SetIsOpen(false);
            theDoor.SetIsPowered(true);
        } else
        {
            theDoor.SetIsOpen(false);
            theDoor.SetIsPowered(false);
        }

        if (theDoor.IsPowered())
        {
            DoorPoweredIndicator.GetComponent<SpriteRenderer>().enabled = true;
        } else
        {
            DoorPoweredIndicator.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void LockText()
    {
        aText.HasBeenUsed();
    }
}
