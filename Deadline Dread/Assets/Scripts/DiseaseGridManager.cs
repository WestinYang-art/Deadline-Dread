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
    // Start is called before the first frame update
    void Start()
    {
        ds = new DiseaseGrid(width, height, cellSize, initialSpreadSpeed);
        ds.DiseaseTheEdges();
        StartCoroutine(ReDisease());
        StartCoroutine(SpreadRampUp());
    }

    IEnumerator SpreadRampUp()
    {
        yield return new WaitForSeconds(2.5f);
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
}
