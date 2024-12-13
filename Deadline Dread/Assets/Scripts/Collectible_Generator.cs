using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Generator : MonoBehaviour
{
    public GameObject map;
    public float delay;
    public int rTiming;
    public float ring;
    public float range;
    public Sprite[] visuals;
    public Foam_Launcher launcher;
    private float time = 0;
    private float actualRandomT;
    private System.Random random = new System.Random();
    private static bool denied;
    private float rX;
    private float rY;
    // public file list;
    void Start()
    {
        delay = 5f / (float) SceneSwitchManager.getPowerLvl();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= delay + actualRandomT)
        {
            rCoordinateCalculations();
            GameObject collectibleThingy = new GameObject();
            collectibleThingy.AddComponent<Collectible>();
            collectibleThingy.GetComponent<Collectible>().initialize(random.Next(0, 3), rX, rY, visuals, launcher); // remember to change this later you stupid fuck
            actualRandomT = (1 * random.Next(0, rTiming));
            time = 0;
        }
        while (denied != false)
        {
            // check map boundaries to make sure you don't spawn a item outside of the map
            // initialize collectible from a list of collectibles
            denied = false;
        }
    }

    private void onClean()
    {
        /* if (depression killed)
         * {
         *     check map boundaries to make sure you don't spawn a item outside of the map
         *     initialize collectible from a list of collectibles
         * }
         */
    }

    public static bool getDenied()
    {
        return denied;
    }

    public static void setDenied(bool xDenied)
    {
        denied = xDenied;
    }

    public void rCoordinateCalculations()
    {
        if (random.Next(0, 2) == 1)
        {
            if (random.Next(0, 2) == 1)
            {
                rX = gameObject.transform.position.x + ring + Random.Range(0f, range);
            }
            else
            {
                rX = gameObject.transform.position.x - ring - Random.Range(0f, range);
            }
        }
        else
        {
            if (random.Next(0, 2) == 1)
            {
                rX = gameObject.transform.position.x - ring + Random.Range(0f, range);
            }
            else
            {
                rX = gameObject.transform.position.x + ring - Random.Range(0f, range);
            }
        }
        if (random.Next(0, 2) == 1)
        {
            if (random.Next(0, 2) == 1)
            {
                rY = gameObject.transform.position.y + ring + Random.Range(0f, range);
            }
            else
            {
                rX = gameObject.transform.position.y - ring - Random.Range(0f, range);
            }
        }
        else
        {
            if (random.Next(0, 2) == 1)
            {
                rY = gameObject.transform.position.y - ring + Random.Range(0f, range);
            }
            else
            {
                rX = gameObject.transform.position.y + ring - Random.Range(0f, range);
            }
        }

    }
}
