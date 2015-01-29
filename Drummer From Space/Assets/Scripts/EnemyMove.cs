using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float moveSpeed = 10f;
	public int destroyTime = 1;
	public Transform jetpackFirePrefab;
	Transform firePoint;
	Transform jetpackFireClone;

	void Awake(){
		if (moveSpeed != 0) {
			moveSpeed = moveSpeed * PlayerPrefs.GetFloat ("Difficulty");
		}
		firePoint = transform.FindChild("FirePoint");
		if (firePoint == null)
		{
			Debug.LogError("Uh Oh! No FirePoint under the enemy as a child.");
		}
		jetpackFireClone = Instantiate(jetpackFirePrefab, firePoint.position, firePoint.rotation) as Transform;
		jetpackFireClone.parent = firePoint;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
		Effect ();
		Destroy(gameObject,destroyTime);
	}
	void Effect(){

		float size = Random.Range(0.4f, 0.9f);
		jetpackFireClone.localScale = new Vector3(size, size, size);
	}
}
