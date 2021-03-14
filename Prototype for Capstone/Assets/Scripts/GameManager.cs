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
    public List<GameObject> Buttons;
    [SerializeField]
    public GameObject MoveableText;
    [SerializeField]
    public GameObject TheDoorObject;
    [SerializeField]
    public GameObject DoorPoweredIndicator;
    [SerializeField]
    public SoundManager.Sound sceneMusicToPlay;

    public float PlayerHP;
    public string Level;

    private Generator aGenerator;
    private bool generatorStatus;
    private List<PushDownButton> theButtons;
    private List<bool> buttonStatuses;
    private ActualUIDragAndDrop aText;
    private bool textStatus;
    public DropSlotTypeEnum.DropSlotType textAttachedTo;
    private Door theDoor;
    private AudioSource loopingSound;

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
        theButtons = new List<PushDownButton>();
        buttonStatuses = new List<bool>();
        if(Generator != null)
        {
            aGenerator = Generator.GetComponent<Generator>();
        }

        if (Buttons != null)
        {
            foreach(GameObject button in Buttons)
                theButtons.Add(button.GetComponent<PushDownButton>());
        }

        if (MoveableText != null)
        {
            aText = MoveableText.GetComponent<ActualUIDragAndDrop>();
        }

        theDoor = TheDoorObject.GetComponent<Door>();

        loopingSound = SoundManager.Instance.PlayLoopingSound(sceneMusicToPlay);
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

        if (theButtons != null)
        {
            foreach (PushDownButton button in theButtons)
                buttonStatuses.Add(button.IsButtonPressed());
        }

        if (MoveableText != null)
        {
            textAttachedTo = aText.slotTextIsIn;
        }


        //The draggable text is checked in the corrosponding things to attach to
        //If the clock has hit the door and opened it then we ignore this
        //EX: The Generator, the Button, and the Door handle the interaction and set powered or open true there
        //TODO: Refactor this so all door checks occur here and so that this works with lists
        if (!theDoor.hasClockHit)
        {
            if (generatorStatus && buttonStatuses[0])
            {
                theDoor.SetIsOpen(true);
                theDoor.SetIsPowered(true);
            }
            else if (generatorStatus || buttonStatuses[0])
            {
                theDoor.SetIsOpen(false);
                theDoor.SetIsPowered(true);
            }
            else
            {
                theDoor.SetIsOpen(false);
                theDoor.SetIsPowered(false);
            }
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
