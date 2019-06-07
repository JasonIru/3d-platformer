using UnityEngine;
using System.Collections;

public class FuelPickup : MonoBehaviour {
	
	void Start() {

	}
	
	void Update() {
	
	}
	
	public void Refuel() {
		Motor.Instance.JetpackFuel += Motor.Instance.JetpackFuelMax;
		Motor.Instance.JetpackFuel = Mathf.Clamp(Motor.Instance.JetpackFuel, 0, Motor.Instance.JetpackFuelMax);
		Destroy(this.gameObject);
	}
}
