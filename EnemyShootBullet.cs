using UnityEngine;
using System.Collections;

public class EnemyShootBullet : MonoBehaviour {

	public static CharacterController EController;
	public static EnemyShootBullet Instance;
	
	public GameObject obj;
	public GameObject Target;
	public Vector3 TargetPos;
	public float MaxDelay = 1f;
	public float Speed = 5f;
	public Vector3 MoveVector;
	
	private float delay = 0f;
	//private Vector3 MoveVector;
	
	void Awake() {
		EController = GetComponent("CharacterController") as CharacterController;
		Instance = this;
	}
	
	void Start() {
		TargetPos = Target.transform.position;
		//MoveVector = new Vector3(0, 0, -Speed);
	}
	
	void Update() {
		//transform.LookAt(Target.transform);
		TargetPos = Target.transform.position - transform.position;
		//TargetPos = transform.position - Target.transform.position;
		//EController.Move((Target.transform.position - transform.position) * Speed * Time.deltaTime);
		/*if (transform.position.x >= TargetPos.x)
			EController.Move(new Vector3(Speed, 0, 0) * Time.deltaTime);
		if (transform.position.x <= TargetPos.x)
			EController.Move(new Vector3(-Speed, 0, 0) * Time.deltaTime);
		if (transform.position.y >= TargetPos.y)
			EController.Move(new Vector3(0, Speed, 0) * Time.deltaTime);
		if (transform.position.y <= TargetPos.y)
			EController.Move(new Vector3(0, -Speed, 0) * Time.deltaTime);
		if (transform.position.z >= TargetPos.z)
			EController.Move(new Vector3(0, 0, Speed) * Time.deltaTime);
		if (transform.position.z <= TargetPos.z)
			EController.Move(new Vector3(0, 0, -Speed) * Time.deltaTime);*/
		//Vector3 forwardDir = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 1f);
		//EController.Move(Vector3.forward);
		//EController.Move(new Vector3(0, 0, -Speed * Time.deltaTime));
		/*Vector3 tmpVel = new Vector3() * Speed;
		if (EController.velocity > tmpVel)
			print("Velocity higher than speed");*/
		EController.Move(MoveVector * Time.deltaTime * Speed);
		//MoveVector = new Vector3(0, 0, -Speed);
		//transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Speed * Time.deltaTime);
		delay += 1f * Time.deltaTime;
		
		if (delay >= MaxDelay) {
			Instantiate(obj, transform.position, transform.rotation);
			delay = 0f;
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit col) {
		if (col.gameObject.tag == "Wall") {
			//transform.Rotate(new Vector3(0, 200, 0) * Time.deltaTime);
			//MoveVector = new Vector3(MoveVector.x + Speed, MoveVector.y, MoveVector.z + Speed);
			//MoveVector = new Vector3(Speed, 0, 0);
			//EController.Move(new Vector3(0, 0, Speed * Time.deltaTime));
			//Speed *= -1;
		}
		else {
			//MoveVector = new Vector3(0, 0, Speed);
			print("hit something else");
		}
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "DirectionChanger") {
			print("Hit DirectionChanger");
			//MoveVector = col.gameObject.SendMessage("GetChangeDirection");
			//WaitForSeconds(1);
			//MoveVector *= 0f;
			//MoveVector += MoveVector *= -1f;
			//MoveVector = new Vector3(0, 0, 0);
			//EController.Move(Vector3.zero);
			DirectionChangerScript directionChangerScript = col.gameObject.GetComponent<DirectionChangerScript>();
			Quaternion rotation = Quaternion.Euler(0, directionChangerScript.ChangeRotation, 0);
			transform.rotation = rotation;
			//EController.velocity = 0f;
			MoveVector = directionChangerScript.ChangeDirection;
			/*if (MoveVector != directionChangerScript.ChangeDirection)
				print("MoveVector not equal");
			if (MoveVector.magnitude > 1)
				MoveVector = Vector3.Normalize(MoveVector);*/
			//var tmpSpd = Speed;
			//Speed = 0;
			//Speed = tmpSpd;
			//Speed *= (Speed * 2);
			//EController.SimpleMove(MoveVector * Speed * Speed);
			//MoveVector *= (Speed * Speed);
		}
	}
	
	/*void OnTriggerStay(Collider col) {
		if (col.gameObject.tag == "DirectionChanger") {
			//print("Hitting DirectionChanger");
			//MoveVector = col.gameObject.SendMessage("GetChangeDirection");
			MoveVector = new Vector3(0, 0, 0);
			DirectionChangerScript directionChangerScript = col.gameObject.GetComponent<DirectionChangerScript>();
			MoveVector = directionChangerScript.ChangeDirection * (Speed * Speed);
		}
	}*/
}
