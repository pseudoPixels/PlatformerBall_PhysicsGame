using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BalanceManager : MonoBehaviour {

	public Text balanceText;
	// Use this for initialization
	void Start () {
		balanceText.text = "Balance: $" + PlayerPrefs.GetInt ("Coins");
	}
	
	// Update is called once per frame
	void updateBalance () {
		balanceText.text = "Balance: $" + PlayerPrefs.GetInt ("Coins");
	}
}
