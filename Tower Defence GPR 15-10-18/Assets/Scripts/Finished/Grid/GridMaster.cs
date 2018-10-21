using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridMaster : MonoBehaviour {

	public GridScript mainGrid;
	private AiUnit unit;
	[SerializeField]
	private float gridManagerWidth = 37;
	[SerializeField]
    private float gridManagerHeight = 17;
	[SerializeField]
	private string gridObjectsTag;

	//this sets up the grid
	void Awake()
	{
        mainGrid = new GridScript(gridManagerWidth, gridManagerHeight);
		mainGrid.DrawGrid();
	}
	
	void Update()
	{
		GameObjectPosition();
	}

	//this wil make building a map easier because it wil center building blocks to tiles even outside play mode
	//it also gives the tile type to the tile
	void GameObjectPosition(){
		GameObject[] gridObjects = GameObject.FindGameObjectsWithTag(gridObjectsTag);
		for(int i = 0; i < gridObjects.Length; i++){
			gridObjects[i].transform.position = mainGrid.GetTile(gridObjects[i].transform.position).position;
			ObjectTypes currentType = gridObjects[i].GetComponent<ObjectTypes>();
			if(mainGrid.GetTile(gridObjects[i].transform.position).getTileType != TileTypes.Building)
			mainGrid.GetTile(gridObjects[i].transform.position).getTileType = currentType.getTileType;
		}
	}

}
