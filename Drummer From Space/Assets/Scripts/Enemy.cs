using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	
	[System.Serializable]
	//define enemy stats class
	public class EnemyStats{
		
		public int Health = 100;
		public int TouchDamage = 10;
		public int KillValue = 10;

	}
	
	//instatiate the players stats
	public EnemyStats enemyStats = new EnemyStats();
	
	public int fallBoundary = -20;
	public AudioClip deathSound;

	void Awake()
	{

	}
	void Start()
	{
		
	}
	void Update()
	{
		//fall below screen
		if (transform.position.y <= fallBoundary)
		{
			Destroy (gameObject);
		}
		
	}

	
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag.Contains ("Player"))
		{
			
				Player player = other.gameObject.GetComponent<Player> ();
				player.DamagePlayer(enemyStats.TouchDamage);
				Debug.Log("Enemy hit player.");

		}
	}


	public void DamageEnemy(int damage)
	{
		//play noise
		audio.Play ();
		enemyStats.Health -= damage;
		if (enemyStats.Health <= 0)
		{
			GameMaster.KillEnemy(this, deathSound);
		}
	}
}
