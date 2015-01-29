using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    [System.Serializable]
    //define player stats class
    public class PlayerStats{

        public int Health = 100;
        public List<Transform> Weapons = new List<Transform>();
		public List<Transform> Grenades = new List<Transform>();
		public int GrenadeCount = 3;
        public int CurrentEquippedWeaponIndex = -1;
        public Transform EquippedWeapon;

    }

    //instatiate the players stats
    public PlayerStats playerStats = new PlayerStats();
    
    public int fallBoundary = -20;

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
            DamagePlayer(99999999);
        }

    }

	public void AddWeapon(Transform weaponToAdd){
		playerStats.Weapons.Add(weaponToAdd);
	}

	public void AddDrumPiece(Transform pieceToAdd){
		GameMaster.gm.AddDrumPiece(pieceToAdd);
	}

	public void AddGrenade (Transform grenadeToAdd){
		playerStats.Grenades.Add (grenadeToAdd);
	}

    public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        if (playerStats.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }

    }
}
