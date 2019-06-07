using UnityEngine;
using System.Collections;

public class PunchScript : MonoBehaviour {

	//public float MaxTimer = Motor.Instance.MaxMeleeTimer;
	//public GameObject obj;
	public float MaxTimer = .25f;
	public float Dmg = 4;
	
	private float timer = 0f;
	
	void Start() {
		//MaxTimer = obj.MaxMeleeTimer;
		//GetComponent<Renderer>().enabled = false;
		Dmg *= Motor.Instance.currentMeleeCombo + 1;
		Dmg = Mathf.Clamp(Dmg, 4, 99);
	}
	
	void Update() {
		//timer += 1f * Time.deltaTime;
		timer += 1f;
		
		if (timer >= MaxTimer) {
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "NPC") {
			col.gameObject.SendMessage("TakeDamage", Dmg);
			print("Hit NPC for " + Dmg.ToString() + " damage");
			//Destroy(this.gameObject);
		}
		if (col.gameObject.tag == "Enemy") {
			col.gameObject.SendMessage("TakeDamage", Dmg);
			print("Hit Enemy for " + Dmg.ToString() + " damage");
			//Destroy(this.gameObject);
		}
		if (col.gameObject.tag != "Player") {
			Destroy(this.gameObject);
		}
	}
}
