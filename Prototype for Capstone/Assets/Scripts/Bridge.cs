using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField]
    Vector2 extendedPosition;

    private Vector2 retractedPosition;
    public bool isPowered;
    public bool isExtended;

    private List<PushDownButton> buttonsInLevel;

    // Start is called before the first frame update
    void Start()
    {
        isPowered = false;
        isExtended = false;
        buttonsInLevel = new List<PushDownButton>();
        retractedPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        foreach (GameObject aButton in GameManager.Instance.Buttons)
            buttonsInLevel.Add(aButton.GetComponent<PushDownButton>());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (PushDownButton aButton in buttonsInLevel)
        {
            string theButtonTag = aButton.gameObject.tag;
            if (theButtonTag == "GivesPower")
            {
                isPowered = aButton.IsButtonPressed();
            }
            else if (theButtonTag == "StartsAction")
            {
                isExtended = aButton.IsButtonPressed();
            }
        }

        if (isPowered && isExtended) extendBridge();
        else retractBridge();
    }

    private void extendBridge()
    {
        gameObject.transform.position = extendedPosition;
    }
    private void retractBridge()
    {
        gameObject.transform.position = retractedPosition;
    }
}
