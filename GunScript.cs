using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour {

	public int dir;
	public float distance = 0.1f;

	void Start() {
		dir = PlayerStats.Instance.dir;
	}
	
	void Update() {
		if (dir == 0)
			transform.localPosition = new Vector3(0, 0, -distance);
		if (dir == 1)
			transform.localPosition = new Vector3(-distance, 0, -distance);
		if (dir == 2)
			transform.localPosition = new Vector3(-distance, 0, 0);
		if (dir == 3)
			transform.localPosition = new Vector3(-distance, 0, distance);
		if (dir == 4)
			transform.localPosition = new Vector3(0, 0, distance);
		if (dir == 5)
			transform.localPosition = new Vector3(distance, 0, distance);
		if (dir == 6)
			transform.localPosition = new Vector3(distance, 0, 0);
		if (dir == 7)
			transform.localPosition = new Vector3(distance, 0, -distance);
	}
	
	void OnGUI() {
		GUI.Label(new Rect(10,180,100,20), dir.ToString());
	}
}
