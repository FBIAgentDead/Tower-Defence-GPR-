using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoice : MonoBehaviour {
	[SerializeField]
	private Text choiceDisplay;

	//give the tag of the gameobject as parameter to instantiate specififc gameobject
	public void SetChoice(string a){
		
		if(PlayerPrefs.GetString("choice") == a){
			PlayerPrefs.SetString("choice", null);
		}
		else
		PlayerPrefs.SetString("choice", a);
	}
	void Update()
	{
		choiceDisplay.text = PlayerPrefs.GetString("choice");
	}
}
