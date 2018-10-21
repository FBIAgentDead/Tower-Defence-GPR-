using UnityEngine;
using System.Collections;

public class Tile{

    private float positionX;
    private float positionY;
    private TileTypes tile;

    //constructor
    public Tile(float x, float y, TileTypes tileTypes)
    {
        positionX = x;
        positionY = y;
        tile = tileTypes;
    }

    //returns current tile position with the use of vectors
    public Vector3 position { get { return new Vector3(positionX,positionY, 1); } }
    public TileTypes getTileType { set { tile = value;  } get { return tile; } }
    
    //this will show the tile and pls don't let me explain the formula
    public void DrawTile(float width, float height, float tileCountX, float tileCountY, bool horizontal)
    {
        if(horizontal == true)
        Debug.DrawLine(new Vector2(positionX + (width/tileCountX)/2,positionY + (height/tileCountY)/2), new Vector2(positionX + (width / tileCountX)/2,positionY - height), Color.black, Mathf.Infinity);
        else
        Debug.DrawLine(new Vector2(positionX - (width/tileCountX)/2,positionY - (height/tileCountY)/2), new Vector2(positionX + width, positionY - (height / tileCountY)/2), Color.black, Mathf.Infinity);
    }

    //gets distance between tile a and tile b
    public int GetDistance(Tile b)
    {
        int aX;
        int aY;
        int bX;
        int bY;

        int distance;

        aX = Mathf.RoundToInt(positionX);
        aY = Mathf.RoundToInt(positionY*-1);
        bX = Mathf.RoundToInt(b.position.x);
        bY = Mathf.RoundToInt(b.position.y*-1);

        distance = (aX + bX) + (aY + bY);
        return distance;
    }

}
