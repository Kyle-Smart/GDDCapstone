using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActualUIDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //NOTE: Commented out code is to be saved for the timer and bomb interaction
    //Move them to a child script when we need to

    //Vars
    public DropSlotTypeEnum.DropSlotType slotTextIsIn;

    [SerializeField]
    private Canvas theCanvas;
    [SerializeField]
    private string beingDraggedString;
    [SerializeField]
    private string onGeneratorString;
    [SerializeField]
    private string onButtonString;
    [SerializeField]
    private string onDoorString;
    private Text UIText;
    private RectTransform rectTransform;

    //Vars for the timer
    private float timer = 3.0f;
    private bool startTimer = false;
    private CanvasGroup canvasGroup;
    private bool isTouched;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        UIText = GetComponentInChildren<Text>();
        canvasGroup = GetComponent<CanvasGroup>();
        isTouched = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        UIText.text = beingDraggedString;
        canvasGroup.blocksRaycasts = false;
        isTouched = true;
        slotTextIsIn = DropSlotTypeEnum.DropSlotType.DEFAULT;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / theCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    /*public void StartTimer()
    {
        startTimer = true;
    }*/

    public void Update()
    {
        /*if (startTimer)
        {
            timer -= Time.deltaTime;
            UIText.text = "0:0" + Mathf.FloorToInt(timer % 60);
        }*/

        if (isTouched)
        {
            switch (slotTextIsIn)
            {
                case DropSlotTypeEnum.DropSlotType.GENERATOR:
                    UIText.text = onGeneratorString;
                    break;
                case DropSlotTypeEnum.DropSlotType.BUTTON:
                    UIText.text = onButtonString;
                    break;
                case DropSlotTypeEnum.DropSlotType.DOOR:
                    UIText.text = onDoorString;
                    break;
                default:
                    UIText.text = beingDraggedString;
                    break;
            }
        }
    }
}
