﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will be used for displaying data on anything in the game world.
/// Used for debugging perposes
/// </summary>
public class DebuggingScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Name = " + hit.collider.name);
                Debug.Log("Tag = " + hit.collider.tag);
                Debug.Log("Hit Point = " + hit.point);
                Debug.Log("Object position = " + hit.collider.gameObject.transform.position);
                Debug.Log("--------------");
            }
        }
    }
}
