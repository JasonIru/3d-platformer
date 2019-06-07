using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject obj;

	void Start() {
	
	}
	
	void Update() {
		transform.LookAt(obj.transform);
	}
}
