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

	public AudioClip[] playerHurt;

	void Start(){
		player = GameObject.FindWithTag ("Player").transform;
	}
	
	void Update(){

		if (Vector3.Distance (transform.position, player.transform.position) < 1) {
			dead = true;
			player.GetComponent<Rigidbody2D>().AddForce(Vector3.up*10f+Vector3.Normalize(player.transform.position-transform.position) * 10f, ForceMode2D.Impulse);
			AudioSource.PlayClipAtPoint(playerHurt[Random.Range(0,2)], Camera.main.transform.position,2f);

			
			
		}

		if (dead) {
			Instantiate(explosion2, transform.position, Quaternion.identity);
			Instantiate(explosion, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionSound, transform.position,0.8f);

			Destroy (Enemy);
		}
		     

	}


}
