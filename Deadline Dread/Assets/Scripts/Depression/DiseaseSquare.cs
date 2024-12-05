using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class DiseaseSquare : MonoBehaviour
{
    private DiseaseGrid grid;
    int status;
    int x;
    int y;
    float cellSize;
    public float spreadSpeed;
    
    public void Initialize(DiseaseGrid g, int status, int x, int y, float cellSize, float spreadSpeed)
    {
        grid = g;
        this.status = status;
        this.x = x;
        this.y = y;
        this.cellSize = cellSize;
        this.spreadSpeed = spreadSpeed;
        /*gameObject.AddComponent<MeshRenderer>();
        gameObject.AddComponent<TextMeshPro>();
        gameObject.GetComponent<TextMeshPro>().SetText(status.ToString());
        gameObject.GetComponent<TextMeshPro>().fontSize = 5;
        gameObject.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Center;*/

        gameObject.AddComponent<SpriteRenderer>();

        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(cellSize, cellSize);

        transform.position = grid.GetWorldPosition(x, y);
        StartCoroutine(Spread());
    }

    public void SetStatus(int s)
    {
        status = s;
        //gameObject.GetComponent<TextMeshPro>().SetText(status.ToString());
    }

    public int GetStatus() { return status; }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bullet") && grid.winning)
        {
            if(status == DiseaseGrid.DEPRESSED) ScoreCalculation.AddScore(2);
            //making square healthy
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            SetStatus(DiseaseGrid.HEALTHY);

            
        }
    }

    IEnumerator Spread()
    {
        yield return new WaitForSeconds(spreadSpeed);
        if(status == DiseaseGrid.DEPRESSED)
        {
            //pick a random neighbor
            /*
                OPTIONS:
                - neighborX = range(x-1, x+1). cannot be <0 or > grid width
                - neighborY = range(y-1, y+1). cannot be <0 or > grid height
            */
            int minX = Math.Max(0, x-1);
            int maxX = Math.Min(x+1, grid.getWidth()-1);
            int minY = Math.Max(0, y-1);
            int maxY = Math.Min(y+1, grid.getHeight()-1);

            System.Random r = new System.Random();

            int nX = r.Next(minX, maxX);
            int nY = r.Next(minY, maxY);
            Debug.Log("Square " + x + ", " + y + " trying to infect square " + nX + ", " + nY);

            //spread da disease. will effectively do nothing when trying to spread to an already depressed target
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = grid.visuals[ (int) Random.Range(0, grid.visuals.Length)];
            gameObject.GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Sliced;
            gameObject.GetComponent<SpriteRenderer>().size = new Vector2(cellSize*1.5f, cellSize*1.5f);
            grid.SetSquareStatus(nX, nY, DiseaseGrid.DEPRESSED);

            //currently, loss is checked in disease grid itself. this is kinda messy, we might want to change
        }
        StartCoroutine(Spread());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
