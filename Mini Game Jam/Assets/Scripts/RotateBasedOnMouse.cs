﻿using UnityEngine;
using System.Collections;

public class RotateBasedOnMouse : MonoBehaviour {

	public Vector3 lookPos;
	public GameObject player;

	void Start(){
		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update () {
		//position at player
		transform.position = player.transform.position;

		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10; //The distance from the camera to the player object
		lookPos = Camera.main.ScreenToWorldPoint(mousePos);
		lookPos -= transform.position;
		float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

		//Debug.DrawRay( transform.position, Vector3.Normalize(lookPos)*1.5f, Color.yellow);

		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//orient direction based on angle
		if(angle > 90 && angle < 180 || angle > -180 && angle < -90){
			transform.localScale = new Vector3(1, -1, 1);
		}else if(angle > -90 && angle < 90){
			transform.localScale = new Vector3(1, 1, 1);
		}
	}
}
