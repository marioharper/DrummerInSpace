using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public Transform EnemyPrefab;
	public int upDownSpeed = 2;
	public int maxUpMovement = 10;
	public int maxDownMovement = 10;
	public float timeToSpawn = 0; 
	public float shortestTimeBetweenSpawn = 0f;
	public float longestTimeBetweenSpawn = 5f;
	public float destroyTime = 15f;

	public float startY;
	public float prevY;


	// Use this for initialization
	void Start () {
		startY = this.transform.position.y;
		prevY = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		//if single player automate movement
		if (PlayerPrefs.GetInt ("Multiplayer") == 0) {
						if (transform.position.y > prevY && transform.position.y < startY + maxUpMovement) {
								prevY = transform.position.y;
								transform.Translate (Vector3.up * Time.deltaTime * upDownSpeed);
						} else if (transform.position.y > startY - maxDownMovement) {
								prevY = transform.position.y;
								transform.Translate (Vector3.down * Time.deltaTime * upDownSpeed);
						} else {
								prevY = transform.position.y - 1;
						}

						if (Time.time > timeToSpawn) {
								float randomNum = Random.Range (shortestTimeBetweenSpawn, longestTimeBetweenSpawn);
								timeToSpawn = Time.time + 1 / randomNum;
								Spawn ();
						}
				}

	}

	public void Spawn(){
		Transform enemyClone = Instantiate(EnemyPrefab, this.transform.position, this.transform.rotation) as Transform;
		Destroy (enemyClone.gameObject, destroyTime);
	}
}
