using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	public Transform bulletSpawn;
	public Transform bullet;
	public Transform player;	
	private Vector3 shootDir;

	public bool shooting;
	public float shootSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		shootDir = bulletSpawn.position+Vector3.Normalize(bulletSpawn.position-player.position);
		Debug.DrawLine (bulletSpawn.position, shootDir, Color.red);
	
	
		handleMouseInputs ();
		if (shooting) {
			print("nigger");
		}
	}

	void handleMouseInputs(){
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			shooting = true;
		} else if (Input.GetKeyUp (KeyCode.Mouse0)) {
			shooting = false;
		}
	}

	IEnumerator fireBullet(float shootInterval){
		while (shooting) {
			Transform bullet = (Transform)Instantiate (bullet, bulletSpawn.position, Quaternion.identity) as Transform;
			yield return new WaitForSeconds (shootInterval);
		}
	}
}
