using UnityEngine;
using System.Collections;

public class FP_Camera : MonoBehaviour {

	public GameObject obj;
	public GameObject gun;
	
	public Camera fpCam;
	
	//public Animator animator;
	
	public Texture Crosshair;
	
	public float X_AimSensitivity = 5f;
	public float Y_AimSensitivity = 5f;
	public float Y_MinLimit = -40f;
	public float Y_MaxLimit = 40f;
	
	private float mouseX = 0f;
	private float mouseY = 0f;
	private float w = 100;
	private float h = 20;
	
	void Start() {
		transform.position = obj.transform.position;
		fpCam = GetComponent("Camera") as Camera;
		fpCam.enabled = false;
		gun.transform.position = this.transform.position;
	}
	
	void Update() {
		this.transform.position = obj.transform.position;
		
		mouseX += Input.GetAxis("Mouse X") * X_AimSensitivity;
		mouseY -= Input.GetAxis("Mouse Y") * Y_AimSensitivity;
		
		mouseY = Helper.ClampAngle(mouseY, Y_MinLimit, Y_MaxLimit);
		Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
		
		transform.rotation = rotation;
		gun.transform.rotation = rotation;
	}
	
	void OnGUI() {
		if (fpCam.enabled) {
			GUI.DrawTexture(new Rect((Screen.width - w) / 2, (Screen.height - h) / 2, w, h), Crosshair, ScaleMode.ScaleToFit, true, 0.0f);
		}
	}
}
