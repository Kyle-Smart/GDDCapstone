using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField]
    Sprite doorOpen;
    [SerializeField]
    Sprite doorClosed;
    [SerializeField]
    Sprite doorJammed;
    public bool hasClockHit;
    public string nextLevel;
    public bool doorOverride;

    private bool isOpen;
    private bool isPowered;
    private bool isJammedOpen;
    private SpriteRenderer spriteRenderer;

    public bool IsOpen()
    {
        return isOpen;
    }

    public bool IsPowered()
    {
        return isPowered;
    }

    public void SetIsOpen(bool status)
    {
        if (status != isOpen && !isJammedOpen && !doorOverride)
        {
            if (status)
            {
                SoundManager.Instance.PlaySound(SoundManager.Sound.DoorOpening);
            }
            else if (!status)
            {
                SoundManager.Instance.PlaySound(SoundManager.Sound.DoorClosing);
            }

            isOpen = status;
        }
    }

    public void SetIsPowered(bool status)
    {
        if(!doorOverride) isPowered = status;
    }


    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        isPowered = false;
        isJammedOpen = false;
        hasClockHit = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isJammedOpen)
        {
            if (isOpen && isPowered)
            {
                spriteRenderer.sprite = doorOpen;
            }
            else
            {
                spriteRenderer.sprite = doorClosed;
            }
        }
        
        if (doorOverride == true)
        {
            isPowered = true;
            isOpen = true;
            spriteRenderer.sprite = doorOpen;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&
            GameManager.Instance.textAttachedTo == DropSlotTypeEnum.DropSlotType.DOOR &&
            Input.GetKey(KeyCode.E) &&
            isPowered &&
            (!isOpen || !isJammedOpen))
        {
            SceneManager.LoadScene(nextLevel);
        }
        else if (collision.tag == "Player" &&
          GameManager.Instance.textAttachedTo == DropSlotTypeEnum.DropSlotType.DOOR &&
          Input.GetKey(KeyCode.E) &&
          !isPowered)
        {
            GameManager.Instance.LockText();
        }
        else if (isOpen || isJammedOpen)
        {
            if (collision.tag == "Player")
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen || isJammedOpen)
        {
            //if (collision.tag == "Player")
            //{
            //    SceneManager.LoadScene(nextLevel);
            //}
             if (collision.tag == "HPBar" && !doorOverride)
            {
                Destroy(collision.gameObject); 
                spriteRenderer.sprite = doorJammed;
                isJammedOpen = true;
                SoundManager.Instance.PlaySound(SoundManager.Sound.DoorJamming);
            }
        }

        if (collision.gameObject.tag == "Clock" && !hasClockHit)
        {
            hasClockHit = true;
            GameObject theClock = Instantiate(collision.gameObject, gameObject.transform);
            theClock.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            StartCoroutine(BreakDoorOpen(theClock));
            Destroy(collision.gameObject);
        }
    }

    IEnumerator BreakDoorOpen(GameObject theClock)
    {
        theClock.GetComponent<Clock>().DetinateClock();
        yield return new WaitForSeconds(5.0f);

        Destroy(theClock);
        SetIsPowered(true);
        SetIsOpen(true);
    }
}
