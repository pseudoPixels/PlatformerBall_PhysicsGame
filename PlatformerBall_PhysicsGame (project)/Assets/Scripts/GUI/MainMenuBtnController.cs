using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuBtnController : MonoBehaviour {

	public Canvas quitPopUp;
	private bool isPopUpShowing = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ConfirmUserQuit(){
		if (isPopUpShowing == false) {
			isPopUpShowing = true;
			quitPopUp.enabled = true;
		} else if (isPopUpShowing == true) {
			DoNotQuit();
		}

	}

	public void DoNotQuit(){
		isPopUpShowing = false;
		quitPopUp.enabled = false;
	}

	public void QuitThisGame(){
		Application.Quit ();
	}


}
