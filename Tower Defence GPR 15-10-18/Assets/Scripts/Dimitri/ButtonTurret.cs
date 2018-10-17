using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurret : MonoBehaviour {

    //this whole script is a test for the grid class

    [SerializeField]
    GameObject floor;
    GridScript grid;
    private int position = 0;

    private void Awake()
    {
        grid = new GridScript(18, 10, 18, 10);
        grid.DrawGrid();
    }

    public void onClick()
    {
        Instantiate(floor, grid.tiles[position,position].position, Quaternion.identity);
        position++;
    }
}
