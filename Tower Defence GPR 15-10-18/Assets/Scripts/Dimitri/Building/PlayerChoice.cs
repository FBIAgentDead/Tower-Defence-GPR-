using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChoice : MonoBehaviour {
	[SerializeField]
	private Text choiceDisplay;
    //Start the game without a selection
    private void Awake()
    {
        PlayerPrefs.SetString("choice", null);
        choiceDisplay.text = "Nothing Selected";
    }
    //give the tag of the gameobject as parameter to instantiate specififc gameobject
    public void SetChoice(string a){

        if (PlayerPrefs.GetString("choice") == a)
        {
            PlayerPrefs.SetString("choice", null);
            choiceDisplay.text = "Nothing Selected";
        }
        else
        {
            PlayerPrefs.SetString("choice", a);
            choiceDisplay.text = PlayerPrefs.GetString("choice");
        }
    }
}
