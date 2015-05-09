using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private Transform player;
	private Vector3 playerPos;

	public float speed;

	float currentX;
	float lastX;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").transform;
		StartCoroutine ("jumpLikeStupid");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentX = transform.position.x;

		if (lastX < currentX) {
			transform.localScale = new Vector3(1,1,1);
		} else if (lastX > currentX) {
			transform.localScale = new Vector3(-1,1,1);
		}


		playerPos = player.transform.position;

		transform.position = Vector3.Lerp (transform.position, playerPos, speed);
		Vector3 dir = transform.position + Vector3.Normalize (player.transform.position - transform.position);
		dir = transform.position +Vector3.forward*10f;
		Debug.DrawLine(transform.position, dir, Color.red);
		RaycastHit hit;
		if(Physics.Raycast(transform.position, dir, out hit, )){
			print (hit.transform.name);


			                             
		}
		lastX = currentX;
	}
}
