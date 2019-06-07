using UnityEngine;
using System.Collections;

public class NPCStats : MonoBehaviour {
	
	public static NPCStats Instance;
	public GameObject txt;

	public int hp = 10;
	
	//private GameObject dmgText;

	void Start() {
		Instance = this;
	}
	
	void Update() {
		if (hp <= 0) {
			Destroy(this.gameObject);
		}
	}
	
	public int GetHp() {
		return hp;
	}
	
	void TakeDamage(int dmg) {
		hp -= dmg;
		
		Vector3 txtPos = transform.position + Vector3.up * 3;
		
		GameObject dmgText = Instantiate(txt, txtPos, transform.rotation) as GameObject;
		dmgText.GetComponent<TextMesh>().text = dmg.ToString();
	}
}
