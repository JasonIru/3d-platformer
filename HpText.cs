using UnityEngine;
using System.Collections;

public class HpText : MonoBehaviour {
	
	public GameObject obj;
	//public NPCStats npcStats;
	
	private int hp;

	void Start () {
		//hp = NPCStats.Instance.hp;
		NPCStats npcStats = obj.GetComponent<NPCStats>();
		hp = npcStats.hp;
		//hp = obj.gameObject.SendMessage("GetHp");
	}
	
	void Update () {
		NPCStats npcStats = obj.GetComponent<NPCStats>();
		hp = npcStats.hp;
		//hp = NPCStats.Instance.hp;
		//hp = obj.gameObject.SendMessage("GetHp");
		GetComponent<TextMesh>().text = hp.ToString();
	}
}
