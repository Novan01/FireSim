using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script makes the green arrow that appears above houses move up and down periodically and rotate.
public class rotateArrowScript : MonoBehaviour {

	public float rotSpeed;
	public float movSpeed;
	public float timer;
	public float direc;

	void Start(){
		rotSpeed = 120f;
		movSpeed = 10f;
		direc = 1f;
		timer = 40f;
	}
	void Update () {
		transform.Rotate(Vector3.down, rotSpeed * Time.deltaTime);

		if (timer<=0) {
			direc = direc * (-1);
			transform.Translate(new Vector3(0,1*direc*(1/100*(100-timer)),0));
			timer = 40;
		} else if(timer>0) {
			transform.Translate(new Vector3(0,1*direc,0));
			timer = timer -1;
		}
			
	}
}
