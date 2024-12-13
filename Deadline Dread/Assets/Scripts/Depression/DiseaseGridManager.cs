using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseGridManager : MonoBehaviour
{
    DiseaseGrid ds;
    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] public float cellSize;
    [SerializeField] float initialSpreadSpeed;
    [SerializeField] float rampUpRate;
    [SerializeField] Sprite[] visuals;
    private bool done;

    // Start is called before the first frame update
    void Start()
    {
        done = false;
        ds = new DiseaseGrid(width, height, cellSize, initialSpreadSpeed, visuals);
        ds.DiseaseTheEdges();
        StartCoroutine(ReDisease());
        StartCoroutine(SpreadRampUp());
        StartCoroutine(PeriodicLossCheck());
    }

    IEnumerator SpreadRampUp()
    {
        
        yield return new WaitForSeconds(3.5f);
        if(!done)
        {
            float newSpeed = ds.getSpreadSpeed()/rampUpRate;
            if(newSpeed < 0.1f) newSpeed = 0.1f;
            ds.SetAllSpeed(newSpeed);
            Debug.Log("NEW SPEED: " + newSpeed.ToString());
            StartCoroutine(SpreadRampUp());
        }
    }

    IEnumerator ReDisease()
    {
        yield return new WaitForSeconds(3.0f);
        if(!done)
        {            
            ds.DiseaseTheEdges();
            StartCoroutine(ReDisease());
        }
    }

    IEnumerator WaitThenSwitch()
    {
        yield return new WaitForSeconds(0.5f);
        SceneSwitchManager.daysLeft--;
        if(SceneSwitchManager.daysLeft > 0) SceneSwitchManager.SwitchToMenu();
        else SceneSwitchManager.SwitchToRoundEnd();
    }

    IEnumerator PeriodicLossCheck()
    {
        if(!done)
        {
            yield return new WaitForSeconds(0.5f);
            ds.CheckLoss();
            if(!ds.winning)
            {
                ds.DiseaseEverything();
                StartCoroutine(WaitThenSwitch());
                done = true;                
            }
            else StartCoroutine(PeriodicLossCheck());
        }
    }
}
