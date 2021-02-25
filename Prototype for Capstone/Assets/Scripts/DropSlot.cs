using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    [SerializeField]
    public DropSlotTypeEnum.DropSlotType dropSlotType;
    [SerializeField]
    ActualUIDragAndDrop draggableText;

    void Start()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            draggableText.slotTextIsIn = dropSlotType;
        }
    }
}
