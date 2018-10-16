﻿using UnityEngine;
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

    //returns current tile position with the use of vectors
    public Vector2 position { get { return new Vector2(positionX,positionY); } }

    //this will show the tile
    public void DrawTile(float width, float height, int tileCountX, int tileCountY, bool horizontal)
    {
        if(horizontal == true)
        Debug.DrawLine(new Vector2(positionX + (width/tileCountX)/2,positionY + (height/tileCountY)/2), new Vector2(positionX + (width / tileCountX)/2,positionY - height), Color.black, Mathf.Infinity);
        else
        Debug.DrawLine(new Vector2(positionX - (width/tileCountX)/2, positionY - (height/tileCountY)/2), new Vector2(positionX + width, positionY - (height / tileCountY)/2), Color.black, Mathf.Infinity);
    }

}
