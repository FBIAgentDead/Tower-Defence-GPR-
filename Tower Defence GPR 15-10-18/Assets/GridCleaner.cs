using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCleaner : MonoBehaviour {

	void Awake()
	{
		GridMaster cleaner = gameObject.GetComponent<GridMaster>();
		cleaner.TileCleaner();
	}
}
