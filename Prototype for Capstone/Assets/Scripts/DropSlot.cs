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

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (eventData.pointerDrag.gameObject.tag == "Clock")
            {
                eventData.pointerDrag.gameObject.GetComponent<Clock>().DetinateClock();
                StartCoroutine(DestroySelf());
            }
            if (draggableText != null) draggableText.slotTextIsIn = dropSlotType;
        }
    }
    
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(5.0f);

        Destroy(gameObject);
    }
}
