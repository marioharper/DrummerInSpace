using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public int Damage = 10;
    public LayerMask whatToHit;
    public Transform BulletTrailPrefab;
    public Transform MuzzleFlashPrefab;
	public Transform BulletHitPrefab;

    public float effectSpawnRate = 10f;

    float timeToFire = 0;
    float timeToSpawnEffect = 0;
    Transform firePoint;

	void Awake () {
        firePoint = transform.FindChild("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("Uh Oh! No FirePoint under the Weapon as a child.");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

	}

    void Shoot()
    {
        // position of mouse in world
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        // position of firePoint in world
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        // start from firePoint go towards mouse
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        
        //if we can spawn
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }

        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 200, Color.cyan);
        
        //we hit something
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
			//we hit an enemy
			if(hit.collider.tag == "Enemy"){ 
				//get the enemies Enemy script
				Enemy theEnemy = hit.collider.gameObject.GetComponent<Enemy>();
				//create a hit
				Transform bulletHitClone = 	Instantiate(BulletHitPrefab, hit.point, firePoint.rotation)as Transform;
				bulletHitClone.parent = hit.collider.transform;
				//randomize the hit size
				float size = Random.Range(0.4f, 1.1f);
				bulletHitClone.localScale = new Vector3(size, size, size);
				//damage the enemy by weapon damage
				theEnemy.DamageEnemy(Damage);
			}
            Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage.");
        }
    }

    void Effect()
    {
		//fire sound
		if (audio != null) {
			audio.Play ();
		} 
		else {
			Debug.LogError("No shoot sound on this weapon!");
		}
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);
        Transform muzzleFlashClone = Instantiate(MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as Transform;
        muzzleFlashClone.parent = firePoint;
        float size = Random.Range(0.4f, 0.9f);
        muzzleFlashClone.localScale = new Vector3(size, size, size);
        Destroy(muzzleFlashClone.gameObject, 0.02f);
    }
}
