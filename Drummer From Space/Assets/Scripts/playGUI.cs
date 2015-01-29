using UnityEngine;
using System.Collections;
using System.Timers;
using System;
using System.Collections.Generic;

public class playGUI : MonoBehaviour {

	Transform thePlayer;
	float nextTimeToSearchForPlayer = 0;
	Player player;

	void OnGUI(){

		float playTime = Time.time;
		playTime = (float)(Math.Truncate((double)((playTime - PlayerPrefs.GetFloat("StartTime"))*1)) / 1);

		if (GUI.Button (new Rect (105,40,80,20), "Main Menu")) {
			Application.LoadLevel (0);
		}

		if (thePlayer == null)
		{
			FindPlayer();
			return;
		}

		//Start timer
		//Make a background box
		GUI.Box (new Rect (Screen.width / 2 - 45, Screen.height - 100, 100, 90), "Health: " + player.playerStats.Health.ToString()+
		         System.Environment.NewLine + 
		         "Score: "+ PlayerPrefs.GetInt("Score") +
		         System.Environment.NewLine + 
		         "Time: " + playTime +
		         System.Environment.NewLine +
		         "Lives: " + PlayerPrefs.GetInt("Lives"));



	}


	void FindPlayer()
	{
		if (nextTimeToSearchForPlayer <= Time.time)
		{
			GameObject searchResult = GameObject.FindGameObjectWithTag("Player");
			if (searchResult != null)
			{
				thePlayer = searchResult.transform;
				player = thePlayer.transform.GetComponent<Player>();
				nextTimeToSearchForPlayer = Time.time + 0.5f;
			}
		}
	}
}
