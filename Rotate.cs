using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public char Axis;
	public float Speed = 200f;

	void Start() {
	
	}
	
	void Update() {
		RotateOnAxis(Axis);
	}
	
	void RotateOnAxis(char RotateAxis) {
		if (RotateAxis == 'x') {
			transform.Rotate(new Vector3(Speed, 0, 0) * Time.deltaTime);
		}
		else if (RotateAxis == 'y') {
			transform.Rotate(new Vector3(0, Speed, 0) * Time.deltaTime);
		}
		else if (RotateAxis == 'z') {
			transform.Rotate(new Vector3(0, 0, Speed) * Time.deltaTime);
		}
		else {
			return;
		}
	}
}
