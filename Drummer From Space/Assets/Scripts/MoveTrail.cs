using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {

    public int moveSpeed = 1;
    public int destroyTime = 1;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject,destroyTime);
	}

	void OnCollisionEnter2D(Collision2D other)
	{

			Debug.Log ("trailHit: " + other.gameObject.name);
			Destroy (this.gameObject);

	}
}
