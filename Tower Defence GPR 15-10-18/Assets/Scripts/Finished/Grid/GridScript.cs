using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript{

    public Tile[,] tiles;
    [SerializeField]
    private float gridManagerHeight;
    [SerializeField]
    private float gridManagerWidth;
    [SerializeField]
    private float tileAmountX;
    [SerializeField]
    private float tileAmountY;
    [SerializeField]
    private float gridManagerPositionX;
    [SerializeField]
    private float gridManagerPositionY;
    
    //constructor getting variables
    public GridScript(float width, float height, float startPositionX = 0, float startPositionY = 0)
    {
        gridManagerHeight = height;
        gridManagerWidth = width;
        tileAmountX = gridManagerWidth;
        tileAmountY = gridManagerHeight;
        gridManagerPositionX = startPositionX;
        gridManagerPositionY = startPositionY;
        tiles = new Tile[Mathf.FloorToInt(height/tileSizeY), Mathf.FloorToInt(width/tileSizeX)];
        CreateGrid();
    }
    
    //get the gridManager position
    public Vector2 position { get { return new Vector2(gridManagerPositionX,gridManagerPositionY); } }

    //these getters can be used to get size for each tile every tile has the same x size and y size
    public float tileSizeX { get { return gridManagerWidth / tileAmountX; } }
    public float tileSizeY { get { return gridManagerHeight / tileAmountY; } }

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

    //creates a new gridManager with length and height pretty cool right?
    public void CreateGrid()
    {
        float tempX = gridManagerPositionX;
        float tempY = gridManagerPositionY;
        int yLayer = 0;
        for (int k = 0; k < (gridManagerHeight/tileSizeY) - 1; k++)
        {
            for (int i = 0; i < (gridManagerWidth/tileSizeX) - 1; i++)
            {
                tiles[yLayer, i] = new Tile(tempX, tempY, TileTypes.None);
                tempX += tileSizeX;
            }
            tempX = gridManagerPositionX;
            yLayer++;
            tempY -= tileSizeY;
        }
    }

    //draws gridManager visual with the use of unity debug.drawline only rendered in the editor for easy use
    public void DrawGrid()
    {
        for (int i = 0; i < (gridManagerWidth/tileSizeX) - 1; i++)
        {
            tiles[0, i].DrawTile(gridManagerWidth, gridManagerHeight, tileAmountX, tileAmountY, true);
        }
        for(int i = 0; i < (gridManagerHeight/tileSizeY) - 1; i++)
        {
            tiles[i, 0].DrawTile(gridManagerWidth, gridManagerHeight, tileAmountX, tileAmountY, false);
        }
    }

    // paste grid numbers for ez path implementation
    public void GridPrint(){

    }

}
