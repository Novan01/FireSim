using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class livesScript : MonoBehaviour {

	/*********************************************************************
	This Script controls the lives shown in the GameObject HealthUI under HUD_Lives
	*********************************************************************/

	public int lives;

	//These 3 helmetss correspond with the icon for extra lives in the top right corner of the play screen. 
	// In the inspector view, These objects should be set to "FireFighterIcon(0)", "FireFighterIcon(1)", and "FireFighterIcon(2)" respectively.
	public GameObject helmet0;
	public GameObject helmet1;
	public GameObject helmet2;

	//public Sprite livesIcon = Sprite.FindObjectOfType<Sprite>("LivesIcon"); //unused code


	void Start () {
		lives = 3;
	}
		
	/*This changes the icons for lives as the player loses lives. */
	void Update () {

		if (lives > 3) {
			lives = 3;
		}
		if (lives == 3) {
			helmet0.GetComponent<Image> ().enabled = true;
			helmet1.GetComponent<Image> ().enabled = true;
			helmet2.GetComponent<Image> ().enabled = true;
		}
		if (lives == 2) {
			helmet0.GetComponent<Image> ().enabled = true;
			helmet1.GetComponent<Image> ().enabled = true;
			helmet2.GetComponent<Image> ().enabled = false;
		}
		if (lives == 1) {
			helmet0.GetComponent<Image> ().enabled = true;
			helmet1.GetComponent<Image> ().enabled = false;
			helmet2.GetComponent<Image> ().enabled = false;
		}
		if (lives < 0) {
			helmet0.GetComponent<Image> ().enabled = false;
			helmet1.GetComponent<Image> ().enabled = false;	
			helmet2.GetComponent<Image> ().enabled = false;
			lives = 0;
		}
		if (lives == 0) {
			SceneManager.LoadScene ("gameOverScene");
		}

	}
}
