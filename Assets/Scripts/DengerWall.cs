using UnityEngine;
using System.Collections;

public class DengerWall : MonoBehaviour {
	void OnCollisionEnter(Collision hit){
		if (hit.gameObject.CompareTag ("player")) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
