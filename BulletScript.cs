using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public Vector3 direction = new Vector3(0, 0, 0);
	public float power = 100.0f;
	public Rigidbody rb;
	public int dir;
	public float Dmg = 1f;
	
	void Start() {
		rb = GetComponent<Rigidbody>();
		dir = PlayerStats.Instance.dir;
		
		/*if (dir == 0)
			direction = new Vector3(0, 0, -1);
		if (dir == 1)
			direction = new Vector3(-1, 0, -1);
		if (dir == 2)
			direction = new Vector3(-1, 0, 0);
		if (dir == 3)
			direction = new Vector3(-1, 0, 1);
		if (dir == 4)
			direction = new Vector3(0, 0, 1);
		if (dir == 5)
			direction = new Vector3(1, 0, 1);
		if (dir == 6)
			direction = new Vector3(1, 0, 0);
		if (dir == 7)
			direction = new Vector3(1, 0, -1);*/
		
		rb.AddForce(transform.forward * power);
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
		if (col.gameObject.GetComponent<Renderer>().enabled != false)
			Destroy(this.gameObject);
	}
}
