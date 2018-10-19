using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaster : MonoBehaviour {

	public GridScript mainGrid;
	[SerializeField]
	private float gridWidth = 37;
	[SerializeField]
    private float gridHeight = 17;

	void Awake()
	{
        mainGrid = new GridScript(gridWidth, gridHeight);
		mainGrid.DrawGrid();
		Debug.Log(mainGrid.GetDistance(mainGrid.tiles[0,0], mainGrid.tiles[2,2]));
	}

}
