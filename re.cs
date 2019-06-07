using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class re : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Reload")) { 
			Application.LoadLevel("Test - Copy");
		}
	}
	
	void OnGUI() {
		GUI.Label(new Rect(10,10,100,2000), "Press 'R' to reload level");
	}
}
