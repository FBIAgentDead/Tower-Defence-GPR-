using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour{

    public float positionX;
    public float positionY;
    [SerializeField]
    private Sprite gridTexture;
    private SpriteRenderer renderer;
    public TileTypes getTile;

    //constructor
    public Tile(float x, float y, TileTypes tileTypes)
    {
        positionX = x;
        positionY = y;
        getTile = tileTypes;
        renderer = GetComponent<SpriteRenderer>();
        DrawTile();
    }

    //this will show the tile
    public void DrawTile()
    {
        renderer.sprite = gridTexture;
    }

}
