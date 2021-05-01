using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField]
    public VolumeSlider volumeSlider;

    public float PlayerHP;
    public string Level; 
    public float volumeLevel = -1;
    public AudioSource loopingSound;

    private Generator aGenerator;
    private bool generatorStatus;
    private List<PushDownButton> theButtons;
    private List<bool> buttonStatuses;
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
        theButtons = new List<PushDownButton>();
        buttonStatuses = new List<bool>();
        if(Generator != null)
        {
            aGenerator = Generator.GetComponent<Generator>();
        }

        if (Buttons != null)
        {
            foreach(GameObject button in Buttons)
            {
                theButtons.Add(button.GetComponent<PushDownButton>());
                buttonStatuses.Add(button.GetComponent<PushDownButton>().IsButtonPressed());
            }
        }

        if (MoveableText != null)
        {
            aText = MoveableText.GetComponent<ActualUIDragAndDrop>();
        }

        if (TheDoorObject != null)
        {
            theDoor = TheDoorObject.GetComponent<Door>();
        }

        loopingSound = SoundManager.Instance.PlayLoopingSound(sceneMusicToPlay);

        volumeLevel = volumeSlider.GetComponent<Slider>().value;
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndSetStatusOfDoor();
    }

    private void CheckAndSetStatusOfDoor()
    {
        if (theDoor != null)
        {
            //Check in here if any of the objects are present then check their states
            if (Generator != null)
            {
                generatorStatus = aGenerator.IsGeneratorOn();
            }

            if (theButtons != null)
            {
                for (int i = 0; i < theButtons.Count; ++i)
                    buttonStatuses[i] = theButtons[i].IsButtonPressed();
            }

            if (MoveableText != null)
            {
                textAttachedTo = aText.slotTextIsIn;
            }


            //The draggable text is checked in the corrosponding things to attach to
            //If the clock has hit the door and opened it then we ignore this
            //EX: The Generator, the Button, and the Door handle the interaction and set powered or open true there
            if (!theDoor.hasClockHit)
            {
                if (buttonStatuses.Count < 1)
                {
                    if (generatorStatus)
                    {
                        theDoor.SetIsPowered(true);
                        theDoor.SetIsOpen(true);
                    }
                    else
                    {
                        theDoor.SetIsPowered(false);
                        theDoor.SetIsOpen(false);
                    }
                }
                else if (Generator == null)
                {
                    if (buttonStatuses[0])
                    {
                        theDoor.SetIsOpen(true);
                        theDoor.SetIsPowered(true);
                    }
                    else
                    {
                        theDoor.SetIsPowered(false);
                        theDoor.SetIsOpen(false);
                    }
                }
                else if (generatorStatus && buttonStatuses[0])
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
            }
            else
            {
                DoorPoweredIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    public void LockText()
    {
        aText.HasBeenUsed();
    }
}
