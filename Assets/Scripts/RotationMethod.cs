using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls the rotation of steering wheel
public class RotationMethod : MonoBehaviour {
	public Rigidbody rb;
	float rot = 90;
	float turn = 10;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.LeftArrow)) {
			if (rot < 84) {	//<90
				therotatemethod ();
				rot += 12;
			}
			if (rot > 96) {		//>90
				therotatemethod ();
				rot -= 12; 
			}
			if(rot >= 84 && rot <= 96) {
				rot = 90;
				therotatemethod ();
			}
			turn = 10;
		}

		if (rot < 490 && rot > -310) {		//490 && -310
			if (Input.GetKey (KeyCode.RightArrow)) {
				rot += turn;
				if (turn > 6) {turn-=.2f;}
				therotatemethod ();
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				rot -= turn;
				if (turn > 6) {turn-=.2f;}
				therotatemethod ();
			}
		}
	}

	void therotatemethod (){
		transform.localEulerAngles = new Vector3(-90,0,rot);
	}
}
