using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public static CharacterController CController;
	public static Controller Instance;
	
	public float angle;
	public bool UseTPCamera = true;
	public string CurrentCameraMode = "Third Person";

	void Awake() {
		CController = GetComponent("CharacterController") as CharacterController;
		Instance = this;
		if (UseTPCamera)
			TP_Camera.UseExistingOrCreateNewMainCamera();
	}
	
	void Update() {
		if (Camera.main == null)
			return;
		
		GetLocomotionInput();
		HandleActionInput();
		
		Motor.Instance.UpdateMotor();
	}
	
	void GetLocomotionInput() {
		var deadZone = 0.1f;
		
		Motor.Instance.VerticalVelocity = Motor.Instance.MoveVector.y;
		Motor.Instance.MoveVector = Vector3.zero;
		
		if (Input.GetAxisRaw("Vertical") > deadZone || Input.GetAxisRaw("Vertical") < -deadZone) {
			Motor.Instance.MoveVector += new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
		}
		
		if (Input.GetAxisRaw("Horizontal") > deadZone || Input.GetAxisRaw("Horizontal") < -deadZone) {
			Motor.Instance.MoveVector += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
		}
	}
	
	void HandleActionInput() {
		if (Input.GetButton("Jump")) {
			Motor.Instance.HoldingJump = true;
			//if (!Motor.Instance.melee)
				Jump();
		}
		else {
			Motor.Instance.HoldingJump = false;
		}
	}
	
	void Jump() {
		Motor.Instance.Jump();
	}
	
	void OnGUI() {
		//GUI.Label(new Rect(10,120,100,20), angle.ToString());
		//GUI.Label(new Rect(10,320,100,20), TP_Camera.Instance.CurrentCameraMode.ToString());
	}
}
