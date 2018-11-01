using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	private int detectRange = 4;
	private int towerDamage;
	private int attackSpeed;
	private GridMaster getTiles;
	private GameObject currentTarget;
	private Transform thisTower;
	private List<Tile> tilesInRange;

	void Update()
	{
		tilesInRange = new List<Tile>();
		thisTower = gameObject.GetComponent<Transform>();
		getTiles = GameObject.Find("Grid").GetComponent<GridMaster>();
		float startX = thisTower.position.x - (detectRange/2);
		float startY = thisTower.position.y + (detectRange/2);
		int times = 0;
		for(int i = 0; i < detectRange; i++){
			for(int j = 0; j < detectRange; j++){
                tilesInRange.Add(getTiles.mainGrid.GetTile(new Vector2(startX,startY)));
				startX += 1;
				times++;
			}
			startY -= 1;
			startX -= 1;
		}
		for(int f = 0; f < tilesInRange.Count; f++)
		Debug.Log(tilesInRange[f].position);
        Debug.Log(times);
	}
	
}
