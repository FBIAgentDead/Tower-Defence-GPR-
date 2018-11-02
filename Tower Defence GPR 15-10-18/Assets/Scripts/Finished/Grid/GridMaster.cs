using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridMaster : MonoBehaviour {

	public GridScript mainGrid;
	[SerializeField]
	private float gridManagerWidth = 37;
	[SerializeField]
    private float gridManagerHeight = 17;
	[SerializeField]
	private float X = 0;
	[SerializeField]
	private float Y = 0;
	[SerializeField]
	private string gridObjectsTag;
    private GameObject[] gridObjects;
	[SerializeField]
	private GameObject parentHost;

	//this sets up the grid
	void Awake()
	{
        mainGrid = new GridScript(gridManagerWidth, gridManagerHeight, X, Y);
		mainGrid.DrawGrid();
	}
	
	void Update()
	{
		gridObjects = GameObject.FindGameObjectsWithTag(gridObjectsTag);
		GameObjectPosition();
	}

	//this wil make building a map easier because it wil center building blocks to tiles even outside play mode
	//it also gives the tile type to the tile
	void GameObjectPosition(){
		for(int i = 0; i < gridObjects.Length; i++){
			if(gridObjects[i] != null || mainGrid.GetTile(gridObjects[i].transform.position) != null){
                TileCleaner();
				gridObjects[i].transform.position = mainGrid.GetTile(gridObjects[i].transform.position).position;
				gridObjects[i].transform.parent = parentHost.transform;
				ObjectTypes currentType = gridObjects[i].GetComponent<ObjectTypes>();
				if(mainGrid.GetTile(gridObjects[i].transform.position).getTileType != TileTypes.Building)
				mainGrid.GetTile(gridObjects[i].transform.position).getTileType = currentType.getTileType;
			}
			
		}
	}

	//if multiple tiles are on the same position it wil destroy the second one
	public void TileCleaner(){
		for(int i = 0; i < gridObjects.Length; i++){
			int temp = (i + 1);
			while(temp != gridObjects.Length){
				if(gridObjects[i].transform.position == gridObjects[temp].transform.position){
					DestroyImmediate(gridObjects[temp]);
					Debug.Log("Cleaned something!");
				}
				temp ++;
			}
		}
	}

}
