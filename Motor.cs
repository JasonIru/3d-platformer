using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

	public static Motor Instance;
	
	public GameObject spr;
	public GameObject Punch;
	public GameObject txt;
	public Animator animator;
	
	public float MoveSpeed = 15f;
	public float JumpSpeed = 12f;
	public float MaxJumpSpeed = 18;
	public float Gravity = 41f;
	public float TerminalVelocity = 40f;
	public float JumpSpeedIncrement = 1f;
	public float AimSensitivity = 5f;
	public string CurrentCameraMode = "Third Person";
	private float mouseX = 0f;
	private float mouseY = 0f;
	public float Y_MinLimit = -40f;
	public float Y_MaxLimit = 40f;
	
	public bool HasJetpack = true;
	public float JetpackFuel;
	public float JetpackFuelMax = 1000f;
	public float JetpackFuelIncrement = 5f;
	public float JetpackFuelDecrement = 10f;
	public float JetpackSpeed = 3f;
	
	public Vector3 MoveVector { get; set; }
	public float VerticalVelocity { get; set; }
	
	public float CheckJump = 1.5f;
	public Vector3 test = new Vector3(0, 3, 0);
	public static bool CanJump = false;
	public bool melee = false;
	public float MaxMeleeTimer = 3f;
	public bool HoldingJump = false;
	public bool ButtonReleased = false;
	public int meleeCombo = 0;
	public int currentMeleeCombo = 0;
	public bool Invincible = false;
	public float MaxInvincibleTimer = 1f;
	public int MaxAirMeleeCombo = 3;
	public int currentAirMeleeCombo = 0;
	public float MaxInvincibleCount = 1f;
	
	private float meleeTimer = 0f;
	//private bool sneaking = false;
	//private float currentJumpIncrement = 0f;
	private float invincibleTimer = 0f;
	
	void Awake() {
		Instance = this;
		animator = spr.GetComponent<Animator>();
		JetpackFuel = JetpackFuelMax;
	}
	
	public void UpdateMotor() {
		PlayerInvincibility();
		SnapAlignCharacterWithCamera();
		if (!melee) {
			meleeCombo = 0;
			ProcessMotion();
		}
		
		if (Input.GetButtonDown("Fire1") && Controller.Instance.CurrentCameraMode == "Third Person") {
			if (meleeCombo < 3) {
			//if (!melee && CanJump) {
			//if (!melee) {
				meleeCombo += 1;
				PlayerMelee();
			}
		}
		/*else {
			meleeCombo = 0;
		}*/
		if (melee) {
			PlayerMelee();
		}
	}
	
	void ProcessMotion() {
		// Transform MoveVector to World Space
		MoveVector = transform.TransformDirection(MoveVector);
		
		// Normalize MoveVector if Magnitude > 1
		if (MoveVector.magnitude > 1)
			MoveVector = Vector3.Normalize(MoveVector);
		
		// Multiply MoveVector by MoveSpeed
		MoveVector *= MoveSpeed;
		
		// Reapply VerticalVelocity MoveVector.y
		MoveVector = new Vector3(MoveVector.x, VerticalVelocity, MoveVector.z);
		
		// Apply gravity
		ApplyGravity();
		
		// Move the Character in World Space
		Controller.CController.Move(MoveVector * Time.deltaTime);
		
		//Debug.DrawRay(transform.position, -test * 2.0f, Color.yellow);
		CheckIfCanJump();
		ButtonReleased = CheckIfButtonReleased();
		
		//RotatePlayer();
		
		CheckSneak();
		
		RefillJetpack();
	}
	
	void RotatePlayer() {
		if (CurrentCameraMode == "First Person") {
			mouseX += Input.GetAxis("Mouse X") * AimSensitivity;
			mouseY -= Input.GetAxis("Mouse Y") * AimSensitivity;
			
			mouseY = Helper.ClampAngle(mouseY, Y_MinLimit, Y_MaxLimit);
			Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
			
			/*Camera.main.transform.Rotate(new Vector3(0, mouseX, 0));
			Camera.main.transform.Rotate(new Vector3(0, 0, -mouseX));
			Camera.main.transform.Rotate(new Vector3(-mouseY, 0, 0));
			Camera.main.transform.Rotate(new Vector3(0, 0, mouseY));*/
			Camera.main.transform.rotation = rotation;
		}
	}
	
	void ApplyGravity() {
		if (MoveVector.y > -TerminalVelocity)
			MoveVector = new Vector3(MoveVector.x, MoveVector.y - Gravity * Time.deltaTime, MoveVector.z);
	
		if (Controller.CController.isGrounded && MoveVector.y < -1) 
			MoveVector = new Vector3(MoveVector.x, -1, MoveVector.z);
	}
	
	public void NegateVerticalVelocity() {
		MoveVector = new Vector3(MoveVector.x, -1, MoveVector.z);
	}
	
	public void PlayerTakeDamage(int dmg) {
		if (!Invincible) {
			/*if (CanJump) {
				animator.SetBool("Moving", false);
				animator.SetInteger("Direction", 4);
				animator.SetBool("Melee", false);
				animator.SetBool("Damaged", true);
			}*/
			
			PlayerStats.Instance.health -= dmg;
			Invincible = true;
			
			Vector3 txtPos = transform.position + transform.up * 3;
			
			GameObject dmgText = Instantiate(txt, txtPos, transform.rotation) as GameObject;
			dmgText.GetComponent<TextMesh>().text = dmg.ToString();
		}
	}
	
	void PlayerInvincibility() {
		if (!Invincible)
			return;
		else {
			invincibleTimer += 1f * Time.deltaTime;
			
			if (invincibleTimer >= 0f && invincibleTimer < (MaxInvincibleCount / 3f))
				spr.GetComponent<Renderer>().enabled = false;
			else if (invincibleTimer >= (MaxInvincibleCount / 3f) && invincibleTimer < ((MaxInvincibleCount / 3f) * 2f))
				spr.GetComponent<Renderer>().enabled = true;
			else if (invincibleTimer >= ((MaxInvincibleCount / 3f) * 2f) && invincibleTimer < MaxInvincibleCount)
				spr.GetComponent<Renderer>().enabled = false;
			else
				spr.GetComponent<Renderer>().enabled = true;
			
			if (invincibleTimer >=  MaxInvincibleTimer) {
				invincibleTimer = 0f;
				Invincible = false;
				spr.GetComponent<Renderer>().enabled = true;
			}
		}
	} 
	
	void PlayerMelee() {
		/*if (!CanJump) {
			melee = false;
			return;
		}*/
		
		//TP_Camera.Instance.Reset();
		
		
		
		if (meleeTimer == 0) {
			if (CanJump) {
				Instantiate(Punch, transform.position + transform.forward, transform.rotation);
				melee = true;
				
				animator.SetBool("Moving", false);
				animator.SetInteger("Direction", 4);
				animator.SetBool("Melee", true);
			}
			else {
				if (currentAirMeleeCombo < MaxAirMeleeCombo) {
					Instantiate(Punch, transform.position + transform.forward, transform.rotation);
					currentAirMeleeCombo += 1;
					
					melee = true;
					
					animator.SetBool("Moving", false);
					animator.SetInteger("Direction", 4);
					animator.SetBool("Melee", true);
				}
				else
					meleeTimer = MaxMeleeTimer;
			}
		}
		
		meleeTimer += 1f * Time.deltaTime;
		
		if (meleeTimer >= MaxMeleeTimer) {
			currentMeleeCombo += 1;
			if (currentMeleeCombo >= meleeCombo) {
				meleeTimer = 0f;
				currentMeleeCombo = 0;
				animator.SetInteger("Combo", currentMeleeCombo);
				melee = false;
				animator.SetBool("Melee", false);
			}
			else {
				meleeTimer = 0f;
				animator.SetInteger("Combo", currentMeleeCombo);
			}
		}
	}
	
	void CheckIfCanJump() {
		RaycastHit hitInfo;
		
		if (!CanJump)
			if (!Controller.CController.isGrounded)
				return;
		
		// Works well up to ramps at 37 degrees when set to 3.0f
		if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 3.0f ) || Controller.CController.isGrounded) {
			CanJump = true;
			HoldingJump = false;
			currentAirMeleeCombo = 0;
			//ButtonReleased = false;
			//currentJumpIncrement = 0f;
		}
		else {
			CanJump = false;
		}
	}
	
	public bool ReturnCanJump() {
		return CanJump;
	}
	
	public void CheckSneak() {
		if (Input.GetButton("Fire1")) {
			//sneaking = true;
			MoveSpeed = 7.5f;
		}
		else {
			//sneaking = false;
			MoveSpeed = 15f;
		}
	}
	
	public void Jump() {
		if (CanJump) {
			VerticalVelocity = JumpSpeed;
			CanJump = false;
		}
		else {
			//if (VerticalVelocity >= 0 && currentJumpIncrement < MaxJumpSpeed) {
			if (HasJetpack && JetpackFuel > 0) {
				//VerticalVelocity += JumpSpeedIncrement;
				//currentJumpIncrement += JumpSpeedIncrement;
				//VerticalVelocity = JetpackSpeed * 5;
				if (!ButtonReleased) {
					VerticalVelocity += JetpackSpeed;
					JetpackFuel -= JetpackFuelDecrement;
					JetpackFuel = Mathf.Clamp(JetpackFuel, 0, JetpackFuelMax);
				}
			}
		}
	}
	
	public bool CheckIfButtonReleased() {
		if (!HoldingJump) {
			if (!CanJump) {
				return true;
			}
			else
				return false;
		}
		if (HoldingJump && ButtonReleased) {
			return true;
		}
		return false;
	}
	
	public void RefillJetpack() {
		if (CanJump) {
		//if (VerticalVelocity <= 0) {
			//JetpackFuel += JetpackFuelIncrement;
			JetpackFuel += JetpackFuelMax;
			JetpackFuel = Mathf.Clamp(JetpackFuel, 0, JetpackFuelMax);
		}
	}
	
	public void SnapAlignCharacterWithCamera() {
		if (MoveVector.x != 0 || MoveVector.z != 0){
			transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 
												  Camera.main.transform.eulerAngles.y, 
												  transform.eulerAngles.z);
		}
	}
	
	/*void OnGUI() {
		//GUI.Label(new Rect(10,200,100,20), VerticalVelocity.ToString());
		GUI.Label(new Rect(10,200,100,20), JetpackFuel.ToString());
		GUI.Label(new Rect(10,220,100,20), HoldingJump.ToString());
		GUI.Label(new Rect(10,240,100,20), ButtonReleased.ToString());
		GUI.Label(new Rect(10,260,100,20), VerticalVelocity.ToString());
		GUI.Label(new Rect(10,280,100,20), meleeTimer.ToString());
		GUI.Label(new Rect(10,300,100,20), meleeCombo.ToString());
		GUI.Label(new Rect(10,360,100,20), currentAirMeleeCombo.ToString());
	}*/
}