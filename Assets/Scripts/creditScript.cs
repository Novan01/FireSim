using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditScript : MonoBehaviour {

	//This script is to be applied to the credits menu on the main menu. It's purpose is to make the credits scroll upwards.
	//Note- the way this works, the back button cannot be included in this script, or else it will scroll off screen along with the credits
	public bool roll;

	public void Start () {

		roll = false;
		transform.SetPositionAndRotation(new Vector3 (220f,210f,0f), new Quaternion(0,0,0,0));
		StartCoroutine (rollCredits ());
	}

	public void Update () {
		if (roll) {
			transform.Translate( new Vector3 (0f, 1.2f, 0f));
		}
	}

	//used for a delay before the credits start moving
	IEnumerator rollCredits (){
		yield return new WaitForSeconds (1);
		roll = true;
	}
}
