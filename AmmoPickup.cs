using UnityEngine;
using System.Collections;

public class AmmoPickup : MonoBehaviour {
	
	public static AmmoPickup Instance;

	void Start() {
		Instance = this;
	}
	
	void Update() {
	
	}
	
	public void FillAmmo() {
		PlayerStats.Instance.bullets += Random.Range(1, 20);
		//PlayerStats.Instance.bullets = Mathf.Clamp(PlayerStats.Instance.bullets, 0, 50);
		Destroy(this.gameObject);
	}
}
