using UnityEngine;
using System.Collections;

public class Tile{

    public float positionX;
    public float positionY;
    public TileTypes getTile;

    //constructor
    public Tile(float x, float y, TileTypes tileTypes)
    {
        positionX = x;
        positionY = y;
        getTile = tileTypes;
    }

    //this will show the tile
    public void DrawTile()
    {
        
    }

}
