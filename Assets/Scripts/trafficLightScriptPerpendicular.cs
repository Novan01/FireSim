using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLightScriptPerpendicular : MonoBehaviour {

	public GameObject redlight; 	//create an object for the red light
	public GameObject yellowlight; 	//create an object for the yellow light
	public GameObject greenlight; 	//create an object for the green light

	public Material redInitial; 	//create material for red light when it is off
	public Material greenInitial; 	//create material for green light when it is off
	public Material yellowInitial; 	//create material for yellow light when it is off

	public Material redFinal; 	//create material for red light when it is on
	public Material greenFinal; 	//create material for green light when it is on
	public Material yellowFinal; 	//create material for yellow light when it is on

	public Light rl; //create light value for red light
	public Light yl; //create light value for yellow light
	public Light gl; //create light value for green light

	public GameObject otherredlight; //create an object for the red light on the other traffic light at the intersection
	public GameObject otheryellowlight; //create an object for the yellow light on the other traffic light at the intersection
	public GameObject othergreenlight; //create an object for the green light on the other traffic light at the intersection

	public GameObject othertrafficlight; //create an object for the other traffic light at the intersection
	public int waittime; //the time for how long each light is on 

	public Light orl; //create light value for the red light on the other traffic light at the intersection
	public Light oyl; //create light value for the yellow light on the other traffic light at the intersection
	public Light ogl;	//create light value for the green light on the other traffic light at the intersection




	// Initializes the variables
	void Start () {
		rl = redlight.GetComponent<Light>(); //assign the light component of the red light object to the light property
		yl = yellowlight.GetComponent<Light> (); //assign the light component of the yellow light object to the light property
		gl = greenlight.GetComponent<Light> (); //assign the light component of the green light object to the light property

		orl = otherredlight.GetComponent<Light>(); //assign the light component of the red light object to the light property from the other traffic light that is on the intersection
		oyl = otheryellowlight.GetComponent<Light>(); //assign the light component of the yellow light object to the light property from the other traffic light that is on the intersection
		ogl = othergreenlight.GetComponent<Light>(); //assign the light component of the green light object to the light property from the other traffic light that is on the intersection

	//	othertrafficlight = GameObject.Find("tl0"); //assign the object for the other traffic light to the other traffic light on the intersection by finding it
		waittime = othertrafficlight.GetComponent<trafficLightScript>().deltat; //waitime is how long it takes for each light to change on the other traffic light. It calls the script for the other traffic light

		rl.enabled = true; //sets the light to have red light initially on
		yl.enabled = false; //sets the light to have the yellow light initially off
		gl.enabled = false; //sets the light to have the green light initially off 

		StartCoroutine (changelight ()); //call for the change light method to start
	}

	/****************************************************************
	THIS CODING TAKES VARIABLES FROM THE OTHER TRAFFIC LIGHT SCRIPT THAT IT DOESN'T CURRENTLY NEED. ORIGINALLY, I PLANNED ON MAKING THIS SCRIPT CHANGE TRAFFIC LIGHTS 
	BASED OFF OF WHAT LIGHT IS SHOWING FOR OTHER TRAFFICLIGHT (EXAMPLE IF CROSS TRAFFIC HAS A GREEN LIGHT, THEN THIS LIGHT WOULD BE RED). INSTEAD THOUGH, I JUST MADE IT 
	A COUROUTINE THAT IS IN-SYNC WITH THE OTHER'S CODE. THIS SHOULD BE TRUE IF (GREENLIGHT DURATION + YELLOWLIGHT DURATION = REDLIGHT DURATION) FOR BOTH SETS OF LIGHTS.
	****************************************************************/


	IEnumerator changelight(){

		while (true) {

				rl.enabled = true;
				if (rl.enabled == true) { //when red light is on, the color of the bulb will be red so it looks like it is on
					redlight.GetComponent<MeshRenderer> ().material = redFinal;
				}
				yl.enabled = false;
				if (yl.enabled == false) { //when yellow light is off, the color of the light will change to a darker color to make it off
					yellowlight.GetComponent<MeshRenderer> ().material = yellowInitial;
				}
				gl.enabled = false;
				if (gl.enabled == false) { //when green light is off, the color of the light will change to a darker color to make it off
					greenlight.GetComponent<MeshRenderer> ().material = greenInitial;
				}
			yield return new WaitForSeconds (waittime*3/2); //the time it takes for the light to turn to the next color

				rl.enabled = false;
				if (rl.enabled == false) { //when red light is off, the color of the light will change to a darker color to make it off
					redlight.GetComponent<MeshRenderer> ().material = redInitial;
				} 
				yl.enabled = false;
				if (yl.enabled == false) { //when yellow light is off, the color of the light will change to a darker color to make it off
					yellowlight.GetComponent<MeshRenderer> ().material = yellowInitial;
				}
				gl.enabled = true;
				if (gl.enabled == true) { //when green light is on, the color of the bulb will be green so it looks like it is on
					greenlight.GetComponent<MeshRenderer> ().material = greenFinal;
				}
			
			yield return new WaitForSeconds (waittime); //the time it takes for the light to turn to the next color

				rl.enabled = false;
				if (rl.enabled == false) { //when red light is off, the color of the light will change to a darker color to make it off
					redlight.GetComponent<MeshRenderer> ().material = redInitial;
				} 
				yl.enabled = true;
				if (yl.enabled == true) { //when yellow light is on, the color of the bulb will be yellow so it looks like it is on
					yellowlight.GetComponent<MeshRenderer> ().material = yellowFinal;
				}
				gl.enabled = false;
				if (gl.enabled == false) { //when green light is off, the color of the light will change to a darker color to make it off
					greenlight.GetComponent<MeshRenderer> ().material = greenInitial;
				}
			yield return new WaitForSeconds (waittime/2); //the time it takes for the light to turn to the next color
		}
	}
}
