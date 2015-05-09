using UnityEngine;
using System.Collections;

public class explodeOnPlayer : MonoBehaviour {
	public GameObject Enemy;
	public ParticleSystem explosion;
	public ParticleSystem explosion2;
	private Transform player;
	public bool dead = false;
	void Start(){
		player = GameObject.FindWithTag ("Player").transform;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			print ("EXPLOSION!");
			Debug.DrawRay(transform.position, player.transform.position, Color.red, 2f);
			player.GetComponent<Rigidbody2D>().AddForce(Vector3.up*20f+Vector3.Normalize(player.transform.position-transform.position) * 10f, ForceMode2D.Impulse);
			dead = true;

		}
	}

	void Update(){

		if (dead) {
			Instantiate(explosion2, transform.position, Quaternion.identity);
			Instantiate(explosion, transform.position, Quaternion.identity);
			Destroy (Enemy);
		}
		     

	}


}
