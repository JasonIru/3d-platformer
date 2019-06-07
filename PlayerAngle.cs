using UnityEngine;
using System.Collections;

public class PlayerAngle : MonoBehaviour {

	private float angle;
	//private float lastAngle;
	public GameObject obj;
	public Animator animator;
	
	//private int[] directionAngles = {0,45,90,135,180,225,270,315};
	private int[] imageViews = {1,2,3,4,5,6,7,8};
	private int currentImageView;
	private int lastImageView;
	
	private int diffCount = 0;
	private int diffImageView;
	
	void Start() {
		animator = obj.GetComponent<Animator>();
		angle = Controller.Instance.angle;
		//lastAngle = angle;
		
		currentImageView = GetImageView();
		lastImageView = currentImageView;
	}
	
	void Update() {
		angle = Controller.Instance.angle;
		if (Motor.Instance.CurrentCameraMode == "Third Person")
			LookAtCamera();
		
		currentImageView = GetImageView();
		//AnimTest();
		//CheckImageView();
		
		Vector3 HorizontalVelocity = Controller.CController.velocity;
		HorizontalVelocity = new Vector3(Controller.CController.velocity.x, 0, Controller.CController.velocity.z);
		
		if (HorizontalVelocity == Vector3.zero) {
			//ResetPlayerImage();
			SetPlayerImage();
		}
		
		//if (Controller.CController.velocity == Vector3.zero) {
			//obj.transform.LookAt(Camera.main.transform);
			
			//transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		//}
		//else {
			//obj.transform.localEulerAngles = new Vector3(0, 0, 0);
		//}
		
		/*if (angle >= 337.5 && angle < 22.5)
			transform.localEulerAngles = new Vector3(0, 0, 0);
		if (angle >= 22.5 && angle < 67.5)
			transform.localEulerAngles = new Vector3(0, 45, 0);
		if (angle >= 67.5 && angle < 112.5)
			transform.localEulerAngles = new Vector3(0, 90, 0);*/
		
		//print(diffImageView.ToString());
		//lastAngle = angle;
		lastImageView = currentImageView;
	}
	
	void LookAtCamera() {
	}
	
	void ResetPlayerImage() {
		if (Input.GetAxis("Mouse Y") != 0.0f)
			animator.SetFloat("dir", 0.5714286f);
	}
	
	int GetImageView() {
		if (angle >= 337.5 || angle < 22.5) {
			return imageViews[0];
		}
		if (angle >= 22.5 && angle < 67.5) {
			return imageViews[1];
		}
		if (angle >= 67.5 && angle < 112.5) {
			return imageViews[2];
		}
		if (angle >= 112.5 && angle < 157.5) {
			return imageViews[3];
		}
		if (angle >= 157.5 && angle < 202.5) {
			return imageViews[4];
		}
		if (angle >= 202.5 && angle < 247.5) {
			return imageViews[5];
		}
		if (angle >= 247.5 && angle < 292.5) {
			return imageViews[6];
		}
		if (angle >= 292.5 && angle < 337.5) {
			return imageViews[7];
		}
		return 0;
	}
	
	void ClampAnimationDirection() {
		if (animator.GetFloat("dir") > 1f)
			animator.SetFloat("dir", 0f);
		if (animator.GetFloat("dir") < 0f)
			animator.SetFloat("dir", 1f);
		if (animator.GetFloat("dir") > 0.9f)
			animator.SetFloat("dir", 1f);
	}
	
	void CheckImageView() {
		if (currentImageView != lastImageView) {
			//print("difference");
			diffCount += 1;
			//lastImageView = currentImageView;*/
			/*if (currentImageView > lastImageView) {
				//var tempDir = animator.GetInteger("Direction");
				//tempDir += 1;
				//print(tempDir.ToString());
				animator.SetInteger("Direction", animator.GetInteger("Direction") + 1);
			}
			if (currentImageView > lastImageView) {
				//var tempDir = animator.GetInteger("Direction");
				//tempDir -= 1;
				animator.SetInteger("Direction", animator.GetInteger("Direction") - 1);
			}*/
			lastImageView = currentImageView;
		}
	}
	
	/*void AnimTest() {
		if (Input.GetButtonDown("Inc")) {
			AnimDirInc();
		}
		if (Input.GetButtonDown("Dec")) {
			AnimDirDec();
		}
	}*/
	
	void AnimDirInc(int times) {
		for (int i = 0; i < times; i++) {
			animator.SetFloat("dir", animator.GetFloat("dir") + 0.1428571f);
			ClampAnimationDirection();
		}
	}
	
	void AnimDirDec(int times) {
		for (int i = 0; i < times; i++) {
			animator.SetFloat("dir", animator.GetFloat("dir") - 0.1428571f);
			ClampAnimationDirection(); 
		}
	}
	
	void SetPlayerImage() {
		if (currentImageView != lastImageView) {
			diffImageView = Mathf.Abs(currentImageView - lastImageView);
			//diffCount += 1;
			//print("CHANGE!!!" + diffCount.ToString());
			if (currentImageView == 1 && lastImageView == 8) {
				AnimDirDec(1);
				//LookAtCamera();
				//print("one");
				return;
			}
			if (currentImageView == 8 && lastImageView == 1) {
				AnimDirInc(1);
				//LookAtCamera();
				//print("two");
				return;
			}
			if (currentImageView > lastImageView) {
				AnimDirDec(diffImageView);
				//LookAtCamera();
				//print("three");
				return;
			}
			if (currentImageView < lastImageView) {
				AnimDirInc(diffImageView);
				//LookAtCamera();
				//print("four");
				return;
			}
			//if (currentImageView >= 0 && currentImageView <= 6) {
				
			//}
			
		}
	}
	
	void OnGUI() {
		GUI.Label(new Rect(10,140,100,20), currentImageView.ToString());
		GUI.Label(new Rect(10,160,100,20), lastImageView.ToString());
		GUI.Label(new Rect(10,2000,100,20), diffImageView.ToString());
	}
}
