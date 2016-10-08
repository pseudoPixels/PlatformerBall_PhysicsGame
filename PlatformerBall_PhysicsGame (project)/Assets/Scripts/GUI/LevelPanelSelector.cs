using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelPanelSelector : MonoBehaviour {


	public GameObject[] levelGroups;
	private int currentLevelPanel = 0;
	public Button rightButton;
	public Sprite fadeRight;
	public Sprite normalRight;

	public Button leftButton;
	public Sprite fadeLeft;
	public Sprite normalLeft;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Total Panels: " + gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadNextPanel(){
		//Debug.Log ("Loading Next Panel");
		//levelGroups [0].SetActive (false);
		//levelGroups [1].SetActive (true);
		if ((currentLevelPanel + 1) <= (levelGroups.Length-1)) {
			currentLevelPanel += 1;
			LoadPanel(currentLevelPanel);
		}

		
	}

	public void LoadPreviousPanel(){
		if ((currentLevelPanel - 1) >= 0) {
			currentLevelPanel -= 1;
			LoadPanel(currentLevelPanel);
		}


	}

	private void LoadPanel(int panelSerial){
		for (int i=1; i<=levelGroups.Length; i++) {
			levelGroups[i-1].SetActive(false);
		}
		levelGroups [panelSerial].SetActive (true);

		if(currentLevelPanel == (levelGroups.Length-1))rightButton.image.sprite = fadeRight;
		else rightButton.image.sprite = normalRight;
		
		if(currentLevelPanel == 0)leftButton.image.sprite = fadeLeft;
		else leftButton.image.sprite = normalLeft;


	}

}
