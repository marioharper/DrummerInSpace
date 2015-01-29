using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {

    public int rotationOffset = 90;

	GameObject thePlayer;
	PlatformerCharacter2D playerData;

	bool armLeft = false;

	void Start(){
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		playerData = thePlayer.GetComponent<PlatformerCharacter2D>();
	}
	// Update is called once per frame
	void Update () {


		//if using controller
			//use controller rotation
			//angle of vector2.up to right thumb input (0-180) (right)
			//check if vector2.x is <0 (360-angle)
			//apply
			//rigibody2d.moverotation(theangle);

		//else mouse rotation
        //subtracting pos of player from the mouse pos
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; 
        difference.Normalize();         //Normalizing the vector. Meaning that the sum of the vector will be equal to 1. 

        //find the angle in degrees
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //apply the rotation
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

		//flip the arm at certain degrees
		if (!playerData.facingRight && !armLeft) {
			Debug.Log ("flip arm");
			FlipArm ();
			armLeft = true;
		} else if (playerData.facingRight && armLeft) {
			FlipArm ();
			armLeft = false;
		}
    }

	void FlipArm(){
		transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);

	}
}
