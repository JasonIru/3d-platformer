using UnityEngine;
using System.Collections;

public class DestroyShadow : MonoBehaviour {
	
	void Start () {
		transform.rotation = Quaternion.Euler(90, 0, 0);
	}
	
	void Update () {
		Destroy(this.gameObject);
	}

}
