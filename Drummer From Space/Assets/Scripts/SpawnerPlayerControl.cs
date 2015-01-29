using UnityEngine;
using System.Collections;

public class SpawnerPlayerControl : MonoBehaviour {

	public bool playerControlled = false;
	private EnemySpawner theEnemySpawner;
	private LineRenderer theLine;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("Multiplayer") == 1) {
			playerControlled = true;
		}
		theEnemySpawner = this.gameObject.GetComponent<EnemySpawner> ();
		theLine = this.gameObject.GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

				if (playerControlled) {
						Vector3 currentPos = this.transform.position;
						Vector3 pointToPos = new Vector3 (currentPos.x -100, currentPos.y, currentPos.z);
						//set line
						theLine.SetPosition (0, currentPos);
						theLine.SetPosition (1, pointToPos);
						if (Input.GetKey ("up") && transform.position.y < theEnemySpawner.startY + theEnemySpawner.maxUpMovement) {
								transform.Translate (Vector3.up * Time.deltaTime * theEnemySpawner.upDownSpeed);	
						}
						if (Input.GetKey ("down") && transform.position.y > theEnemySpawner.startY - theEnemySpawner.maxDownMovement) {
								transform.Translate (Vector3.down * Time.deltaTime * theEnemySpawner.upDownSpeed);	
						}
						if (Input.GetKeyDown ("left")) {
							theEnemySpawner.Spawn();
						}
				}
		}
}
