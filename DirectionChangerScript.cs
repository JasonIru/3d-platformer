using UnityEngine;
using System.Collections;

public class DirectionChangerScript : MonoBehaviour {

	public float Direction;
	public Vector3 ChangeDirection;
	public float ChangeRotation;
	
	void Start() {
		if (Direction == 0)
			ChangeDirection = new Vector3(0, 0, -1);
		if (Direction == 1)
			ChangeDirection = new Vector3(-1, 0, -1);
		if (Direction == 2)
			ChangeDirection = new Vector3(-1, 0, 0);
		if (Direction == 3)
			ChangeDirection = new Vector3(-1, 0, 1);
		if (Direction == 4)
			ChangeDirection = new Vector3(0, 0, 1);
		if (Direction == 5)
			ChangeDirection = new Vector3(1, 0, 1);
		if (Direction == 6)
			ChangeDirection = new Vector3(1, 0, 0);
		if (Direction == 7)
			ChangeDirection = new Vector3(1, 0, -1);
	}
	
	void Update() {
		if (Direction == 0)
			ChangeRotation = 180;
		if (Direction == 1)
			ChangeRotation = 225;
		if (Direction == 2)
			ChangeRotation = 270;
		if (Direction == 3)
			ChangeRotation = 315;
		if (Direction == 4)
			ChangeRotation = 0;
		if (Direction == 5)
			ChangeRotation = 45;
		if (Direction == 6)
			ChangeRotation = 90;
		if (Direction == 7)
			ChangeRotation = 135;
	}
	
	public Vector3 GetChangeDirection() {
		return ChangeDirection;
	}
}
