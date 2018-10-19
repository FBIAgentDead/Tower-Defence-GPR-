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
    private float gridPositionX;
    private float gridPositionY;
    
    //constructor getting variables
    public GridScript(float width, float height, int tileCountX, int tileCountY,float startPositionX = 0, float startPositionY = 0)
    {
        gridHeight = height;
        gridWidth = width;
        tileAmountX = tileCountX;
        gridPositionX = startPositionX;
        gridPositionY = startPositionY;
        tileAmountY = tileCountY;
        tiles = new Tile[Mathf.FloorToInt(height/tileSizeY), Mathf.FloorToInt(width/tileSizeX)];
        CreateGrid();
    }

    //get the grid position
    public Vector2 position { get { return new Vector2(gridPositionX,gridPositionY); } }

    //these getters can be used to get size for each tile every tile has the same x size and y size
    public float tileSizeX { get { return gridWidth / tileAmountX; } }
    public float tileSizeY { get { return gridHeight / tileAmountY; } }

    //it gets the array lenght x or y so you can check what the array lenght is
    public float lenghtY { get { return tileAmountY; } }
    public float lenghtX { get { return tileAmountX; } }
    
    //get the tile based on vector2 position and yes we know this is a weird and big way to do 
    //it but we couldn't find it on google sowwy :(
    public Tile GetTile(Vector2 position)
    {
        if(position.x < 0 && position.y < 0){
            Tile currentTile = tiles[Mathf.RoundToInt((position.y / tileSizeY)*-1), Mathf.RoundToInt((position.x / tileSizeX) * -1)];
            return currentTile;
        }
        else if(position.y < 0)
        {
            Tile currentTile = tiles[Mathf.RoundToInt((position.y / tileSizeY)*-1), Mathf.RoundToInt((position.x / tileSizeX))];
            return currentTile;
        }
        else if(position.x < 0)
        {
            Tile currentTile = tiles[Mathf.RoundToInt((position.y / tileSizeY)), Mathf.RoundToInt((position.x / tileSizeX)*-1)];
            return currentTile;
        }
        else
        {
            Tile currentTile = tiles[Mathf.RoundToInt((position.y / tileSizeY)), Mathf.RoundToInt((position.x / tileSizeX))];
            return currentTile;
        }
    }

    //creates a new grid with length and height pretty cool right?
    public void CreateGrid()
    {
        float tempX = gridPositionX;
        float tempY = gridPositionY;
        int yLayer = 0;
        for (int k = 0; k < (gridHeight/tileSizeY) - 1; k++)
        {
            for (int i = 0; i < (gridWidth/tileSizeX) - 1; i++)
            {
                tiles[yLayer, i] = new Tile(tempX, tempY, TileTypes.Available);
                tempX += tileSizeX;
            }
            tempX = gridPositionX;
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
