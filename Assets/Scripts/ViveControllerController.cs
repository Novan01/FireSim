﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(UnityEngine.Input.GetJoystickNames ());
	}
}
