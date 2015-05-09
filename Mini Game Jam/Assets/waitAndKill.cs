using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
public class waitAndKill : MonoBehaviour {
	public AudioClip hit;
	public ParticleSystem bloodParticles;
	public ParticleSystem groundHit;
	// Use this for initialization
	void Start () {
		StartCoroutine ("waitAndDestroy", 3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Enemy") {
			col.transform.GetComponent<EnemyAI> ().life -= 10;
			Instantiate (bloodParticles, col.transform.position, Quaternion.identity);
			col.GetComponent<AudioSource> ().clip = hit;
			col.GetComponent<AudioSource> ().pitch = Random.Range (0.8f, 1.2f);
			col.GetComponent<AudioSource> ().volume = Random.Range (0.5f, 1f);
			col.GetComponent<AudioSource> ().PlayOneShot (hit);
			col.transform.GetComponent<Rigidbody2D> ().AddForce ((col.transform.position - transform.position) * 10, ForceMode2D.Impulse);
			Destroy (this.gameObject);
		} else if (col.transform.tag == "Ground") {
			Instantiate (groundHit, transform.position, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}


	IEnumerator waitAndDestroy(float s){
		yield return new WaitForSeconds(s);
		Destroy (this.gameObject);
	}
}
