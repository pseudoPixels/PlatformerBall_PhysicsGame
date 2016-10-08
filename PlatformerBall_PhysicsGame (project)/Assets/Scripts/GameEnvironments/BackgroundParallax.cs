using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {


	public Transform[] Backgrounds;
	public float parallaxScale;
	public float parallaxReductionFactor;
	public float smoothing;

	private Vector3 _lastPosition;
	// Use this for initialization
	void Start () {
		_lastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		var parallax = (_lastPosition.x - transform.position.x) * parallaxScale;

		for (int i=0; i< Backgrounds.Length; i++) {
			var backgroundTargetPos = Backgrounds[i].position.x +  parallax * (i* parallaxReductionFactor + 1);
			Backgrounds[i].position = Vector3.Lerp(Backgrounds[i].position,
			                                       new Vector3(backgroundTargetPos, Backgrounds[i].position.y, Backgrounds[i].position.z),
			                                       smoothing * Time.deltaTime
			                                       );
		}

		_lastPosition = transform.position;

	}
}
