using UnityEngine;
using System.Collections;


public class LoadLevelByName : MonoBehaviour {

	//private string[] levelNamesInSerial = new string[] {"Level_01", "Level_02_New", "Level_03_New"};
	public int totalNumOfAvailableLevels = 10;
	public void LoadLevelGivenTheName(string levelName){
		Application.LoadLevel (levelName);
	}

	public void RetryLevel(){
		//PlayerPrefs.SetInt("PLAYER_LIFE", 5);
		PlayerPrefs.SetInt("PLAYER_LIFE", 3);
		Application.LoadLevel (PlayerPrefs.GetInt("CURRENT_LEVEL_SERIAL"));

	}

	public void LoadNextLevel(){

		if (PlayerPrefs.GetInt ("CURRENT_LEVEL_SERIAL") + 1 <= totalNumOfAvailableLevels) {
			PlayerPrefs.SetInt("CURRENT_LEVEL_SERIAL", PlayerPrefs.GetInt ("CURRENT_LEVEL_SERIAL") + 1 );
			PlayerPrefs.SetInt("PLAYER_LIFE", 3);
			Application.LoadLevel (PlayerPrefs.GetInt("CURRENT_LEVEL_SERIAL"));

		}


		//PlayerPrefs.SetInt("PLAYER_LIFE", 5);
		//string lastLevelName = PlayerPrefs.GetString ("LAST_LEVEL");


		/*
		int lastLevelSerial = System.Array.IndexOf (levelNamesInSerial, lastLevelName);
		if (lastLevelSerial > -1 && lastLevelSerial < levelNamesInSerial.Length) {
			int nextLevel = lastLevelSerial + 1;
			LoadLevelGivenTheName(levelNamesInSerial[nextLevel]);
		}*/

	}

	public void rateThisApp(){
		Application.OpenURL("market://details?id=com.codespec.trapped");
	}
	public void visitMySocialPage(string webURL){
		Application.OpenURL(webURL);
	}

}
