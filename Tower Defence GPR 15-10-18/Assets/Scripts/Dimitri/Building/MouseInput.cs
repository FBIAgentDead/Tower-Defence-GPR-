﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour {

	GridMaster tileLocation;
	[SerializeField]
	GameObject parentUnits;

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
				Debug.Log(PlayerPrefs.GetString("choice"));
				building = Resources.Load("Towers/"+PlayerPrefs.GetString("choice")) as GameObject;
				if(building != null){
                	tileLocation.mainGrid.GetTile(Camera.main.ScreenToWorldPoint(Input.mousePosition)).getTileType = TileTypes.Building;
				}
				GameObject clone = Instantiate(building,tileLocation.mainGrid.GetTile(Camera.main.ScreenToWorldPoint(Input.mousePosition)).position, Quaternion.identity);
				clone.transform.parent = parentUnits.transform;
			}
		}
	}		
	
}
