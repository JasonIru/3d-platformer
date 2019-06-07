using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {
	
	public static PlayerAnimation Instance;
	public Animator animator;

	void Start() {
		Instance = this;
		animator = this.GetComponent<Animator>();
	}
	
	void Update() {
		//if (!Motor.Instance.melee)
			ProcessAnimation();
	}
	
	void ProcessAnimation() {
		// Jumping
		if (Motor.CanJump)
			animator.SetInteger("Grounded", 1);
		else
			animator.SetInteger("Grounded", 0);
		
		animator.SetFloat("x", Input.GetAxis("Horizontal"));
		animator.SetFloat("y", Input.GetAxis("Vertical"));
		
		// Direction
		if (Input.GetAxisRaw("Vertical") > 0) {
			animator.SetFloat("dir", 0.5714286f);
			animator.SetBool("Moving", true);
		}
		if (Input.GetAxisRaw("Vertical") < 0) {
			animator.SetFloat("dir", 0f);
			animator.SetBool("Moving", true);
		}
		if (Input.GetAxisRaw("Horizontal") > 0) {
			animator.SetFloat("dir", 0.8571429f);
			animator.SetBool("Moving", true);
		}
		if (Input.GetAxisRaw("Horizontal") < 0) {
			animator.SetFloat("dir", 0.2857143f);
			animator.SetBool("Moving", true);
		}
		
		if (Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") > 0) {
			animator.SetFloat("dir", 0.7142857f);
			animator.SetBool("Moving", true);
		}
		if (Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") > 0) {
			animator.SetFloat("dir", 1f);
			animator.SetBool("Moving", true);
		}
		if (Input.GetAxisRaw("Vertical") > 0 && Input.GetAxisRaw("Horizontal") < 0) {
			animator.SetFloat("dir", 0.4285714f);
			animator.SetBool("Moving", true);
		}
		if (Input.GetAxisRaw("Vertical") < 0 && Input.GetAxisRaw("Horizontal") < 0) {
			animator.SetFloat("dir", 0.1428571f);
			animator.SetBool("Moving", true);
		}
		
		if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
			animator.SetBool("Moving", false);
		
		// Moving
		/*if (Controller.CController.velocity != Vector3.zero) {
			animator.SetBool("Moving", true);
		}
		else {
			animator.SetBool("Moving", false);
		}*/
		/*Vector3 HorizontalVelocity = Controller.CController.velocity;
		HorizontalVelocity = new Vector3(Controller.CController.velocity.x, 0, Controller.CController.velocity.z);*/
		
		/*Vector3 HorizontalVelocity = Controller.CController.velocity;
		HorizontalVelocity = new Vector3(Controller.CController.velocity.x, 0, Controller.CController.velocity.z);*/
		
		/*if (Controller.CController.velocity.y != 0) {
			animator.SetBool("Grounded", false);
		}
		else {
			animator.SetBool("Grounded", true);
		}*/
		
		/*if (HorizontalVelocity == Vector3.zero) {
			animator.SetBool("Moving", true);
		}
		else {
			animator.SetBool("Moving", false);
		}*/
	}
	
	void OnGUI() {
		//GUI.Label(new Rect(10,30,100,20), animator.GetFloat("dir").ToString());
	}
}
