using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
	
	public static HealthPickup Instance;
	
	//public AudioClip HealSound;
	//AudioSource audio;

	void Start() {
		Instance = this;
		//audio = GetComponent<AudioSource>();
	}
	
	void Update() {
	
	}
	
	/*void OnControllerColliderHit(ControllerColliderHit col) {
		if (col.gameObject.name == "Medkit") {
			Destroy(this.gameObject);
		}
	}*/
	/*void OnTriggerEnter(Collider col) {
		if (col.gameObject.name == "Medkit") {
			PlayerStats.Instance.health += 500;
			Destroy(this.gameObject);
		}
	}*/
	
	public void HealPlayer() {
		PlayerStats.Instance.health += 100;
		PlayerStats.Instance.health = Mathf.Clamp(PlayerStats.Instance.health, 0, 500);
		//audio.PlayOneShot(HealSound, 1.0F);
		Destroy(this.gameObject);
	}
}
