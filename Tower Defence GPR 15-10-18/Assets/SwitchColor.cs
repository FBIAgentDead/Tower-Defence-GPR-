using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchColor : MonoBehaviour {

	[SerializeField]
	Material color;
	int random;
	Color b;
	void Update()
	{
		if(Input.GetKey(KeyCode.DownArrow)){
			random = Random.Range(0,5);
			color.color = new Color(random,0,0);
		}
	}
}
