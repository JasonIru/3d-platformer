using UnityEngine;
using System.Collections;

public class NPCAnimation : MonoBehaviour {

	public Animator animator;
	public GameObject obj;
	public GameObject Target;
	
	private float angle;
	//private int[] directionAngles = {0,45,90,135,180,225,270,315};
	private int[] imageViews = {0,1,2,3,4,5,6,7};
	private int currentImageView;
	private int lastImageView;
	
	private int diffImageView;
	
	
	void Start() {
		animator = this.GetComponent<Animator>();
		
		angle = CalculateAngle();
		
		currentImageView = GetImageView();
		lastImageView = currentImageView;
	}

	void Update() {
		angle = CalculateAngle();
		LookAtCamera();
		
		currentImageView = GetImageView();
		
		SetNPCImage();
		
		lastImageView = currentImageView;
		
		//transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, 3 * Time.deltaTime);
	}
	
	void LookAtCamera() {
	}
	
	float CalculateAngle() {
		// Calculate Angle
		Vector3 dir = transform.position - Camera.main.transform.position;
		Quaternion look = Quaternion.LookRotation(dir);
		return look.eulerAngles.y;
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
	
	public void SetAnimationDirection(int setDir) {
		animator.SetInteger("NPCDirection", setDir);
	}
	
	void ClampAnimationDirection() {
		if (animator.GetInteger("NPCDirection") > 7)
			animator.SetInteger("NPCDirection", 0);
		if (animator.GetInteger("NPCDirection") < 0)
			animator.SetInteger("NPCDirection", 7);
	}
	
	void AnimDirInc(int times) {
		for (int i = 0; i < times; i++) {
			animator.SetInteger("NPCDirection", animator.GetInteger("NPCDirection") + 1);
			ClampAnimationDirection();
		}
	}
	
	void AnimDirDec(int times) {
		for (int i = 0; i < times; i++) {
			animator.SetInteger("NPCDirection", animator.GetInteger("NPCDirection") - 1);
			ClampAnimationDirection(); 
		}
	}
	
	void SetNPCImage() {
		if (currentImageView != lastImageView) {
			diffImageView = Mathf.Abs(currentImageView - lastImageView);
			if (currentImageView == 1 && lastImageView == 8) {
				AnimDirDec(1);
				return;
			}
			if (currentImageView == 8 && lastImageView == 1) {
				AnimDirInc(1);
				return;
			}
			if (currentImageView > lastImageView) {
				AnimDirDec(diffImageView);
				return;
			}
			if (currentImageView < lastImageView) {
				AnimDirInc(diffImageView);
				return;
			}
		}
	}
}
