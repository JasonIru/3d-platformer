using UnityEngine;
using System.Collections;

public class StopChildRotation : MonoBehaviour {

	Quaternion rotation;

	void Awake() {
		rotation = transform.rotation;
	}
	
	void Update() {
		transform.rotation = rotation;
	}
}
