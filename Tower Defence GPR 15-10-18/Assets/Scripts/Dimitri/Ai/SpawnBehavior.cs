using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehavior : MonoBehaviour {

	[SerializeField]
	private Directions[] spawnPath;
	[SerializeField]
	GameObject[] enemies;
	private AiUnitScript setPath;
	[SerializeField]
	private float respawnTime;
	[SerializeField]
	GameObject parentEnemies;

	void Start()
	{
		StartCoroutine("spawnEnemies");
	}

	IEnumerator spawnEnemies()
	{
		while(true){
			GameObject currentEnemie = enemies[Random.Range(0, enemies.Length)];
			setPath = currentEnemie.GetComponent<AiUnitScript>();
			setPath.path = spawnPath;
			GameObject enenmieClone = Instantiate(currentEnemie, transform.position, Quaternion.identity);
            enenmieClone.transform.SetParent(parentEnemies.transform);
			yield return new WaitForSeconds(respawnTime);
		}
	}
}
