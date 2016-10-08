using UnityEngine;
using System.Collections;

public class Lock_Destroy_Self : MonoBehaviour {

	public void PlayerTouchedTheKey(){
		Destroy (gameObject);
	}
}
