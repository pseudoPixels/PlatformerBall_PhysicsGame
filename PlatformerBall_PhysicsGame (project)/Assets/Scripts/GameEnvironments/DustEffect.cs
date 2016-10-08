using UnityEngine;
using System.Collections;

public class DustEffect : MonoBehaviour {


	public GameObject dustParticleLeftToRight;
	public GameObject dustParticleRightToLeft;
	public float xOffsetLeftToRight = 0.3f;
	public float xOffsetRightToLeft = 0.3f;
	public float yOffset = -0.55f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (rigidbody2D.velocity.x > 0.1) {
			GameObject go = Instantiate (dustParticleLeftToRight, new Vector2 (gameObject.transform.position.x + xOffsetLeftToRight, gameObject.transform.position.y + yOffset), dustParticleLeftToRight.transform.rotation) as GameObject;
			Destroy (go, .60f);
		} else if (rigidbody2D.velocity.x < -0.1) {
			GameObject go = Instantiate (dustParticleRightToLeft, new Vector2 (gameObject.transform.position.x + xOffsetRightToLeft, gameObject.transform.position.y + yOffset), dustParticleRightToLeft.transform.rotation) as GameObject;
			Destroy (go, .60f);
		}
	}
}
