using UnityEngine;
using System.Collections;

public class BillboardY : MonoBehaviour {

	void Start() {
	
	}
	
	void Update() {
		var lookPos = Camera.main.transform.position - transform.position;
		lookPos.y = 0;
		var rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
	}
}
