using UnityEngine;
using UnityEngine.UI;
using System.Collections;


namespace UnitySampleAssets.CrossPlatformInput.PlatformSpecific
{
public class BallController : MonoBehaviour {


	public float hInput=0.0f;
	public float vInput=0.0f;


	//Vars for ground check
	bool isGrounded = false;
	public Transform groundCheck;
	public float groundRadius = 5.0f;
	public LayerMask whatIsGround;



	public float horizontalForce = 15.0f;
	public float verticalForce = 200.0f;

	private bool moveHorzRight = false;
	private bool moveHorzLeft = false;
	private bool ballJump = false;

	//public GameObject rayDrawingPosition;
	//public GameObject rayDrawingEndPosition;
	//public LayerMask ignoreLayerMask;
	//private float rayDist = 0.0f;

	public float distG = 1.50f;

	Vector3 groundCheckPos = new Vector3(0,0,0);



	public bool isPlayerDead = false;

	public Camera mainCamera;

	public GameObject[] ballBrokenParts;


	public Text coinText;
	private int coinAmount = 0;

	private float buttonHoldDownTime = 0;

	private float horzontalInputMultiplier = 0.0f;

	

	public AudioClip jumpingSound;



	public Image Life1;
	public Image Life2;
	public Image Life3;






		public GameObject dustParticleLeftToRight;
		public GameObject dustParticleRightToLeft;
		public float xOffsetLeftToRight = 0.3f;
		public float xOffsetRightToLeft = 0.3f;
		public float yOffset = -0.55f;

		private SpriteRenderer thisBallSpriteRenderer;

		public Sprite[] balls;

		private GameObject backMusic;

	// Use this for initialization
	void Start () {

        //LOAD THE ACTIVE BALL
		thisBallSpriteRenderer = GetComponent<SpriteRenderer>();
		thisBallSpriteRenderer.sprite = balls[PlayerPrefs.GetInt("ACTIVE_BALL")];

			backMusic = GameObject.Find ("Main Camera");

		
		coinAmount = PlayerPrefs.GetInt ("Coins");
		coinText.text = "$ " + coinAmount.ToString();
		int playerLife = PlayerPrefs.GetInt ("PLAYER_LIFE");
		if (playerLife < 3) {
				gameObject.transform.position = new Vector3(PlayerPrefs.GetFloat("CHKP_X"), PlayerPrefs.GetFloat("CHKP_Y"), PlayerPrefs.GetFloat("CHKP_Z"));
		}


		
		showLifeOnScreen ();
		#if UNITY_ANDROID
			horzontalInputMultiplier = 7000.0f;
		#endif

		#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
			horzontalInputMultiplier = 220.0f;
		
		#endif

	}



	private void showLifeOnScreen(){
			int playerLife = PlayerPrefs.GetInt ("PLAYER_LIFE");
			if (playerLife == 2)
			Life3.enabled = false;
		else if (playerLife == 1) {
			Life2.enabled = false;
			Life3.enabled = false;
		} else if (playerLife == 0) {
			Life1.enabled = false;
			Life2.enabled = false;
			Life3.enabled = false;
		}
	}

	public void touchJump(int j){
		if (j == 1) {
				ballJump = true;
				audio.PlayOneShot(jumpingSound);
			}
		else
			ballJump = false;
	}

	public void touchHorizontalMoveDown(int h){
		if (h == 1) {
				buttonHoldDownTime += Time.deltaTime;
				moveHorzRight = true;
			} /*else {
				buttonHoldDownTime = 0;
				moveHorzRight = false;
			}*/
	    if (h == -1) {
				buttonHoldDownTime += Time.deltaTime;
				moveHorzLeft = true;
			} /*else {

				moveHorzLeft = false;
			}*/
	}

		public void touchHorizontalMoveUp(int k){
			buttonHoldDownTime = 0;
			moveHorzLeft = false;
			moveHorzRight = false;
		}


	// Update is called once per frame
	void FixedUpdate () {

		isGrounded = Physics2D.OverlapCircle (groundCheckPos, 0.01f, whatIsGround);


		#if UNITY_ANDROID
			//hInput = CrossPlatformInputManager.GetAxis ("Horizontal");
				if (moveHorzRight)
					hInput = buttonHoldDownTime;
				else if (moveHorzLeft)
					hInput = -buttonHoldDownTime;
				else hInput = 0.0f;
				
				
		#endif

		#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
			hInput = Input.GetAxis ("Horizontal"); //FOR PC

		#endif


			hInput *= horizontalForce;

		if (isPlayerDead == false) {
			rigidbody2D.AddForce (new Vector2 (hInput*Time.deltaTime*horzontalInputMultiplier, 0));
			if (isGrounded && ballJump) {
				rigidbody2D.AddForce (new Vector2 (0, verticalForce*Time.deltaTime*60.0f));
			}
		}


		if (rigidbody2D.velocity.y > 8.0f)
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, 8.0f); 
		if (rigidbody2D.velocity.x > 5.0f)
			rigidbody2D.velocity = new Vector2 (5.0f, rigidbody2D.velocity.y);
		if (rigidbody2D.velocity.x < -5.0f)
			rigidbody2D.velocity = new Vector2 (-5.0f, rigidbody2D.velocity.y);





	}

	void Update(){
		if(isPlayerDead)rigidbody2D.velocity = new Vector3 (0,0,0);

		#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
			if (Input.GetKeyDown (KeyCode.UpArrow)){
				ballJump = true;
				audio.PlayOneShot(jumpingSound);
			}
			if (Input.GetKeyUp (KeyCode.UpArrow))
				ballJump = false;
		#endif

		groundCheckPos = new Vector3 (transform.position.x, transform.position.y-distG, transform.position.z);


		if (isGrounded) {
				if (rigidbody2D.velocity.x > 0.1) {
					GameObject go = Instantiate (dustParticleLeftToRight, new Vector2 (gameObject.transform.position.x + xOffsetLeftToRight, gameObject.transform.position.y + yOffset), dustParticleLeftToRight.transform.rotation) as GameObject;
					Destroy (go, .60f);
				} else if (rigidbody2D.velocity.x < -0.1) {
					GameObject go = Instantiate (dustParticleRightToLeft, new Vector2 (gameObject.transform.position.x + xOffsetRightToLeft, gameObject.transform.position.y + yOffset), dustParticleRightToLeft.transform.rotation) as GameObject;
					Destroy (go, .60f);
				}
		}

	}

	public void PlayerDead(){
			//Debug.Log ("Someone called player Dead...");
		PlayerPrefs.SetString ("LAST_LEVEL", Application.loadedLevelName);
		PlayerPrefs.SetInt ("PLAYER_LIFE", PlayerPrefs.GetInt("PLAYER_LIFE") - 1);

		rigidbody2D.velocity = new Vector3 (0,0,0);
		isPlayerDead = true;
		mainCamera.SendMessage ("StopFollowingCameraToBall");
		
			backMusic.audio.Stop ();

		Instantiate (ballBrokenParts[PlayerPrefs.GetInt("ACTIVE_BALL")], gameObject.transform.position, Quaternion.identity);
		Destroy (gameObject);
	}

	public void AddCoins(int amount){
		coinAmount += amount;
		coinText.text = "$ " + coinAmount.ToString ();
		PlayerPrefs.SetInt ("Coins", coinAmount);
	}


	public void DecreaseLifeByOne(){
			PlayerPrefs.SetInt ("PLAYER_LIFE", PlayerPrefs.GetInt("PLAYER_LIFE") - 1);
			showLifeOnScreen ();
	}


}

}
