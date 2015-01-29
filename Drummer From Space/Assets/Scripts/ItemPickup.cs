using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour {
    
    private int zRotation = 0;
    private int prevZRotation = 0;
	public Transform itemToAdd;

    void Awake()
    {
    }

    void Update()
    {
        if (zRotation >= prevZRotation && zRotation < 15)
        {
            prevZRotation = zRotation++;
        }
        else if (zRotation > -15)
        {
            prevZRotation = zRotation--;
        }
        else
        {
            prevZRotation = zRotation;
        }
        transform.eulerAngles = new Vector3(0, 0, zRotation);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Contains ("Player"))
        {
			//pickup sound
			if (audio != null) {
				audio.Play ();
			} 
			else {
				Debug.LogError("No sound on this pickup!");
			}
			
			if(itemToAdd != null){
				Player player = other.GetComponent<Player> ();

				if(gameObject.CompareTag("Weapon")){

					player.AddWeapon(itemToAdd);
					Debug.Log("Picked up weapon.");

				}
				else if(gameObject.CompareTag("DrumPiece")){

					player.AddDrumPiece(itemToAdd);
					Debug.Log("Drum Piece picked up.");

				}
				else if (gameObject.CompareTag("Grenade")){
					player.AddGrenade(itemToAdd);
					Debug.Log ("Grenade picked up.");
				}
			}

			Destroy (this.gameObject);
        }
    }
}

