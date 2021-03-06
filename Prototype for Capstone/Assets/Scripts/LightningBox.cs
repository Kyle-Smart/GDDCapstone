﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBox : MonoBehaviour
{
    [SerializeField]
    GameObject theLightning;

    [SerializeField]
    private int breakMagnitudeValue = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.BoxBreak);
            Instantiate(theLightning, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } else
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.BoxDrop);
        }
    }
}
