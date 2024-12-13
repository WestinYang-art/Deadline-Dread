using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{
    public GameObject topBox, bottomBox, leftBox, rightBox;
    [SerializeField] DiseaseGridManager dgm;
    float gridWidth;
    float gridHeight;
    void Start()
    {
        CreateBoundingBox();
    }

    void CreateBoundingBox()
    {
        gridWidth = (float)dgm.width * dgm.cellSize;
        gridHeight = (float)dgm.height * dgm.cellSize;

        topBox.transform.position = new Vector3(gridWidth * 0.5f, gridHeight * 1.5f, topBox.transform.position.z);
        topBox.transform.localScale = new Vector3(gridWidth * 3f, gridHeight, topBox.transform.localScale.z);

        bottomBox.transform.position = new Vector3(gridWidth * 0.5f, gridHeight * -0.5f, bottomBox.transform.position.z);
        bottomBox.transform.localScale = new Vector3(gridWidth * 3f, gridHeight, bottomBox.transform.localScale.z);

        leftBox.transform.position = new Vector3(gridWidth * -0.5f, gridHeight * 0.5f, leftBox.transform.position.z);
        leftBox.transform.localScale = new Vector3(gridWidth, gridHeight*3f, leftBox.transform.localScale.z);

        rightBox.transform.position = new Vector3(gridWidth * 1.5f, gridHeight * 0.5f, rightBox.transform.position.z);
        rightBox.transform.localScale = new Vector3(gridWidth, gridHeight*3f, rightBox.transform.localScale.z);
    }
}
