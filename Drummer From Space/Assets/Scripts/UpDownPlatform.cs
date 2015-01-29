using UnityEngine;
using System.Collections;

public class UpDownPlatform : MonoBehaviour {
	public int upDownSpeed = 2;
	public int maxUpMovement = 10;
	public int maxDownMovement = 10;

	float startY;
	float prevY;

	// Use this for initialization
	void Start () {
		startY = this.transform.position.y;
		prevY = this.transform.position.y;


	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.y >= prevY && transform.position.y < startY + maxUpMovement) {
			prevY = transform.position.y;
			transform.Translate (Vector3.up * Time.deltaTime * upDownSpeed);
		} 
		else if (transform.position.y > startY - maxDownMovement) {
			prevY = transform.position.y;
			transform.Translate (Vector3.down * Time.deltaTime * upDownSpeed);
		} 
		else {
			prevY = transform.position.y;
		}
	}
}
