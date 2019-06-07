using UnityEngine;
using System.Collections;

public class MoveShadow : MonoBehaviour {
	
	public GameObject ThePrefab;

	void Start() {
	
	}
	
	void Update() {
		if (!Motor.CanJump) {
			RaycastHit hitInfo;
			
			if (Physics.Raycast(transform.position, Vector3.down, out hitInfo)) {
				//Debug.DrawRay(transform.position, Vector3.down * 10.0f, Color.yellow);
				//print("hit");
				Instantiate(ThePrefab, hitInfo.point, Quaternion.identity);
			}
		}
	}
}
