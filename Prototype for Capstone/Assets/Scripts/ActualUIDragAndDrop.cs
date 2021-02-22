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
    [SerializeField]
    private Canvas theCanvas;
    [SerializeField]
    private DropSlot dropSlot;
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

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        UIText = GetComponentInChildren<Text>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        UIText.text = beingDraggedString;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / theCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
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
    }
}
