using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;
    Player player;                                      // Reference to the player;


	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
        player = GetComponent<Player>();
	}

    void Update ()
    {
        // Read the jump input in Update so button presses aren't missed.
#if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
#else
		if (Input.GetButtonDown("Jump")) jump = true;
#endif
        if (Input.GetButtonDown("E"))
        {
            
            int currentWeapon = player.playerStats.CurrentEquippedWeaponIndex;
            int weaponsSize = player.playerStats.Weapons.Count;

            if (weaponsSize == 0)
                return;
            if (currentWeapon < weaponsSize-1)
            {
                character.EquipWeapon(currentWeapon + 1);
            }
            else
            {
                character.EquipWeapon(0);
            }
        }
        if (Input.GetButtonDown("Q"))
        {
            
            int currentWeapon = player.playerStats.CurrentEquippedWeaponIndex;
            int weaponsSize = player.playerStats.Weapons.Count;

			if (weaponsSize == 0)
                return;
            if (currentWeapon > 0)
            {
                character.EquipWeapon(currentWeapon -1 );
            }
            else
            {
                character.EquipWeapon(weaponsSize -1);
            }
        }
		//if right mouse click
		if (Input.GetButtonDown ("Fire2")) 
		{
			ThrowGrenade();
		}

    }

	void FixedUpdate()
	{
		// Read the inputs.
		bool crouch = Input.GetKey(KeyCode.LeftControl);
		#if CROSS_PLATFORM_INPUT
		float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif

		// Pass all parameters to the character control script.
		character.Move( h, crouch , jump );

        // Reset the jump input once it has been used.
	    jump = false;
	}
	void ThrowGrenade()
	{
		int grenadeCount = player.playerStats.Grenades.Count;
		Debug.Log (grenadeCount);
		//if player has grenade
		if (grenadeCount > 0) 
		{
			Transform grenadeClone = Instantiate(player.playerStats.Grenades[grenadeCount-1], player.transform.position, player.transform.rotation) as Transform;

		}
	}
}
