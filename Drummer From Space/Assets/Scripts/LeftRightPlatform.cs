using UnityEngine;
using System.Collections;

public class LeftRightPlatform : MonoBehaviour {
	public int leftRightSpeed = 2;
	public int maxLeftMovement = 10;
	public int maxRightMovement = 10;

	float startX;
	float prevX;

	// Use this for initialization
	void Start () {
		startX = this.transform.position.x;
		prevX = this.transform.position.x;


	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.x >= prevX && transform.position.x < startX + maxRightMovement) {
			prevX = transform.position.x;
			transform.Translate (Vector3.right * Time.deltaTime * leftRightSpeed);
		} 
		else if (transform.position.x > startX - maxLeftMovement) {
			prevX = transform.position.x;
			transform.Translate (Vector3.left * Time.deltaTime * leftRightSpeed);
		} 
		else {
			prevX = transform.position.x;
		}
	}
}
