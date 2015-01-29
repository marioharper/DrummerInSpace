using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	public int damage = 100;
	public int damageRadius = 1;
	public float explodeDelay = 2.0f;
	public Transform explosion;
	float startTime;
	CircleCollider2D grenadeCollider;

	// Use this for initialization
	void Start () {
		grenadeCollider = gameObject.GetComponent<CircleCollider2D> ();
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Start: "+startTime+" Time: " + Time.time + " Explode: " + (startTime + explodeDelay));
		//after 10 seconds, expand the circle collider
		if (Time.time >= (startTime + explodeDelay)) 
		{
			Debug.Log ("Grenade expand");
			CircleCollider2D explosionCollider = gameObject.AddComponent<CircleCollider2D>() as CircleCollider2D;
			explosionCollider.center = grenadeCollider.center;
			explosionCollider.isTrigger = true;
			explosionCollider.radius = damageRadius;

			Transform explosionClone = Instantiate(explosion, transform.position, transform.rotation) as Transform;
			Destroy(gameObject);
			Destroy(explosionClone.gameObject, 0.2f);

		}

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("Grenade hit something");
	}
}
