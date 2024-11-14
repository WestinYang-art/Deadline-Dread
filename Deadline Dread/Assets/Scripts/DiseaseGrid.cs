using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseGrid
{
    private int width;
    private int height;

    //constants for grid vals
    public const int HEALTHY = 0;
    public const int DEPRESSED = 11;


    private float cellSize;
    //spread speed currently not used
    private float spreadSpeed;

    private int[,] gridStatus;
    private GameObject[,] grid;

    public DiseaseGrid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        gridStatus = new int[width,height];
        grid = new GameObject[width,height];
        InitializeGrid();
    }

    public void InitializeGrid()
    {
        for(int x = 0; x<width; x++)
        {
            for(int y=0; y<height; y++)
            {
                grid[x,y] = new GameObject();
                grid[x,y].AddComponent<DiseaseSquare>();
                grid[x,y].GetComponent<DiseaseSquare>().Initialize(this, gridStatus[x,y], x, y, cellSize);
            }
        }
    }

    public void SetSquareStatus(int x, int y, int val)
    {
        if(x >= 0 && x < width && y >= 0 && y < height)
        {
            grid[x,y].GetComponent<DiseaseSquare>().SetStatus(val);
        }
        else Debug.Log("Square " + x + ", " + y + " is out of bounds.");
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public int getWidth(){ return width; }
    public int getHeight(){ return height; }
}
