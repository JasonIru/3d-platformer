using UnityEngine;
using System.Collections;

public class TopColliderScript : MonoBehaviour {

	//public GameObject Player;
	
	void Start() {
		GetComponent<Renderer>().enabled = false;
	}
	
	void Update() {
		
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag != "Player") {
			//print("collide");
			if (Motor.Instance.VerticalVelocity > 0) {
				Motor.Instance.NegateVerticalVelocity();
				//print("Reset VerticalVelocity");
			}
		}
	}
}
