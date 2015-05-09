using UnityEngine;
using System.Collections;

public class Skyer : MonoBehaviour {
	public float minX = 15.5f;
	public float maxX = 32.5f;
	bool movingright = false;
	public float speed = 5f;
	private float desiredSpeed;
	// Use this for initialization

	void Start () {

	}
	void FixedUpdate (){
		//	transform.position += new Vector3 (3f, 0f, 0f) *Time.deltaTime;

		if (movingright) {
			desiredSpeed = speed;
		} else {
			desiredSpeed = -speed;
		}

		if (transform.position.x <= minX) {
			movingright = true;
		}
		else if (transform.position.x >= maxX) { // Checking right boundary
			movingright = false;
		}
		transform.position += new Vector3 (desiredSpeed, 0f, 0f) * Time.deltaTime;


	}
}