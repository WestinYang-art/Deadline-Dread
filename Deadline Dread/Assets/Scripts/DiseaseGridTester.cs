using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseGridTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DiseaseGrid ds = new DiseaseGrid(10, 10, 1.0f);
        for(int x = 0; x<ds.getWidth(); x++)
        {
            for(int y = 0; y<ds.getHeight(); y++)
            {
                ds.SetSquareStatus(x, y, DiseaseGrid.DEPRESSED);
            }
        }
    }
}
