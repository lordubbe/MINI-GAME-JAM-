using UnityEngine;
using System.Collections;

public class makeitdissaper : MonoBehaviour {

	void FixedUpdate () {
		transform.position += new Vector3 (0, 0.005f, 0);
		transform.GetComponent<SpriteRenderer> ().color -= new Color (0, 0, 0, 0.003f);

		if (transform.GetComponent<SpriteRenderer> ().color.a <= 0) {
			Destroy(this.gameObject);
		}

	}
}
