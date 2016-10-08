using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreMsgController : MonoBehaviour {

	public Canvas msgCanvas;
	private GameObject balanceManager;


	private GameObject[] allBtn;

	// Use this for initialization
	void Start () {
		balanceManager = GameObject.Find ("BalanceManager");
		allBtn = GameObject.FindGameObjectsWithTag ("BALL_PRICE");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void confirm(){
		msgCanvas.enabled = false;

	}
	public void buyThisBall(){
		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - PlayerPrefs.GetInt("INTENTED_BALL_PRICE"));
		PlayerPrefs.SetInt ("BOUGHT_BALL_" + PlayerPrefs.GetInt ("INTENTED_BALL_ID").ToString(), 1);
		
		balanceManager.SendMessage ("updateBalance");
		for(int i= 0; i<allBtn.Length; i++)allBtn[i].SendMessage("updateThePriceAndStateText");
		confirm ();
	}

	private void setThisBallAsActive(){
		PlayerPrefs.SetInt ("ACTIVE_BALL", PlayerPrefs.GetInt ("INTENTED_BALL_ID"));
	}


}
