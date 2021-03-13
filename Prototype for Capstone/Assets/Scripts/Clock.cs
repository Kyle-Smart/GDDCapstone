using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField]
    Text clockText;
    private float timer = 5.0f;
    private bool startTimer;
    private bool detinationTimer;
    private bool isUsed;
    private float flickerTimer = 0.5f; 

    // Start is called before the first frame update
    void Start()
    {
        startTimer = true;
        detinationTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer || detinationTimer)
        {
            timer -= Time.deltaTime;
            clockText.text = "0:0" + Mathf.FloorToInt(timer % 60);

            if (timer < 0.0)
            {
                if (detinationTimer) Destroy(gameObject);
                startTimer = false;
                timer = 5.0f;
                clockText.text = "88:88";
            }
        }
        else
        {
            FlickerText();
        }
    }

    public void DetinateClock()
    {
        detinationTimer = true;
    }

    private void FlickerText()
    {
        flickerTimer -= Time.deltaTime;

        if (flickerTimer < 0.0)
        {
            if (clockText.text == "88:88")
            {
                clockText.text = "";
            }
            else
            {
                clockText.text = "88:88";
            }
            flickerTimer = Time.deltaTime + 0.5f;
        }
    }
}
