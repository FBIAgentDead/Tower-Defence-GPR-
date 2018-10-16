using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid{

    [SerializeField]
    public Tile[,] tiles;
    private float gridHeight;
    private float gridWidth;
    private int tileAmountX;
    private int tileAmountY;

    //constructor getting variables
    public Grid(float width, float height, int tileCountX, int tileCountY)
    {
        gridHeight = height;
        gridWidth = width;
        tileAmountX = tileCountX;
        tileAmountY = tileCountY;
        tiles = new Tile[100,100];
        CreateGrid();
    }

    //creates a new grid with length and height pretty cool right?
    public void CreateGrid()
    {
        float tempX = 0;
        float tempY = 0;
        int yLayer = 0;
        for (int k = 0; k < gridHeight; k++)
        {
            for (int i = 0; i < gridWidth; i++)
            {
                tiles[yLayer, i] = new Tile(tempX, tempY, TileTypes.Available);
                tempX += (gridWidth / tileAmountX);
            }
            tempX = 0;
            yLayer++;
            tempY += (gridHeight / tileAmountY);
        }
    }

    //draws grid but currently broken :(
    public void DrawGrid()
    {
        for (int i = 0; i < tileAmountX; i++)
        {
            tiles[0, i].DrawTile(gridWidth, gridHeight, tileAmountX, tileAmountY, true);
        }
        for(int i = 0; i < tileAmountY; i++)
        {
            tiles[i, 0].DrawTile(gridWidth, gridHeight, tileAmountX, tileAmountY, false);
        }
    }

    //Yet to see if it works...
    public float PositionIndex(float x, float y)
    {
        return Mathf.Floor((x / tileAmountX) * Mathf.Round(x));
    }

}
