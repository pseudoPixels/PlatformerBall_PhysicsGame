using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour {


	public Button thisButton;
	public Image star1;
	public Image star2;
	public Image star3;



	public Sprite starActive;
	public Sprite starInactive;
	public Sprite lockedLevelStarInactive;

	public Sprite levelBackLocked;
	public Sprite levelBackUnLocked;

	private int numberOfCompletedLevels = 1;
	public int thisLevelNumber = 1;
	//public string nameOfSceneToLoad = "Level_01";

	//public AudioClip buttonClickSoundEffect;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("NUMBER_OF_COMP_LEVELS", 0);
		numberOfCompletedLevels = PlayerPrefs.GetInt ("NUMBER_OF_COMP_LEVELS");
		//if(numberOfCompletedLevels == 0) numberOfCompletedLevels +=1;


		//Show the appropriate background.
		if (thisLevelNumber <= numberOfCompletedLevels+1) {
			thisButton.image.sprite = levelBackUnLocked;
		}
		else thisButton.image.sprite = levelBackLocked;





		//show the stars earned
		if (thisLevelNumber <= numberOfCompletedLevels+1) {//this level has been unlocked.


			int starEarned = PlayerPrefs.GetInt ("STAR_EARNED_"+thisLevelNumber.ToString());
			//Debug.Log("STAR earned by " + thisLevelNumber.ToString() + " level = "+starEarned.ToString());

			star1.sprite = starInactive;
			star2.sprite = starInactive;
			star3.sprite = starInactive;

			if(starEarned == 1){
				star1.sprite = starActive;
			}else if(starEarned == 2){
				star1.sprite = starActive;
				star2.sprite = starActive;
			}else if(starEarned == 3){
				star1.sprite = starActive;
				star2.sprite = starActive;
				star3.sprite = starActive;
			}

		} 
		else { // this level is still locked... 
			star1.sprite = lockedLevelStarInactive;
			star2.sprite = lockedLevelStarInactive;
			star3.sprite = lockedLevelStarInactive;
		}









	}
	



	public void LoadThisLevel(){
		if (thisLevelNumber <= numberOfCompletedLevels+1) {
			//audio.PlayOneShot(buttonClickSoundEffect);
			PlayerPrefs.SetInt("PLAYER_LIFE", 3);
			PlayerPrefs.SetInt("CURRENT_LEVEL_SERIAL", thisLevelNumber);
			Application.LoadLevel(thisLevelNumber);
		}
	}


}
