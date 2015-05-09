using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
	public float camDistance;
	public Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (player.GetComponent<Movement> ().isJumping) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (player.position.x, player.position.y-1.5f, -camDistance), 0.1f);
		} else {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (player.position.x, player.position.y+1f, -camDistance), 0.05f);
		}
		Camera.main.orthographicSize = camDistance;
	}
}
