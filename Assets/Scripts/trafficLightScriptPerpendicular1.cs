/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;*/

/*This Script depends on TrafficLightScript. In the inspector menu, under the object this script is attatched to should be three lights. Drag RedLight, 
YellowLight, and GreenLight into the corresponding spots in this script for GameObject redlight, yellowolight, and greenlight, if these spots are ever empty.

Also, do the same for the GameObjects otherredlight, otheryellowlight, othergreenlight, and othertrafficlight except you get these from another GameObject traffic light that 
runs the script "trafficLightScript" from which this script is dependant upon.

Hopefully, if you understand how this script works, you will either continue this format for turns and what not, or create an entirely new format that
is more effective and more practical than what I am currently doing.
************************************/

/*
	public GameObject redlight;
	public GameObject yellowlight;
	public GameObject greenlight;

	public GameObject otherredlight;
	public GameObject otheryellowlight;
	public GameObject othergreenlight;

	public GameObject othertrafficlight;
	public int waittime;

	public Light rl;
	public Light yl;
	public Light gl;

	public Light orl;
	public Light oyl;
	public Light ogl;	*/



/*
	// Initializes the variables
	void Start () {
		rl = redlight.GetComponent<Light>();
		yl = yellowlight.GetComponent<Light>();
		gl = greenlight.GetComponent<Light>();

		orl = otherredlight.GetComponent<Light>();
		oyl = otheryellowlight.GetComponent<Light>();
		ogl = othergreenlight.GetComponent<Light>();

		waittime = othertrafficlight.GetComponent<trafficLightScript>().deltat;

		rl.enabled = true;
		yl.enabled = false;
		gl.enabled = false;

		StartCoroutine (changelight ());
	}
    */
	/****************************************************************
	THIS CODING TAKES VARIABLES FROM THE OTHER TRAFFIC LIGHT SCRIPT THAT IT DOESN'T CURRENTLY NEED. ORIGINALLY, I PLANNED ON MAKING THIS SCRIPT CHANGE TRAFFIC LIGHTS 
	BASED OFF OF WHAT LIGHT IS SHOWING FOR OTHER TRAFFICLIGHT (EXAMPLE IF CROSS TRAFFIC HAS A GREEN LIGHT, THEN THIS LIGHT WOULD BE RED). INSTEAD THOUGH, I JUST MADE IT 
	A COUROUTINE THAT IS IN-SYNC WITH THE OTHER'S CODE. THIS SHOULD BE TRUE IF (GREENLIGHT DURATION + YELLOWLIGHT DURATION = REDLIGHT DURATION) FOR BOTH SETS OF LIGHTS.
	****************************************************************/
/*

	IEnumerator changelight(){

		while (true) {
			rl.enabled = true;
			yl.enabled = false;
			gl.enabled = false;
			yield return new WaitForSeconds (waittime*3/2);
			rl.enabled = false;
			yl.enabled = false;
			gl.enabled = true;
			yield return new WaitForSeconds (waittime);
			rl.enabled = false;
			yl.enabled = true;
			gl.enabled = false;
			yield return new WaitForSeconds (waittime/2);
		}
	}
}
*/