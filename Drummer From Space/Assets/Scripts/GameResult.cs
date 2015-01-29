using UnityEngine;
using System.Collections;
using System.Timers;
using System;
using System.Collections.Generic;

public class GameResult : MonoBehaviour {
	float playTime;
	int setItems;
	float difficulty;
	int playerScore;
	int highScore;
	int playerLives;

	void Start(){
		//check if main song is created
		if (GameObject.FindGameObjectWithTag ("MainSong")) {
			Destroy (GameObject.FindGameObjectWithTag ("MainSong"));
		}

		//get players game score
		playerScore = PlayerPrefs.GetInt ("Score");
		//get the difficulty
		difficulty = PlayerPrefs.GetFloat ("Difficulty");
		//get the #of items collected
		setItems = PlayerPrefs.GetInt ("DrumSetCount");

		//get the playing time
		playTime = Time.time;
		playTime = (float)(Math.Truncate((double)((playTime - PlayerPrefs.GetFloat("StartTime"))*1)) / 1);

		//calculate players total score
		playerScore = (int)(playerScore * difficulty + (setItems * 200) - (playTime * .05));
		//if a highscore exists and the players score is higher than the highscore
		//or if a highscore doesnt exist
		if(PlayerPrefs.HasKey("HighScore") && playerScore > PlayerPrefs.GetInt("HighScore") || !PlayerPrefs.HasKey("HighScore")){
				//assign the players score as the new highscore
				PlayerPrefs.SetInt("HighScore", playerScore);
		}
		//Highscore exists and is larger than players score, so do nothing
		else
		{
		}

		highScore = PlayerPrefs.GetInt ("HighScore");
	}

	void OnDestroy(){
		if (playerScore == PlayerPrefs.GetInt ("HighScore") || !PlayerPrefs.HasKey("HighScorer")) {
						PlayerPrefs.SetString ("HighScorer", highScorer);
				}
	}
	public string highScorer = "Your Name";

	void OnGUI(){
		//if beat game
		if (setItems == 3) {
			GUI.Box (new Rect (Screen.width / 2 -150, Screen.height/2 - 45 - 100, 300, 90), "You've collected all the pieces!");
		}
		else {
			GUI.Box (new Rect (Screen.width / 2 - 150, Screen.height/2 - 45 - 100, 300, 90), "You didn't collect all of the pieces!");
		}

		if (playerScore == PlayerPrefs.GetInt("HighScore")|| !PlayerPrefs.HasKey("HighScorer")) {
			GUI.Box (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 24 - 100, 100, 24), "New high score!");
			highScorer = GUI.TextField (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 12 - 75, 200, 24), highScorer, 25);
		}

				//player played a game
				if (PlayerPrefs.HasKey("Score")) {
						//show results
						//Make a background box
						GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height/2 - 45, 200, 90), "Your Score: " + playerScore +
			         		System.Environment.NewLine+
			         		"High Score: " + highScore+
			         		System.Environment.NewLine +
			                "By: " + PlayerPrefs.GetString("HighScorer")+
							System.Environment.NewLine + 
			         		System.Environment.NewLine + 
							"Your Time: " + playTime 
							);
				}
		if (GUI.Button (new Rect (Screen.width / 2 - 60, Screen.height/2 - 10 - 175 ,120,20), "Save/Main Menu")) {
			Application.LoadLevel (0);
		}
		}
}
