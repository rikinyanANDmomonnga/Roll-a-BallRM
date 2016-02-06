using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;

	void FixedUpdate(){
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");

		Rigidbody rbody = GetComponent<Rigidbody> ();

		rbody.AddForce (x*speed, 0, z*speed);
	}
}
