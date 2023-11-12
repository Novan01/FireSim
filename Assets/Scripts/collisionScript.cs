using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour {

	//THIS SCRIPT'S purpose is to detract lives from the player when they hit obstacles.

	public bool invinc;
	private int lifeNumber;

	//Here, colWith is a variable for the gameObject firetruck is hitting, and col is said gameObject's collider.
	//ColWith is set to the GameObject "Obstacle", in which all obstacles are children of.

	void Start () {
		invinc = false;
		lifeNumber = GameObject.Find ("Car").GetComponent<livesScript> ().lives;
	}

	//This segment detracts a life if the firetruck hits an obstacle.
	//Here, "obs" (short for obstacle) is a tag attatched to all obstacles that will do damage to the truck.
	void OnTriggerEnter(Collider other){
		if ((other.CompareTag("obs")) && (invinc == false)) {
			GameObject.Find ("Car").GetComponent<livesScript> ().lives = (GameObject.Find ("Car").GetComponent<livesScript> ().lives) - 1;
			invinc = true;
			StartCoroutine (loseLife());
		}

		//This adds a life when the player drives into a wrench, or any other object tagged to be an extra life.
		if (other.CompareTag ("extraLife")) {
			GameObject.Find ("Car").GetComponent<livesScript> ().lives = (GameObject.Find ("Car").GetComponent<livesScript> ().lives) + 1;

			Destroy (other.gameObject);
		}
	}

	/*Here, a coroutine is used so that the "Yield Return Wait" can be used so that 
	the player has some time to stop colliding with an object and not instantly die.*/

	IEnumerator loseLife(){
		
		yield return new WaitForSeconds (1);
		invinc = false;
	}

}
