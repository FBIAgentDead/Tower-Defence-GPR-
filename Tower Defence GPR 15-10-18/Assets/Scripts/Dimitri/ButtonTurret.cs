using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTurret : MonoBehaviour {

    //this whole script is a test for the grid class

    [SerializeField]
    GameObject floor;
    GridScript grid;
    private int position = 0;

    public void onClick()
    {
        grid = new GridScript(37, 17, 37, 17);
        grid.DrawGrid();
    }
}
