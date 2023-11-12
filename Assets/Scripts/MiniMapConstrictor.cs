using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Constricts the minimap camera's rotation & position to be above a rigid body (the firetruck)
public class MiniMapConstrictor : MonoBehaviour {
	public Rigidbody rb;
//	public float height = 500;
//	public float x = 90;
//	public float y = 0;
//	public float z = 0;
//	public float w = 90;


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (rb.transform.position.x, rb.transform.position.y - 500, rb.transform.position.z); //constantly changes the minimap camera's position to the same x and z values as the truck
		transform.rotation = new Quaternion (90, 0, 0, 90); //resticts the minimap camera's rotation to always look downward at the map
	}
}
