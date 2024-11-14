using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseGridTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DiseaseGrid ds = new DiseaseGrid(10, 10, 1.0f, 1.0f);
        ds.DiseaseTheEdges();
    }
}
