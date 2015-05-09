using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class shoot : MonoBehaviour {
	public Transform bulletSpawn;
	public Transform bullet;
	public float bulletSpeed;
	public Transform player;	
	private Vector3 shootDir;
	private ParticleSystem shootParticles;
	public bool shooting;
	public float shootSpeed;
	public float shotSpread;
	public float bulletKnockback;
	public AudioClip shotSound;
	public AudioClip shellSound;

	// Use this for initialization
	void Start () {
		shootParticles = bulletSpawn.GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		shootDir = Vector3.Normalize (player.transform.position - bulletSpawn.transform.position)*-1;
		Debug.DrawRay (bulletSpawn.position, shootDir, Color.red);
	
	
		handleMouseInputs ();


	}

	void handleMouseInputs(){
		if (Input.GetKeyDown (KeyCode.Mouse0)) {//if shooting
			Camera.main.GetComponent<CameraShake> ().enabled = true;

			shooting = true;
			shootParticles.enableEmission = true;
			bulletSpawn.GetChild (0).GetComponent<ParticleSystem> ().enableEmission = true;
			StartCoroutine ("fireBullet", shootSpeed);
		} else if (Input.GetKeyUp (KeyCode.Mouse0)) {//if not
			Camera.main.GetComponent<CameraShake> ().enabled = false;
			shooting = false;
			transform.localScale = new Vector3 (1, 1, 1);
			shootParticles.enableEmission = false;
			bulletSpawn.GetChild (0).GetComponent<ParticleSystem> ().enableEmission = false;
			StopCoroutine ("fireBullet");
		}
	}
		IEnumerator fireBullet(float shootInterval){
			while (shooting) {
				player.GetComponent<Rigidbody2D>().AddForce((shootDir*bulletKnockback)*-1);


				GetComponent<AudioSource>().pitch = Random.Range (1.5f, 2.0f);
				GetComponent<AudioSource>().volume = Random.Range(0.2f, 0.1f);
				GetComponent<AudioSource>().PlayOneShot(shotSound);
				float rand = Random.Range (0f,1f);
				if(rand>0.7f)
					StartCoroutine("waitAndPlayShell", 1f);

				Vector2 randomDir = new Vector2(shootDir.x+Random.Range (-shotSpread,shotSpread), shootDir.y+Random.Range (-shotSpread,shotSpread));
				Transform shot = Instantiate (bullet, bulletSpawn.position, transform.rotation) as Transform;			
				//Debug.DrawRay(bulletSpawn.position, shootDir);
				shot.GetComponent<Rigidbody2D>().AddForce(randomDir+new Vector2(shootDir.x, shootDir.y)*bulletSpeed, ForceMode2D.Impulse);
				yield return new WaitForSeconds (shootInterval);
			}
		}

	IEnumerator waitAndPlayShell (float seconds){
		yield return new WaitForSeconds(seconds);
		bulletSpawn.GetComponent<AudioSource>().pitch = Random.Range (0.8f, 1.6f);
		bulletSpawn.GetComponent<AudioSource> ().volume = Random.Range (0.2f, 0.4f);
		bulletSpawn.GetComponent<AudioSource>().PlayOneShot(shellSound);
	}
	
}
