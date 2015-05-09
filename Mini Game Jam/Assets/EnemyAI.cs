using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private Transform player;
	private Vector3 playerPos;
	public int life = 100;
	public float speed;

	public GameObject pointsUp;

	public AudioClip[] shouts;


	float currentX;
	float lastX;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").transform;
		StartCoroutine ("jumpLikeStupid");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (life <= 0) {
			Instantiate (pointsUp, transform.position, Quaternion.identity);
			GameObject.Find("GameManager").GetComponent<GameManager>().points+=100;
			GetComponentInChildren<explodeOnPlayer>().dead = true;
		}

		currentX = transform.position.x;

		if (lastX < currentX) {
			transform.localScale = new Vector3(1,1,1);
		} else if (lastX > currentX) {
			transform.localScale = new Vector3(-1,1,1);
		}


		playerPos = player.transform.position;
		if(Vector3.Distance(playerPos, transform.position)<10){
		transform.position = Vector3.Lerp (transform.position, playerPos, speed);
		Vector3 dir = transform.position + Vector3.Normalize (player.transform.position - transform.position);
		dir = transform.position +Vector3.forward*10f;
		}
		lastX = currentX;
	}

	IEnumerator jumpLikeStupid(){
		while (true) {
			//JUMP
			float rand = Random.Range(0.8f, 3.5f);
			yield return new WaitForSeconds(rand);
			Vector3 vel = GetComponent<Rigidbody2D>().velocity;
			vel = new Vector3(0, 0, 0);
			if(Random.Range(0.0f,1.0f)>0.96f)
			AudioSource.PlayClipAtPoint(shouts[Random.Range (0,shouts.Length-1)], transform.position, Random.Range (0.5f,1f));

			GetComponent<Rigidbody2D>().AddForce(Vector2.up*10, ForceMode2D.Impulse);

		}
	}
}
