using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCollisionator : MonoBehaviour {
	public static bool close = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollision (Collision collision){
		Debug.Log ("bleh");
		if (collision.gameObject.name == "DoorTruck") {
			close = true;
		}
		Debug.Log (close);
	}

	/*void OnCollisionEnter (Collision collision){
		Debug.Log ("enter");
		if (collision.gameObject.name == "DoorTruck") {
			close = true;
		}
		Debug.Log (close);
	}
	void OnCollisionExit (Collision collision){
		Debug.Log ("exit");
		if (collision.gameObject.name == "DoorTruck") {
			close = false;
		}
	}*/
}
