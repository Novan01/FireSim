using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is used to rotate objects such as wrenches. A simialr script is used for the AddressArrow.
public class wrenchScript : MonoBehaviour {

	public float rotSpeed = 115f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
	}
}
