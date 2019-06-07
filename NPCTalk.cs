using UnityEngine;
using System.Collections;

public class NPCTalk : MonoBehaviour {

	public GameObject obj;
	public GameObject txt;
	
	public string TalkText = "Hello World";
	
	void Start() {
		GetComponent<Renderer>().enabled = false;
	}
	
	void Update() {
	
	}
	
	void Talk() {
		//NPCAnimation npcAnimation = obj.GetComponent<NPCAnimation>();
		//NPCStats npcStats = obj.GetComponent<NPCStats>();
		Vector3 txtPos = transform.position + Vector3.up * 3;
		
		GameObject talkText = Instantiate(txt, txtPos, transform.rotation) as GameObject;
		talkText.GetComponent<TextMesh>().text = TalkText;
	}
	
	void OnTriggerEnter(Collider col) {
		//NPCAnimation npcAnimation = obj.GetComponent<NPCAnimation>();
		//NPCStats npcStats = obj.GetComponent<NPCStats>();
		Vector3 txtPos = transform.position + Vector3.up * 3;
		
		if (col.gameObject.tag == "Player") {
			if (Input.GetButtonDown("Submit")) {
				//NPCAnimation.SetAnimationDirection(0);
				print("col");
				GameObject talkText = Instantiate(txt, txtPos, transform.rotation) as GameObject;
				talkText.GetComponent<TextMesh>().text = TalkText;
			}
		}
	}
}
