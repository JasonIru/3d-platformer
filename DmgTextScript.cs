using UnityEngine;
using System.Collections;

public class DmgTextScript : MonoBehaviour {

	public float MaxTimer = 1f;
	
	private float timer = 0f;
	
	void Start() {
	
	}
	
	void Update() {
		timer += 1f * Time.deltaTime * 7.5f;
		//timer += 1f;
		
		if (timer >= MaxTimer)
			Destroy(this.gameObject);
	}
}
