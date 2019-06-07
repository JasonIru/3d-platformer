using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public static Enemy Instance;

	// Use this for initialization
	void Start () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void kill() {
		//audio.PlayOneShot(HealSound, 1.0F);
		Destroy(this.gameObject);
	}
}
