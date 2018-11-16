using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	[SerializeField]
	GameObject bulletType;
	[SerializeField]
	private int detectRange = 3;
	[SerializeField]
	private int towerDamage;
	[SerializeField]
	private float attackSpeed;
	[SerializeField]
	float projectileSpeed;
	private GridMaster getTiles;
	private GameObject currentTarget;
	private Transform thisTower;
	[SerializeField]
	GameObject building;
	private List<Tile> tilesInRange = new List<Tile>();
	bool doIt = true;

	void Awake()
	{
		getTiles = GameObject.Find("Grid").GetComponent<GridMaster>();
		thisTower = gameObject.GetComponent<Transform>();
	}

	void Update()
	{
		if (doIt == true)
		{
			StartCoroutine("ShootAtTarget");
		}
	}

	//this checks enemys near the tower with use of the boxcast2d function
	private List<GameObject> CheckForEnemys(){
		RaycastHit2D[] allHits;
		List<GameObject> allEnemys = new List<GameObject>(); 
		allHits = Physics2D.BoxCastAll(transform.position, new Vector2(detectRange, detectRange), 0, Vector2.up);
		for(int i = 0; i < allHits.Length; i++){
			allEnemys.Add(allHits[i].transform.gameObject);
		}
		return allEnemys;
	}

	//this wil shoot at the closest target given with use of the checkforenemys function
	private IEnumerator ShootAtTarget()
	{
			GameObject currentTarget = CheckForEnemys()[0];
			List<GameObject> allBullets = new List<GameObject>();
			float distanceToEnemy = Vector2.Distance(transform.position, currentTarget.transform.position);
			AiUnitScript enemyStat = currentTarget.GetComponent<AiUnitScript>();
			while(distanceToEnemy < detectRange){
				currentTarget = CheckForEnemys()[0];
				allBullets.Add(Instantiate(bulletType, transform.position, Quaternion.identity));
				doIt = false;
				for(int i = 0; i < allBullets.Count; i++){
					if(allBullets[i].transform.position != currentTarget.transform.position){
						StartCoroutine(ProjectileLerp(allBullets[i].transform, currentTarget.transform, enemyStat));
					}
					allBullets.RemoveAt(i);
				}
				yield return new WaitForSeconds(attackSpeed);
			}
	}

	//this wil shoot projectile towards an enemy
	private IEnumerator ProjectileLerp(Transform projectile, Transform enemy, AiUnitScript enemyStat){
		float speed = 0;
		while(speed < 1){
			projectile.position = Vector2.Lerp(projectile.position, enemy.position, 0 + speed);
			speed += 0.01f;
			yield return new WaitForSeconds(projectileSpeed/10);
		}
		if (true)
		{
			Destroy(projectile.transform.gameObject);
		}
		Debug.Log(enemyStat.getHealth);
		enemyStat.getHealth =- towerDamage;
		if(enemyStat.getHealth < 0 || enemyStat.getHealth == 0){
			Destroy(enemy.transform.gameObject);
		}
		doIt = true;
	}
	
}
