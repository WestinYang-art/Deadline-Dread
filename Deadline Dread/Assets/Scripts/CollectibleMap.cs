using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleMap : MonoBehaviour
{
    [SerializeField] DiseaseGridManager dgm;
    // Start is called before the first frame update
    void Start()
    {
        PositionMap();
    }

    // Update is called once per frame
    void PositionMap()
    {
        float gridWidth = (float)dgm.width * dgm.cellSize;
        float gridHeight = (float)dgm.height * dgm.cellSize;

        transform.position = new Vector3(gridWidth * 0.5f, gridHeight * 0.5f, transform.position.z);
        transform.localScale = new Vector3(gridWidth, gridHeight, transform.localScale.z);

    }
}
