using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform ball;
	Vector3 ballPosition;

	private bool isPlayerDead = false;

	public GameObject bloodOnScreen;
	public GameObject bloodParticleEffect;
	// Use this for initialization
	void Start () {
		ballPosition = ball.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPlayerDead) {
			ballPosition = new Vector3 (ball.transform.position.x, ball.transform.position.y+1.0f, transform.position.z);
			transform.position = ballPosition;
		}
	}

	public void StopFollowingCameraToBall(){
		isPlayerDead = true;
		Instantiate(bloodParticleEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z+2.0f), Quaternion.identity);
		Resize (bloodOnScreen);
		bloodOnScreen.SetActive (true);
	}


	void Resize(GameObject bloodSplatter)
	{
		SpriteRenderer sr=bloodSplatter.GetComponent<SpriteRenderer>();
		if(sr==null) return;
		
		bloodSplatter.transform.localScale=new Vector3(1,1,1);
		
		float width=sr.sprite.bounds.size.x;
		float height=sr.sprite.bounds.size.y;
		
		
		float worldScreenHeight=Camera.main.orthographicSize*2f;
		float worldScreenWidth=worldScreenHeight/Screen.height*Screen.width;
		
		Vector3 xWidth = bloodSplatter.transform.localScale;
		xWidth.x=worldScreenWidth / width;
		bloodSplatter.transform.localScale=xWidth;
		//transform.localScale.x = worldScreenWidth / width;
		Vector3 yHeight = bloodSplatter.transform.localScale;
		yHeight.y=worldScreenHeight / height;
		bloodSplatter.transform.localScale=yHeight;
		//transform.localScale.y = worldScreenHeight / height;
		
	}
}
