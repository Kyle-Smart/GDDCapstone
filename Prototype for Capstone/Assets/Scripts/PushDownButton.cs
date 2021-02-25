using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDownButton : MonoBehaviour
{
    //Vars
    [SerializeField]
    Sprite unpressedSprite;
    [SerializeField]
    Sprite pressedSprite;
    [SerializeField]
    Sprite brokenSprite;

    private SpriteRenderer spriteRenderer;
    private List<Collider2D> objectsOnButton;
    private bool isLockedDown;
    bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectsOnButton = new List<Collider2D>();
        isLockedDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLockedDown)
        {
            if (!isPressed && objectsOnButton.Count > 0)
            {
                ButtonAction();
            }
            else if (isPressed && objectsOnButton.Count < 1)
            {
                ButtonAction();
            }
        }
    }

    //This changes the state and the sprite of the button
    void ButtonAction()
    {
        isPressed = !isPressed;

        if (isPressed)
        {
            spriteRenderer.sprite = pressedSprite;
        } else
        {
            spriteRenderer.sprite = unpressedSprite;
        }
    }

    //Getter for the button state
    public bool IsButtonPressed()
    {
        return isPressed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        objectsOnButton.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        objectsOnButton.Remove(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" &&
            GameManager.Instance.textAttachedTo == DropSlotTypeEnum.DropSlotType.BUTTON &&
            Input.GetKey(KeyCode.E))
        {
            isPressed = true;
            spriteRenderer.sprite = brokenSprite;
            isLockedDown = true;
        }
    }
}
