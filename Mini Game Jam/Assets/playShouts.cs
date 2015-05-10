using UnityEngine;
using System.Collections;

public class playShouts : MonoBehaviour {

	public GameObject gun;

	public AudioClip[] shouts;

	// Use this for initialization
	void Start () {
		if (gun == null) {
			gun = GameObject.Find("Gun");
		}
		StartCoroutine ("randomShouts");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	IEnumerator randomShouts(){
		while(true) {
			if(gun.GetComponent<shoot> ().shooting){
				float rand = Random.Range (0.0f,1.0f);
				if(rand> 0.2f){
					int random = Random.Range(0, shouts.Length-1);
					AudioSource.PlayClipAtPoint(shouts[random],Camera.main.transform.position, 1f);
				}
			}

			yield return new WaitForSeconds(2f);
		}
	}
}
