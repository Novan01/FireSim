//using System;
//using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
//using UnityStandardAssets.Utility;
//using Random = UnityEngine.Random;


using UnityEngine;
using System.Collections;

public class ThirdPersonMouseCamera : MonoBehaviour {

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yee= 0.0f;
	private float pitch = 0.0f;

	void Update () {
		yee+= speedH * Input.GetAxis("Mouse X");
		pitch += speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yee, 0.0f);
	}
}