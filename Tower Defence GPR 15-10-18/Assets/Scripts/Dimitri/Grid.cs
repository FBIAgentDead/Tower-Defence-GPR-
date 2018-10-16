using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid{

    [SerializeField]
    public Tile[,] tiles;
    private float gridHeight;
    private float gridWidth;
    private int tileAmount;

    //constructor getting variables
    public Grid(float width, float height, int tileCount)
    {
        gridHeight = height;
        gridWidth = width;
        tileAmount = tileCount;
        tiles = new Tile[100,100];
    }

    //hier gaan we het grid in elkaar zetten met behulp van de grote en breedte die zijn megegeven 
    public void CreateGrid()
    {
        float tempX = 0;
        int yLayer = 0;
        for(int i = 0; i < gridWidth; i++)
        {
            tiles[yLayer,i] = new Tile(tempX,0,TileTypes.Available);
            tempX += (gridWidth / tileAmount);
        }
        yLayer++;
    }

}
