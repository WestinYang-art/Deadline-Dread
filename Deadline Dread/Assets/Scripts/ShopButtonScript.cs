using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour
{
    private float time;
    public float colorTime;
    public int flashAmount;
    private int count = 0;
    public bool flashing;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flashing == true)
        {
            time += Time.deltaTime;
            if (time >= colorTime)
            {
                if (count % 2 == 1)
                {
                    gameObject.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<Image>().color = Color.white;
                }
                count += 1;
                if (count >= flashAmount)
                {
                    flashing = false;
                    count = 0;
                    gameObject.GetComponent<Image>().color = Color.white;
                }
                time = 0;
            }
        }
    }

    public void FixedUpdate()
    {

    }

    public void flash()
    {
        gameObject.GetComponent<Image>().color = Color.red;
        flashing = true;
    }
}
