using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour {

	public GameObject obj;
	
	void Start() {
		GetComponent<Renderer>().enabled = false;
	}
	
	void Update() {
		this.transform.position = obj.transform.position;
		transform.LookAt(Camera.main.transform);
	}
}
