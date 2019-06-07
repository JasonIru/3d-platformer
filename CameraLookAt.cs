using UnityEngine;
using System.Collections;

public class CameraLookAt : MonoBehaviour {

	public GameObject obj;

	void Start() {
	
	}
	
	void Update() {
		transform.LookAt(obj.transform);
	}
}
