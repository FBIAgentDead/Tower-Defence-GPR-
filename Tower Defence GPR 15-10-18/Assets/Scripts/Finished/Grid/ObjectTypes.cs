using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTypes : MonoBehaviour {

	[SerializeField]
	private TileTypes tileTypes;
	public TileTypes getTileType { get{ return tileTypes; } set { getTileType = value; } }
} 
