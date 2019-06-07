using UnityEngine;
using System.Collections;

public class JetpackPickup : MonoBehaviour {
	
	public float FuelAmount = 500f;

	void Start() {
	
	}
	
	void Update() {
	
	}
	
	void GiveJetpack() {
		Motor.Instance.HasJetpack = true;
		Motor.Instance.JetpackFuelMax = FuelAmount;
		Destroy(this.gameObject);
	}
}
