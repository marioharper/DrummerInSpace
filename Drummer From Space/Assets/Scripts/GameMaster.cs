using UnityEngine;
using System.Collections;
using System.Timers;
using System;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm;

    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }

		RespawnWeaponPickups ();

	}
	

	void Update(){

	}

	void OnDestroy(){
	}

    public Transform playerPrefab;
	public Transform handGunPickupPrefab;
	public Transform machineGunPickupPrefab;
    public Transform spawnPoint;
	public Transform spawnParticles;
    public int spawnDelay = 5;

    public IEnumerator RespawnPlayer()
    {
		Transform particleClone = Instantiate(spawnParticles, spawnPoint.position, spawnPoint.rotation) as Transform;
        Debug.Log("ToDo: Add waiting for spawn sound");
        yield return new WaitForSeconds(spawnDelay);
		Destroy (particleClone.gameObject);
		RespawnWeaponPickups ();
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("ToDo: add spawn particles");
    }
	public void RespawnWeaponPickups(){
		//remove all weapons
		RemoveWeapons ();
		//respawn all weapon pickups
		GameObject[] WeaponRespawns = GameObject.FindGameObjectsWithTag ("WeaponSpawn");
		foreach (GameObject respawn in WeaponRespawns) {
			if(respawn.name == "HandGunSpawn"){
				Instantiate(handGunPickupPrefab, respawn.transform.position, respawn.transform.rotation);
			}
			else if(respawn.name == "MachineGunSpawn"){
				Instantiate(machineGunPickupPrefab, respawn.transform.position, respawn.transform.rotation);
			}
		}
		Debug.Log ("Respawned all weapons");
	}

	public void RemoveWeapons(){
		//remove all weapons
		GameObject[] Weapons = GameObject.FindGameObjectsWithTag ("Weapon");
		foreach (GameObject weapon in Weapons) {
			Destroy (weapon.gameObject);
		}

		Debug.Log ("Removed all weapons");
	}

	public static void updateScore(int num){

		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + num);
	}

	public  void AddDrumPiece(Transform pieceToAdd){
		if (pieceToAdd.gameObject.name == "Bass") {
			PlayerPrefs.SetInt("DrumSetCount", 1);
			Application.LoadLevel (2);
		} 
		else if (pieceToAdd.gameObject.name == "Snare") {
			PlayerPrefs.SetInt("DrumSetCount", 2);
			Application.LoadLevel (3);
		}
		else if (pieceToAdd.gameObject.name == "Cymbal") {
			PlayerPrefs.SetInt("DrumSetCount", 3);
			Application.LoadLevel (4);
		} 


	}

    public static void KillPlayer(Player player)
    {
		if (PlayerPrefs.GetInt("Lives") == 1) {
			Application.LoadLevel (4);
		} 
		else {
			PlayerPrefs.SetInt("Lives",PlayerPrefs.GetInt("Lives") - 1);
			Destroy (player.gameObject);
			gm.StartCoroutine (gm.RespawnPlayer ());
		}
    }
	public static void KillEnemy(Enemy enemy, AudioClip deathSound)
	{
		AudioSource temp = enemy.gameObject.AddComponent<AudioSource> ();
		temp.clip = deathSound;
		temp.volume = 1;
		temp.Play ();

		Rigidbody2D enemiesRigibody = enemy.gameObject.AddComponent<Rigidbody2D> ();//add rigibody
		enemiesRigibody.mass = 1;
		enemiesRigibody.gravityScale = 3;
		enemy.GetComponent<EnemyMove> ().moveSpeed = 2;
		enemy.enemyStats.TouchDamage = 0;
		updateScore (enemy.GetComponent<Enemy>().enemyStats.KillValue);
		Debug.Log ("ToDo:add destroy stuff");
	}
}
