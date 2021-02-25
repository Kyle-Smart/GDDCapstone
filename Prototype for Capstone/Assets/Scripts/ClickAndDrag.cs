using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    //Variables
    private Vector3 mOffset;    //Tracks the offset of the mouse in reference to the UI object
    private float mOffsetZ;     //Tracks the Z coordinate of the offset (not 100% if needed for a 2D game)

    //This is the game object version of the UI element
    [SerializeField]
    GameObject theObjectVersion;
    [SerializeField]
    bool isUI = true;

    //This handles having the UI element be clickable
    private void OnMouseDown()
    {
        mOffsetZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        mOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    //This finds the mouse position in the screen and transfers it to world point
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mOffsetZ;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    //As the mouse is dragging the UI element, follow the mouse
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mOffset;
    }

    //This handles destroying the UI element and replacing it with the object version
    private void OnMouseUp()
    {
        if(isUI)
        {
            Instantiate(theObjectVersion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
