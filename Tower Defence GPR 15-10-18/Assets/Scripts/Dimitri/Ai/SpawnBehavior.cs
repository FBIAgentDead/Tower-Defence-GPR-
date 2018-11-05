using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour {

	[SerializeField]
	private Directions[] spawnPath;
	[SerializeField]
	GameObject[] enemies;
	private AiUnit setPath;

	void Start()
	{
		StartCoroutine("spawnEnemies");
	}

	IEnumerator spawnEnemies()
	{
		GameObject currentEnemie = enemies[Random.Range(0, enemies.Length)];
		setPath = currentEnemie.GetComponent<AiUnit>();
		setPath.path = spawnPath;
		Instantiate(currentEnemie, transform.position, Quaternion.identity);
		yield return null;
	}
}
