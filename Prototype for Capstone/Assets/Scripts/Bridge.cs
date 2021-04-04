using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField]
    Vector2 extendedPosition;
    [SerializeField]
    GameObject ButtonToPower;
    [SerializeField]
    GameObject ButtonToMove;
    [SerializeField]
    GameObject GeneratorToPowerAndMove;

    private Vector2 retractedPosition;
    public bool isPowered;
    public bool isExtended;

    // Start is called before the first frame update
    void Start()
    {
        isPowered = false;
        isExtended = false;
        retractedPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (GeneratorToPowerAndMove == null)
        {
            bool isBridgePowered = ButtonToPower.GetComponent<PushDownButton>().IsButtonPressed();
            if (isBridgePowered)
            {
                isPowered = true;
            }
            else
            {
                isPowered = false;
            }

            bool isBridgeExtended = ButtonToMove.GetComponent<PushDownButton>().IsButtonPressed();
            if (isBridgeExtended)
            {
                isExtended = true;
            }
            else
            {
                isExtended = false;
            }
        } 
        else
        {
            bool isGeneratorOn = GeneratorToPowerAndMove.GetComponent<Generator>().IsGeneratorOn();
            if (isGeneratorOn)
            {
                isPowered = isExtended = true;
            }
            else
            {
                isPowered = isExtended = false;
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
