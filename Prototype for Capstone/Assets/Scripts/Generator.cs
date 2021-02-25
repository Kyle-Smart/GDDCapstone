using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    Sprite generatorOn;

    private SpriteRenderer spriteRenderer;
    private bool isPowered;
    
    public bool IsGeneratorOn()
    {
        return isPowered;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isPowered = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lightning")
        {
            Destroy(collision.gameObject);
            spriteRenderer.sprite = generatorOn;
            isPowered = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && 
            GameManager.Instance.textAttachedTo == DropSlotTypeEnum.DropSlotType.GENERATOR && 
            Input.GetKey(KeyCode.E))
        {
            isPowered = true;
            spriteRenderer.sprite = generatorOn;
        }
    }
}
