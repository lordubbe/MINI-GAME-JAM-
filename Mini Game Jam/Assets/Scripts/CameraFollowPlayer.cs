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
		transform.position = Vector3.Lerp (transform.position, new Vector3 (player.position.x, player.position.y, -camDistance), 0.1f);
		Camera.main.orthographicSize = camDistance;
	}
}
