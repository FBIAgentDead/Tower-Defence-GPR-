using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

	GridMaster tileLocation;

	void Awake()
	{
		tileLocation = GetComponent<GridMaster>();
	}
	
	//gets input and builds objects checks store choice to know wich object to build
	void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			GameObject building;
			if(tileLocation.mainGrid.GetTile(Camera.main.ScreenToWorldPoint(Input.mousePosition)).getTileType == TileTypes.BuildBlock){
				building = GameObject.Find(PlayerPrefs.GetString("choice"));
                tileLocation.mainGrid.GetTile(Camera.main.ScreenToWorldPoint(Input.mousePosition)).getTileType = TileTypes.Building;
				Instantiate(building,tileLocation.mainGrid.GetTile(Camera.main.ScreenToWorldPoint(Input.mousePosition)).position, Quaternion.identity);
			}
		}
	}		
	
}
