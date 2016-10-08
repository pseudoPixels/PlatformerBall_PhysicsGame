using UnityEngine;
using System.Collections;

public class DistantKeyMsgSender : MonoBehaviour {

	public GameObject theLock;
	public GameObject visualKey;
	private SlideUpOnKeyDown sk;
	private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sk = theLock.GetComponent<SlideUpOnKeyDown> ();
		sr = visualKey.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D col){
		sk.SendMessage("UnlockYourself");
		sr.color = new Color (1.0f, 0,0,1.0f);
	}
	void OnTriggerExit2D(Collider2D col){
		sr.color = new Color (1.0f, 1.0f,1.0f,1.0f);
		sk.SendMessage("LockYourself");
	}
}
