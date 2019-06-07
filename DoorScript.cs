using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public AudioClip HealSound;
	public AudioClip HurtSound;
	public AudioClip AmmoSound;
	public AudioClip JetpackSound;
	public AudioClip FuelSound;
	public AudioClip KillSound;
	
	AudioSource audio;
	
	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void Update() {
		/*if (Input.GetButtonDown("Fire2")) {
			Application.LoadLevel("Test2");
		}*/
	}
	
	void OnControllerColliderHit(ControllerColliderHit col) {
		if (col.gameObject.name == "Wall") {
			//print("hit wall");
			//audio.PlayOneShot(HurtSound, 1.0F);
			//PlayerStats.Instance.health -= 1;
		}
		if (col.gameObject.name == "door")	
			Application.LoadLevel("Test2");
		/*if (col.gameObject.name == "Medkit") {
			HealthPickup.Instance.HealPlayer();
			audio.PlayOneShot(HealSound, 1.0F);
		}*/
		
		//print("hit");
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Medkit") {
			//HealthPickup.Instance.HealPlayer();
			col.gameObject.SendMessage("HealPlayer");
			audio.PlayOneShot(HealSound, 1.0F);
		}
		if (col.gameObject.tag == "Ammo") {
			//AmmoPickup.Instance.FillAmmo();
			col.gameObject.SendMessage("FillAmmo");
			audio.PlayOneShot(AmmoSound, 1.0F);
		}
		if (col.gameObject.tag == "Jetpack") {
			//HealthPickup.Instance.HealPlayer();
			col.gameObject.SendMessage("GiveJetpack");
			audio.PlayOneShot(JetpackSound, 1.0F);
		}
		if (col.gameObject.tag == "JetpackFuel" && Motor.Instance.HasJetpack) {
			//HealthPickup.Instance.HealPlayer();
			col.gameObject.SendMessage("Refuel");
			audio.PlayOneShot(FuelSound, 1.0F);
		}
		if (col.gameObject.tag == "Enemy" && !Motor.CanJump) {
			col.gameObject.SendMessage("kill");
			audio.PlayOneShot(KillSound, 1.0F);
		}
	}
	
	void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "TalkZone") {
			//HealthPickup.Instance.HealPlayer();
			//print("col");
			if (Input.GetButtonDown("Submit")) {
				//print("talk");
				col.gameObject.SendMessage("Talk");
			}
		}
	}
}
