using UnityEngine;
using System.Collections;

public class fadeOutAndDisappear : MonoBehaviour {


	void FixedUpdate () {
		transform.position += new Vector3 (0, 0.1f, 0);
		transform.GetComponent<SpriteRenderer> ().color -= new Color (0, 0, 0, 0.01f);

		if (transform.GetComponent<SpriteRenderer> ().color.a <= 0) {
			Destroy(this.gameObject);
		}

	}
}
