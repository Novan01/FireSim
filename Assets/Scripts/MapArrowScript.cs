using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArrowScript : MonoBehaviour {
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//constantly changes the minimap arrow's position to the same x and z values as the truck
		transform.position = new Vector3 (rb.transform.position.x, rb.transform.position.y - 1020, rb.transform.position.z);
	}
}
