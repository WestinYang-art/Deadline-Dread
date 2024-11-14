using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiseaseSquare : MonoBehaviour
{
    private DiseaseGrid grid;
    int status;
    int x;
    int y;
    float cellSize;
    
    public void Initialize(DiseaseGrid g, int status, int x, int y, float cellSize)
    {
        grid = g;
        this.status = status;
        this.x = x;
        this.y = y;
        this.cellSize = cellSize;
        gameObject.AddComponent<MeshRenderer>();
        gameObject.AddComponent<TextMeshPro>();
        gameObject.GetComponent<TextMeshPro>().SetText(status.ToString());
        gameObject.GetComponent<TextMeshPro>().fontSize = 5;
        gameObject.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Center;
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(cellSize, cellSize);

        transform.position = grid.GetWorldPosition(x, y);
    }

    public void SetStatus(int s)
    {
        status = s;
        gameObject.GetComponent<TextMeshPro>().SetText(status.ToString());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            SetStatus(DiseaseGrid.HEALTHY);
            //making square healthy
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
