using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseGridTester : MonoBehaviour
{
    DiseaseGrid ds;
    // Start is called before the first frame update
    void Start()
    {
        ds = new DiseaseGrid(10, 10, 1.0f, 0.3f);
        ds.DiseaseTheEdges();
        StartCoroutine(ReDisease());
    }

    IEnumerator ReDisease()
    {
        yield return new WaitForSeconds(3.0f);
        ds.DiseaseTheEdges();
        StartCoroutine(ReDisease());
    }
}
