using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

	void Start() {
	
	}
	
	void Update() {
	
	}
	
	void OnMouseOver() {
		if (Input.GetButtonDown("Fire1")) {
			Application.LoadLevel("Test");
		}
	}
}
