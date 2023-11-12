using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLightScript : MonoBehaviour {

/************************************
This Script is a very basic trafic light script. Chances are, you will have to come up with a more advanced version for turns and what not. 
In the inspector menu, under the object this script is attatched to should be three lights. Drag RedLight, YellowLight, and GreenLight into 
the corresponding spots in this script for GameObject redlight, yellowolight, and greenlight, if these spots are ever empty.

Hopefully, if you understand how this script works, you will either continue this format for turns and what not, or create an entirely new format that
is more effective and more practical than what I am currently doing.
************************************/


	public GameObject redlight;
	public GameObject yellowlight;
	public GameObject greenlight;

	public int deltat = 10; //This variable is named "delta t", which means "Change in Time"

	public Light rl;
	public Light yl;
	public Light gl;

	// Use this for initialization
	void Start () {
		rl = redlight.GetComponent<Light>();
		yl = yellowlight.GetComponent<Light> ();
		gl = greenlight.GetComponent<Light> ();
	
		StartCoroutine (change());
	}

	IEnumerator change(){
		
		while (true) {
			rl.enabled = false;
			yl.enabled = false;
			gl.enabled = true;
			yield return new WaitForSeconds (deltat);
			rl.enabled = false;
			yl.enabled = true;
			gl.enabled = false;
			yield return new WaitForSeconds (deltat/2);
			rl.enabled = true;
			yl.enabled = false;
			gl.enabled = false;
			yield return new WaitForSeconds (deltat*3/2);
		}
	}

//This code is from a demo unity project made by Khalil. It involves a coroutine, so I stuck it here for reference 
	//	public Material[] colorSwap = new Material[6];
	//	public GameObject colChange;
	//	private MeshRenderer meshRend;
	//	private bool run = true;
	//
	//	void Awake (){
	//		meshRend = colChange.GetComponent<MeshRenderer> ();
	//		StartCoroutine (delayy());
	//	}
	//
	//
	//	//	void Update () {
	//	//		
	//	//	}
	//	//
	//	IEnumerator delayy(){
	//
	//		while (run) {
	//			for (int col = 0; col < colorSwap.Length; col++) {
	//				meshRend.material = colorSwap [col];
	//				yield return new WaitForSeconds (1);
	//			}
	//		}
	//
	//	}
	//







}
