using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseGridManager : MonoBehaviour
{
    DiseaseGrid ds;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float cellSize;
    [SerializeField] float initialSpreadSpeed;
    [SerializeField] float rampUpRate;
    [SerializeField] Sprite[] visuals;

    // Start is called before the first frame update
    void Start()
    {
        ds = new DiseaseGrid(width, height, cellSize, initialSpreadSpeed, visuals);
        ds.DiseaseTheEdges();
        StartCoroutine(ReDisease());
        StartCoroutine(SpreadRampUp());
    }

    IEnumerator SpreadRampUp()
    {
        yield return new WaitForSeconds(3.5f);
        float newSpeed = ds.getSpreadSpeed()/rampUpRate;
        if(newSpeed < 0.1f) newSpeed = 0.1f;
        ds.SetAllSpeed(newSpeed);
        Debug.Log("NEW SPEED: " + newSpeed.ToString());
        StartCoroutine(SpreadRampUp());
    }

    IEnumerator ReDisease()
    {
        yield return new WaitForSeconds(3.0f);
        ds.DiseaseTheEdges();
        StartCoroutine(ReDisease());
    }

    IEnumerator WaitThenSwitch()
    {
        yield return new WaitForSeconds(2.0f);
        SceneSwitchManager.SwitchToMenu();
    }
    void Update()
    {
        if(!ds.winning)
        {
            //not the best place to handle loss but whatever... i dont feel like making a Loss Manager rn
            StartCoroutine(WaitThenSwitch());
        }
        else
        {
            ds.CheckLoss();
        }
    }
}
