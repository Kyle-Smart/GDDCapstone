﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActualUIDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
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
    private CanvasGroup canvasGroup;
    private bool isTouched;
    private bool isUsed;
    public bool isText;

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
        if (isText) slotTextIsIn = DropSlotTypeEnum.DropSlotType.DEFAULT;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / theCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void HasBeenUsed()
    {
        isUsed = true;
        canvasGroup.blocksRaycasts = false;
    }

    public void Update()
    {
        if (isTouched && isText)
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
