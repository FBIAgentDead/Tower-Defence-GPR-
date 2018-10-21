using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour {
	
	[SerializeField]
	string scene1;
	[SerializeField]
	string scene2;
	Scene store;
	Scene game;

	void Awake()
	{
		store = SceneManager.GetSceneByName(scene1);
		game = SceneManager.GetSceneByName(scene2);	
	}

	public void SwitchScene(){
		SceneManager.LoadSceneAsync(0);
		if(SceneManager.sceneCount == 0)
			SceneManager.SetActiveScene(store);
		else
			SceneManager.SetActiveScene(game);
	}
}
