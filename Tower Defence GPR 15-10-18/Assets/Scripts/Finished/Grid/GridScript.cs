using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript{

    [SerializeField]
    public Tile[,] tiles;
    private float gridHeight;
    private float gridWidth;
    private int tileAmountX;
    private int tileAmountY;

    //constructor getting variables
    public GridScript(float width, float height, int tileCountX, int tileCountY)
    {
        gridHeight = height;
        gridWidth = width;
        tileAmountX = tileCountX;
        tileAmountY = tileCountY;
        tiles = new Tile[Mathf.FloorToInt(height/tileSizeY), Mathf.FloorToInt(width/tileSizeX)];
        CreateGrid();
    }

    //these getters can be used to get size for each tile every tile has the same x size and y size
    public float tileSizeX { get { return gridWidth / tileAmountX; } }
    public float tileSizeY { get { return gridHeight / tileAmountY; } }

    //it gets the array lenght x or y so you can check what the array lenght is
    public float lenghtY { get { return tileAmountY; } }
    public float lenghtX { get { return tileAmountX; } }

    public int GetTileX(float x)
    {
        Debug.Log(Mathf.FloorToInt(x / tileSizeX));
        return Mathf.FloorToInt(x / tileSizeX);
    }

    public int GetTileY(float y)
    {
        Debug.Log(Mathf.FloorToInt(y / tileSizeY));
        return Mathf.FloorToInt(y / tileSizeY);
    }

    //creates a new grid with length and height pretty cool right?
    public void CreateGrid()
    {
        float tempX = 0;
        float tempY = 0;
        int yLayer = 0;
        int timesDone = 0;
        for (int k = 0; k < (gridHeight/tileSizeY) - 1; k++)
        {
            timesDone++;
            for (int i = 0; i < (gridWidth/tileSizeX) - 1; i++)
            {
                tiles[yLayer, i] = new Tile(tempX, tempY, TileTypes.Available);
                tempX += tileSizeX;
            }
            tempX = 0;
            yLayer++;
            tempY -= tileSizeY;
        }
    }

    //draws grid visual with the use of unity debug.drawline only rendered in the editor for easy use
    public void DrawGrid()
    {
        for (int i = 0; i < (gridWidth/tileSizeX) - 1; i++)
        {
            tiles[0, i].DrawTile(gridWidth, gridHeight, tileAmountX, tileAmountY, true);
        }
        for(int i = 0; i < (gridHeight/tileSizeY) - 1; i++)
        {
            tiles[i, 0].DrawTile(gridWidth, gridHeight, tileAmountX, tileAmountY, false);
        }
    }

}
