using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats Instance;
	public int health = 100;
	public int MaxHealth = 100;
	public float ScaleHealth = 0.0f;
	public int place = 0;
	public int dir;
	public Animator animator;
	public int bullets = 10;
	public int MaxBullets = 10;
	public float Power = 0f;
	public float MaxPower = 300f;
	
	private float JetpackFuel;
	private float JetpackFuelMax;
	
	public Texture HealthFront;
	public Texture HealthBack;
	
	public AudioClip ReloadSound;
	AudioSource audio;
	
	public GameObject obj;
	
	void Start() {
		Instance = this;
		animator = obj.GetComponent<Animator>();
		audio = GetComponent<AudioSource>();
		
		dir = animator.GetInteger("Direction");
		MaxHealth = health;
		MaxBullets = bullets;
		
		JetpackFuel = Motor.Instance.JetpackFuel;
		JetpackFuelMax = Motor.Instance.JetpackFuelMax;
	}
	
	void Update() {
		if (health <= 0) {
			//Destroy(this.gameObject);
			Application.LoadLevel("Test2");
		}
		if (Input.GetButton("Reload")) {
			if (bullets != MaxBullets) {
				audio.PlayOneShot(ReloadSound, 1.0F);
				bullets = MaxBullets;
			}
		}
		
		JetpackFuel = Motor.Instance.JetpackFuel;
	}
	
	void TakeDamage(int dmg) {
		health -= dmg;
	}
	
	void OnGUI() {
		GUI.Label(new Rect(10,50,100,20), health.ToString());
		GUI.Label(new Rect(10,70,100,20), bullets.ToString());
		
		//GUI.DrawTexture(new Rect(10, 10, 9, 20), HealthBack, ScaleMode.ScaleToFit, true, ScaleHealth);
		/*for (int i = 0; i < MaxHealth; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 10, 10 + i, 20), HealthBack, ScaleMode.ScaleToFit, true, ScaleHealth);
		}
		for (int i = 0; i < health; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 10, 10 + i, 20), HealthFront, ScaleMode.ScaleToFit, true, ScaleHealth);
		}*/
		/*GUI.DrawTexture(new Rect(10, 10, MaxHealth, 20), HealthBack, ScaleMode.ScaleAndCrop, true, ScaleHealth);
		GUI.DrawTexture(new Rect(10, 10, health, 20), HealthFront, ScaleMode.ScaleAndCrop, true, ScaleHealth);
		
		for (int i = 0; i < bullets; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 100, 10 + i, 20), HealthBack, ScaleMode.ScaleToFit, true, ScaleHealth);
		}
		
		for (int i = 0; i < JetpackFuelMax; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 180, 10 + i, 20), HealthBack, ScaleMode.ScaleToFit, true, ScaleHealth);
		}
		for (int i = 0; i < JetpackFuel; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 180, 10 + i, 20), HealthFront, ScaleMode.ScaleToFit, true, ScaleHealth);
		}
		for (int i = 0; i < JetpackFuel; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 180, 10 + i, 20), HealthFront, ScaleMode.ScaleToFit, true, ScaleHealth);
		}
		for (int i = 0; i < MaxPower; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 320, 10 + i, 20), HealthBack, ScaleMode.ScaleToFit, true, ScaleHealth);
		}
		
		/*for (int i = 0; i < MaxHealth; i++) {
			GUI.DrawTexture(new Rect(10, 10, 10 + i, 20), HealthBack, ScaleMode.ScaleToFit, true, ScaleHealth);
			place = i;
		}
		GUI.DrawTexture(new Rect(10, 10, 10 + place, 20), HealthBack, ScaleMode.ScaleToFit, true, ScaleHealth);*/
	}
}
