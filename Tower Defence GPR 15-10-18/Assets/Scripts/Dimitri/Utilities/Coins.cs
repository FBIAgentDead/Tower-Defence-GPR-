using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

	private float coins;
	[SerializeField]
	Text displayMoney;
	public float PlayerCoins { get{ return coins; } set{ coins = value; } }

	void Update()
	{
		DisplayCoins();
	}

	private void DisplayCoins(){
		displayMoney.text = "Current Money: " + coins;
	}

}
