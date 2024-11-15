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
    private float spreadSpeed;

    private int[,] gridStatus;
    private GameObject[,] grid;

    public DiseaseGrid(int width, int height, float cellSize, float spreadSpeed)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.spreadSpeed = spreadSpeed;
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
                grid[x,y].GetComponent<DiseaseSquare>().Initialize(this, gridStatus[x,y], x, y, cellSize, spreadSpeed);
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
    
    public GameObject GetSquareStatus(int x, int y)
    {
        if(x >= 0 && x < width && y >= 0 && y < height)
        {
            return grid[x,y];
        }
        else{
            Debug.Log("Square " + x + ", " + y + " is out of bounds. Returning 0,0");
            return grid[0,0];
        }
    }

    public void DiseaseTheEdges()
    {
        for(int i = 0; i<width; i++)
        {
            SetSquareStatus(i, 0, DEPRESSED);
            SetSquareStatus(i, height-1, DEPRESSED);
        }
        for(int i = 0; i<height; i++)
        {
            SetSquareStatus(0, i, DEPRESSED);
            SetSquareStatus(width-1,i,DEPRESSED);
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public int getWidth(){ return width; }
    public int getHeight(){ return height; }
}
