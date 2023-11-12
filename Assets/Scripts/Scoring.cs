using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

	public float score;
	public Text scoreText;
	public float time = 0.0f;
	public float timePass = 1.1f;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > timePass) {
			time = time - timePass;
			score = Mathf.Floor(score - Time.deltaTime);
			scoreText.text = "Score: " + score;
		}
		if (score <= 2) {
			score = 1;
		}
	}

}
