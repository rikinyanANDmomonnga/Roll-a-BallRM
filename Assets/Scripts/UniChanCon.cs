using UnityEngine;
using System.Collections;

public class UniChanCon : MonoBehaviour {
	CharacterController controller;
	Animator animator;
	Vector3 moveDirection=Vector3.zero;
	
	public float gravity;
	public float speedZ;
	public float speedJump;
	
	
	void Start () {
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator> ();
		
	}
	
	void Update ()
	{
		if (controller.isGrounded) {
			if(Input.GetAxis("Vertical")>0.0f){
				moveDirection.z=Input.GetAxis("Vertical")*speedZ;
			}else{
				moveDirection.z=0;
			}
		}
		transform.Rotate (0, Input.GetAxis ("Horizontal") , 0);
		if(Input.GetButton("Jump")){
			moveDirection.y=speedJump;
			animator.SetTrigger("Jump");
		}
		
		moveDirection.y -=gravity*Time.deltaTime;
		
		Vector3 globalDirection=transform.TransformDirection(moveDirection);
		controller.Move (globalDirection*Time.deltaTime);
		if (controller.isGrounded) {
			moveDirection.y = 0;
			animator.SetBool("Jump",moveDirection.y!=0);
		}
		Debug.Log("aiueo");

		animator.SetBool ("Run", moveDirection.z > 0.0f&&Input.GetAxis ("Horizontal")==0);
		animator.SetBool ("RunL", moveDirection.z > 0.0f&&Input.GetAxis ("Horizontal")<0);
		animator.SetBool ("RunR", moveDirection.z > 0.0f&&Input.GetAxis ("Horizontal")>0);
		animator.SetBool ("WalkL", moveDirection.z==0.0f&&Input.GetAxis ("Horizontal")<0);
		animator.SetBool ("WalkR", moveDirection.z==0.0f&&Input.GetAxis ("Horizontal")>0);
		
	}
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		// hit.gameObjectで衝突したオブジェクト情報が得られる
		if (hit.gameObject.CompareTag ("DangerWall")) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}