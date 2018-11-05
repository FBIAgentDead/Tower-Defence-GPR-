using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	
	[SerializeField]
	private int detectRange = 3;
	[SerializeField]
	private int towerDamage;
	[SerializeField]
	private int attackSpeed;
	private GridMaster getTiles;
	private GameObject currentTarget;
	private Transform thisTower;
	[SerializeField]
	GameObject building;
	private List<Tile> tilesInRange = new List<Tile>();

	void Awake()
	{
		getTiles = GameObject.Find("Grid").GetComponent<GridMaster>();
		thisTower = gameObject.GetComponent<Transform>();
        GetTilesInRange();
	}

	//this function wil get all the tiles in range with the given range
	private void GetTilesInRange(){
		int startX =- detectRange;
		int startY =- detectRange;
		for(int i = 0; i < (detectRange*2)+1; i++){
			for(int j = 0; j < (detectRange*2)+1; j++){
				tilesInRange.Add(getTiles.mainGrid.GetTile(thisTower.position, startX, startY));
				startX++;
			}
			startY = (startY + 1);
			startX =- detectRange;
		}
	}
	
}
