using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour {
	public Camera mapCam;
	public Camera mainCam;

	// Use this for initialization
	void Start () {
		mapCam.enabled = false;
		mainCam.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.M)) //activates the pop-up camera map and displays it on the screen when a button is pressed
		{
			mapCam.enabled = true;
			mainCam.enabled = true;
			//showMapCam ();
			//mapCam.enabled = true;
			//Display.displays [1].Activate ();
			//Display.displays [1].SetRenderingResolution(256, 256);
			//mapCam.SetTargetBuffers(Display.displays[1].colorBuffer, Display.displays[1].depthBuffer);
		} 
		else
		{
			//showMainCam
			mapCam.enabled = false;
			mainCam.enabled = true;
		}
	}
	void showMapCam()
	{
		mapCam.enabled = true;
		mainCam.enabled = false;
	}
	void showMainCam()
	{
		mapCam.enabled = false;
		mainCam.enabled = true;
	}
}
