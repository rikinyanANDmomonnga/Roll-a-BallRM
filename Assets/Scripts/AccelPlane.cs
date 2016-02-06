using UnityEngine;
using System.Collections;

public class AccelPlane : MonoBehaviour {
	void OnCollisionStay(Collision hit){
		if (hit.gameObject.CompareTag ("player")) {
			Rigidbody rbody = hit.rigidbody;
			Vector3 vel = rbody.velocity;
			rbody.velocity = new Vector3 ( vel.x + 1 , vel.y, vel.z );
		}
	}
}
