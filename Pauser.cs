using UnityEngine;
using System.Collections;

public class Pauser : MonoBehaviour {

	public bool paused = false;

	void Start() {
	
	}
	
	void Update() {
		if(Input.GetButtonUp("Cancel")) {
			if(!paused) {
				Time.timeScale = 0;
				paused = true;
			}
			else {
				Time.timeScale = 1;
				paused = false;
			}
		}
	}
}
