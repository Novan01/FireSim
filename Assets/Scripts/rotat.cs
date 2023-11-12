using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotat : MonoBehaviour {

	public float rotSpeed = 115f;

	// Update is called once per frame
	void Update () {
//		transform.Rotate(Vector3.forward, rotSpeed * Time.deltaTime);
		transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
	}
}
