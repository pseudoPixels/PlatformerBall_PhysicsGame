using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreMangement : MonoBehaviour {

	public int thisBallID;
	public int thisBallPrice;
	public Text ballPriceAndState;

	private GameObject balanceManager;


	public Canvas msgCanvas;
	public Text msgToMsgCanvas;


	public Canvas ballBuyConfirmationCanvas;

	private GameObject[] allBtn;
	// Use this for initialization
	void Start () {
		//PlayerPrefs.SetInt ("BOUGHT_BALL_" + thisBallID.ToString (), 0);
		//PlayerPrefs.SetInt ("Coins", 750);
		balanceManager = GameObject.Find ("BalanceManager");

		PlayerPrefs.SetInt ("BOUGHT_BALL_0", 1);
		updateThePriceAndStateText ();

		allBtn = GameObject.FindGameObjectsWithTag ("BALL_PRICE");



	

	}

	public void updateThePriceAndStateText(){
		if (isThisBallBoughtAlready () == false) {
			ballPriceAndState.text = "$ " + thisBallPrice.ToString();
		} 
		else {
			if(thisBallID == PlayerPrefs.GetInt ("ACTIVE_BALL")){
				ballPriceAndState.text = "Active" ;
				ballPriceAndState.color = Color.gray;
			}
			else {
				ballPriceAndState.text = "Unlocked" ;
				ballPriceAndState.color = Color.blue;
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void manageBallBuying(){

		if (isThisBallBoughtAlready () == true) {
			setThisBallAsActive ();
			msgCanvas.enabled = true;
			msgToMsgCanvas.text = "This Ball has been set \n as active now.";
			//bool noBallYetShownAsActive = true;
			for(int i= 0; i<allBtn.Length; i++){
				allBtn[i].SendMessage("updateThePriceAndStateText");
				//if(allBtn.G)
			}
			//updateThePriceAndStateText ();
		} 
		else {

			if (thisBallPrice <= getAvailableBalance ()) {
				buyThisBall ();
				setThisBallAsActive ();
			}
			else {
				msgCanvas.enabled = true;
				msgToMsgCanvas.text = "Sorry, You don't have enough money to buy this item !!!";

			}
		}
	}



	private void setThisBallAsActive(){
		PlayerPrefs.SetInt ("ACTIVE_BALL", thisBallID);
	}

	private int getAvailableBalance(){
		return PlayerPrefs.GetInt ("Coins");
	}

	private void buyThisBall(){
		ballBuyConfirmationCanvas.enabled = true;

		PlayerPrefs.SetInt ("INTENTED_BALL_PRICE",thisBallPrice);
		PlayerPrefs.SetInt ("INTENTED_BALL_ID",thisBallID);

		//PlayerPrefs.SetInt ("Coins", getAvailableBalance() - thisBallPrice);
		//PlayerPrefs.SetInt ("BOUGHT_BALL_" + thisBallID.ToString (), 1);

		//balanceManager.SendMessage ("updateBalance");
	}

	private bool isThisBallBoughtAlready(){
		if (PlayerPrefs.GetInt ("BOUGHT_BALL_" + thisBallID.ToString ()) <= 0)
			return false;

		return true;
	}


}
