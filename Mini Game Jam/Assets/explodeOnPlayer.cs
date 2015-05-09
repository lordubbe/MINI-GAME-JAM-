using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class explodeOnPlayer : MonoBehaviour {
	public GameObject Enemy;
	public ParticleSystem explosion;
	public ParticleSystem explosion2;
	private Transform player;
	public bool dead = false;
	public AudioClip explosionSound;
	void Start(){
		player = GameObject.FindWithTag ("Player").transform;
	}
	
	void Update(){

		if (Vector3.Distance (transform.position, player.transform.position) < 1) {
			dead = true;
			player.GetComponent<Rigidbody2D>().AddForce(Vector3.up*20f+Vector3.Normalize(player.transform.position-transform.position) * 10f, ForceMode2D.Impulse);


		}

		if (dead) {
			Instantiate(explosion2, transform.position, Quaternion.identity);
			Instantiate(explosion, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position,1f);

			Destroy (Enemy);
		}
		     

	}


}
