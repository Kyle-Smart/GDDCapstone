using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{
    Image theImage;

    void Start()
    {
        theImage = GetComponent<Image>();
        theImage.enabled = false;
    }

    public void EnableImage()
    {
        theImage.enabled = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.gameObject.GetComponent<ActualUIDragAndDrop>().StartTimer();
        }
    }
}
