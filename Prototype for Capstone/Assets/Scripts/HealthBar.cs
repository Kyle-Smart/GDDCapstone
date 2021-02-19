using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    //Vars
    private Transform bar;
    private float currentHP = 1;
    private bool isObject = false;

    // Start is called before the first frame update
    void Start()
    {
        //If there is a RB2D, then we know it is not on the UI and we don't need to have the HP bar function
        isObject = gameObject.TryGetComponent(out Rigidbody2D rigidbody2D);

        bar = transform.Find("HPBarForeground");
        //If the HP bar is an object and not on the UI, set it to the last value found in the GameManager and set the size
        if (isObject)
        {
            currentHP = GameManager.Instance.PlayerHP;
            setSize(0);
        }
        
    }

    private void Update()
    {
        if (GameManager.Instance.PlayerHP != currentHP)
        {
            GameManager.Instance.PlayerHP = currentHP;
        }
    }

    //This method changes the size of the HP bar.
    public void setSize(float sizeNormalized)
    {
        currentHP -= sizeNormalized;
        if (currentHP < 0)
            currentHP = 0;
        bar.localScale = new Vector3(currentHP, 1f);
    }
}
