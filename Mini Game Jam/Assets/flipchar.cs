using UnityEngine;
using System.Collections;

public class flipchar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			transform.localScale = new Vector3(-1,1,1);
		}else if(Input.GetKeyDown (KeyCode.D)){
			transform.localScale = new Vector3(1,1,1);
		}
	}
}
