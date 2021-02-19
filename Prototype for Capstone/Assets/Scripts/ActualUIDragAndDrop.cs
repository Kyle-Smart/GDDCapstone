using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActualUIDragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    private Canvas theCanvas;
    [SerializeField]
    private DropSlot theBomb;
    [SerializeField]
    private GameObject wallToMove;
    private Text timerText;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private float timer = 3.0f;
    private bool startTimer = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        timerText = GetComponentInChildren<Text>();
        timerText.text = "88:88";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / theCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void StartTimer()
    {
        startTimer = true;
    }

    public void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            timerText.text = "0:0" + Mathf.FloorToInt(timer % 60);

            if (timer < 0)
            {
                wallToMove.transform.localScale = new Vector2(wallToMove.transform.localScale.x - 0.2f, wallToMove.transform.localScale.y);
                Destroy(theBomb.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
