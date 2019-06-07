using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {

	//public GameObject Target;
	public Rigidbody rb;
	public float power = 5000.0f;
	public Vector3 TargetPos;
	
	void Start() {
		rb = GetComponent<Rigidbody>();
		TargetPos = EnemyShootBullet.Instance.TargetPos;
		//rb.AddForce(TargetPos * power);
		rb.AddForce(transform.forward * power);
	}
	
	void Update() {
	
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.SendMessage("PlayerTakeDamage", 10);
			//Destroy(this.gameObject);
		}
		if (col.gameObject.tag != "Enemy" && col.gameObject.GetComponent<Renderer>().enabled != false) {
			Destroy(this.gameObject);
		}
	}
}
