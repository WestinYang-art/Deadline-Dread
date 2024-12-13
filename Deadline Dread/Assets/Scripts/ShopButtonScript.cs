using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonScript : MonoBehaviour
{
    public float time;
    public float colorTime = 1;
    public int count;
    public bool flashing;
    public bool testHit;
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
                if (count % 2 == 0)
                {
                    gameObject.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    gameObject.GetComponent<Image>().color = Color.white;
                }
                count += 1;
                if (count >= 11)
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
