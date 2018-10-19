using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript{

    public Tile[,] tiles;
    [SerializeField]
    private float gridHeight;
    [SerializeField]
    private float gridWidth;
    [SerializeField]
    private float tileAmountX;
    [SerializeField]
    private float tileAmountY;
    [SerializeField]
    private float gridPositionX;
    [SerializeField]
    private float gridPositionY;
    
    //constructor getting variables
    public GridScript(float width, float height, float startPositionX = 0, float startPositionY = 0)
    {
        gridHeight = height;
        gridWidth = width;
        tileAmountX = gridWidth;
        tileAmountY = gridHeight;
        gridPositionX = startPositionX;
        gridPositionY = startPositionY;
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
    public Tile GetTile(Vector2 position, int parentX = 0, int parentY = 0)
    {
        if(position.x < 0 && position.y < 0){
            Tile currentTile = tiles[Mathf.RoundToInt(((position.y/tileSizeY)*-1)+parentY),Mathf.RoundToInt(((position.x/tileSizeX)*-1)+parentX)];
            return currentTile;
        }
        else if(position.y < 0)
        {
            Tile currentTile = tiles[Mathf.RoundToInt(((position.y/tileSizeY)*-1)+parentY),Mathf.RoundToInt((position.x/tileSizeX)+parentX)];
            return currentTile;
        }
        else if(position.x < 0)
        {
            Tile currentTile = tiles[Mathf.RoundToInt((position.y/tileSizeY)+parentY),Mathf.RoundToInt(((position.x/tileSizeX)*-1)+parentX)];
            return currentTile;
        }
        else
        {
            Tile currentTile = tiles[Mathf.RoundToInt((position.y/tileSizeY)+parentY),Mathf.RoundToInt((position.x/tileSizeX)+parentX)];
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

    public int GetDistance(Tile start, Tile finish)
    {
        int aX;
        int aY;
        int bX;
        int bY;

        int distance;

        aX = Mathf.RoundToInt(start.position.x);
        aY = Mathf.RoundToInt((start.position.y)*-1);
        bX = Mathf.RoundToInt(finish.position.x);
        bY = Mathf.RoundToInt((finish.position.y)*-1);

        distance = (aX + bX) + (aY + bY);
        return distance;
    }
}
