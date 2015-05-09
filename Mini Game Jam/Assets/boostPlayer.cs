using UnityEngine;
using System.Collections;

public class boostPlayer : MonoBehaviour {

	public ParticleSystem pickupParticles;
	public GameObject enemy;
	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.tag == "Player") {
			StartCoroutine("buffAndKill");
		}
	}
	IEnumerator buffAndKill(){
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<Collider2D> ().enabled = false;
		Instantiate (pickupParticles, transform.position, Quaternion.identity);

		Instantiate (enemy, transform.position+new Vector3(2,4,0), Quaternion.identity);
		Instantiate (enemy, transform.position+new Vector3(2,4,0), Quaternion.identity);

		Instantiate (enemy, transform.position+new Vector3(2,4,0), Quaternion.identity);

		Instantiate (enemy, transform.position+new Vector3(2,4,0), Quaternion.identity);
		Instantiate (enemy, transform.position+new Vector3(2,4,0), Quaternion.identity);
		Instantiate (enemy, transform.position+new Vector3(2,4,0), Quaternion.identity);

		
		
		
		
		GameObject.Find ("Player").GetComponent<playShouts> ().gun.GetComponent<shoot> ().playShells = false;
		GameObject.Find ("Player").GetComponent<playShouts>().gun.GetComponent<shoot>().shootSpeed = 0.04f;
		yield return new WaitForSeconds(5f);
		GameObject.Find ("Player").GetComponent<playShouts> ().gun.GetComponent<shoot> ().playShells = true;
		GameObject.Find ("Player").GetComponent<playShouts>().gun.GetComponent<shoot>().shootSpeed = 0.08f;
		Destroy(this.gameObject);

	}
}
