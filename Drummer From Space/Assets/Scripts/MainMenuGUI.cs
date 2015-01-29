using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	public string message = "";

	void Start(){
		//check if main song is created
		if (GameObject.FindGameObjectWithTag ("MainSong")) {
			//kill main song if true
			Destroy (GameObject.FindGameObjectWithTag ("MainSong"));
		}

		//reset all persistent values
		PlayerPrefs.SetInt ("DrumSetCount", 0);
		PlayerPrefs.SetInt ("Score", 0);
		PlayerPrefs.SetInt ("Lives", 0);
		PlayerPrefs.SetFloat ("Difficulty", 0f);
		PlayerPrefs.SetInt ("Multiplayer", 0);

		//do not reset the highscore, let it persist
		//PlayerPrefs.SetInt ("HighScore", 0);

	}

	void OnGUI(){

		var centeredBoxStyle = GUI.skin.GetStyle ("Box");
		centeredBoxStyle.alignment = TextAnchor.UpperCenter;
		var centeredButtonStyle = GUI.skin.GetStyle ("Button");
		centeredButtonStyle.alignment = TextAnchor.MiddleCenter;
		//Make a background box
		GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 350), message, centeredBoxStyle);

		if (GUI.Button (new Rect (Screen.width / 2 - 100 + (50), Screen.height / 2 - 100 + 0, 100, 50), "Easy", centeredButtonStyle)) {
			PlayerPrefs.SetFloat ("StartTime", Time.time);
			PlayerPrefs.SetFloat ("Difficulty" , 1.0f);
			PlayerPrefs.SetInt ("Lives", 5);
			if (audio != null) {
				audio.Play ();
			} 
			else {
				Debug.LogError("No sound on this button!");
			}
			Application.LoadLevel (1);

			
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100 + (50), Screen.height / 2 - 100 + 55, 100, 50), "Medium", centeredButtonStyle)) {
			PlayerPrefs.SetFloat ("StartTime", Time.time);
			PlayerPrefs.SetFloat ("Difficulty" , 1.5f);
			PlayerPrefs.SetInt ("Lives", 4);
			if (audio != null) {
				audio.Play ();
			} 
			else {
				Debug.LogError("No sound on this button!");
			}
			Application.LoadLevel (1);

		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100 + (50), Screen.height / 2 - 100 + 110, 100, 50), "Hard", centeredButtonStyle)) {
			PlayerPrefs.SetFloat ("StartTime", Time.time);
			PlayerPrefs.SetFloat ("Difficulty" , 2.0f);
			PlayerPrefs.SetInt ("Lives", 3);
			if (audio != null) {
				audio.Play ();
			} 
			else {
				Debug.LogError("No sound on this button!");
			}
			Application.LoadLevel (1);

		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100 + (50), Screen.height / 2 - 100 + 165, 100, 50), "Insane", centeredButtonStyle)) {
			PlayerPrefs.SetFloat ("StartTime", Time.time);
			PlayerPrefs.SetFloat ("Difficulty" , 3.0f);
			PlayerPrefs.SetInt ("Lives", 1);
			if (audio != null) {
				audio.Play ();
			} 
			else {
				Debug.LogError("No sound on this button!");
			}
			Application.LoadLevel (1);

		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100 + (50), Screen.height / 2 - 100 + 220, 100, 50), "Multiplayer", centeredButtonStyle)) {
			PlayerPrefs.SetFloat ("StartTime", Time.time);
			PlayerPrefs.SetFloat ("Difficulty" , 3.0f);
			PlayerPrefs.SetInt ("Lives", 4);
			PlayerPrefs.SetInt ("Multiplayer", 1);

			if (audio != null) {
				audio.Play ();
			} 
			else {
				Debug.LogError("No sound on this button!");
			}
			Application.LoadLevel (1);
			
		}
		
	}
	
	

}
