using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Sprite doorOpen;

    private bool isOpen;
    private bool isPowered;

    public bool IsOpen()
    {
        return isOpen;
    }

    public bool IsPowered()
    {
        return isPowered;
    }

    public void SetIsOpen(bool status)
    {
        isOpen = status;
    }

    public void SetIsPowered(bool status)
    {
        isPowered = status;
    }


    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        isPowered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
