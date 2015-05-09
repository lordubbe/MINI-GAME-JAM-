using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	public int playerHealth;
	public int points;

	public Text scoreText;

	void Start(){
		scoreText = GameObject.Find ("ScoreText").GetComponent<Text>();
	}


	void FixedUpdate(){
		scoreText.text = points.ToString();
	}

}
