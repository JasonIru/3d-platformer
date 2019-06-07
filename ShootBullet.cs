using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour {

	public GameObject ThePrefab;
	public GameObject Bullet2;
	public GameObject Bullet3;
	public AudioClip BulletSound;
	public AudioClip ChargeSound;
	AudioSource audio;
	
	public Animator animator;
	public GameObject obj;
	
	public float Power = 0f;
	public float MaxPower = 300f;
	
	public float ScaleHealth = 0.0f;
	
	public Texture HealthFront;
	public Texture HealthBack;
	
	void Start() {
		audio = GetComponent<AudioSource>();
		animator = obj.GetComponent<Animator>();
	}
	
	
	void Update() {
		if (Controller.Instance.CurrentCameraMode == "First Person" && PlayerStats.Instance.bullets > 0) {
			Shoot();
		}
	}
	
	void Shoot() {
		if (Input.GetButton("Fire1")) {
			Motor.Instance.SnapAlignCharacterWithCamera();
			if (PlayerStats.Instance.bullets > 0) {
				//GetComponent<AudioSource>().PlayOneShot(BulletSound);
				if (Controller.CController.velocity == Vector3.zero) {
					animator.SetInteger("Direction", 4);
				}
			}
			Power += 1f;
			Power = Mathf.Clamp(Power, 0, MaxPower);
			//audio.PlayOneShot(ChargeSound, 1.0F);
		}
		if (Input.GetButtonUp("Fire1")) {
			audio.PlayOneShot(BulletSound, 1.0F);
			
			if (Power < 100) {
				Instantiate(ThePrefab, transform.position, transform.rotation);
			}
			else if (Power >= 100 && Power < MaxPower) {
				Instantiate(Bullet2, transform.position, transform.rotation);
			}
			else if (Power >= MaxPower) {
				Instantiate(Bullet3, transform.position, transform.rotation);
			}
			else
				print("BulletScript Power Error");
			
			PlayerStats.Instance.bullets -= 1;
			Power = 0f;
		}
	}
	
	void OnGUI() {
		GUI.Label(new Rect(10,340,100,20), Power.ToString());
		/*for (int i = 0; i < MaxPower; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 340, 10 + i, 20), HealthBack, ScaleMode.ScaleToFit, true, ScaleHealth);
		}
		for (int i = 0; i < Power; i++) {
			//ScaleHealth = health;
			GUI.DrawTexture(new Rect(10, 340, 10 + i, 20), HealthFront, ScaleMode.ScaleToFit, true, ScaleHealth);
		}*/
	}
}
