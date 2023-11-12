using UnityEngine;
//part of code came from https://gist.github.com/victorbstan/e5903829576eaf6ce5e3 mainly the wheel rotation

namespace Adrenak.Tork {
	public class WheelRenderer : MonoBehaviour {
		public Wheel wheel;
		public float offset;
		public float angle;
        public float angle1;

        // Wheel Wrapping Objects
        public Transform WheelWrapper;

        // Wheel Meshes
        public Transform WheelMesh;

        // Wheel Colliders
        // Front
        public WheelCollider wheelC;



        private void OnValidate() {
			SyncPosition();
		}

		public void Update() {
			SyncPosition();
			SyncRotation();
		}

		void SyncPosition() {
			if (wheel == null) {
				Debug.LogWarning("No Wheel attached to WheelRenderer (" + gameObject.name + ")");
				return;
			}

			transform.position = new Vector3(
				wheel.transform.position.x,
				wheel.transform.position.y,
				wheel.transform.position.z
			); 

			transform.localPosition = new Vector3(
				transform.localPosition.x + offset, transform.localPosition.y - (wheel.suspensionDistance - wheel.CompressionDistance),
				transform.localPosition.z
			);
		}

		void SyncRotation() {
            //transform.localEulerAngles = wheel.transform.localEulerAngles;

            //var newX = transform.localEulerAngles.x + wheel.Velocity.magnitude;
            //transform.localEulerAngles = new Vector3(
            //	newX,
            //	//transform.localEulerAngles.x + wheel.Velocity.magnitude * 10,
            //	transform.localEulerAngles.y,
            //	transform.localEulerAngles.z
            //);

            /* if (Input.GetKey(KeyCode.W) )//|| Input.GetKeyUp(KeyCode.W))
             {
                 transform.localEulerAngles = Vector3.zero;
                 angle += (Time.deltaTime * Mathf.Abs(wheel.Velocity.z)) / (2 * Mathf.PI * wheel.radius) * 360;
                 wheel.steerAngle = angle * Input.GetAxis("Horizontal");
                 //angle1 += (Time.deltaTime * -1 * Mathf.Abs(wheel.Velocity.z)) / (2 * Mathf.PI * wheel.radius) * 360;
                 transform.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
                 transform.Rotate(new Vector3(1, 0, 0), angle); //makes the wheel rotate as wheels
             } */
            /* if (Input.GetKey(KeyCode.S))
            {
                transform.localEulerAngles = Vector3.zero;
                angle -= (Time.deltaTime * wheel.Velocity.z) / (2 * Mathf.PI * wheel.radius) * 360;
                // wheel.steerAngle = angle * Input.GetAxis("Horizontal");
               // angle1 += (Time.deltaTime * -1 * Mathf.Abs(wheel.Velocity.z)) / (2 * Mathf.PI * wheel.radius) * 360;
                transform.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
                transform.Rotate(new Vector3(1, 0, 0), angle); //makes the wheel rotate as wheels
            } */
            // transform.Rotate(new Vector3(0, -1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
            //transform.Rotate(new Vector3(-1, 0, 0), angle1); //makes the wheel rotate as wheels


            //  wheel.transform.Rotate(weelColli.rpm / 60 * 360 * Time.deltaTime, 0, 0); 

            /*  if (Input.GetKey(KeyCode.W) || Input.GetKeyUp(KeyCode.W))
              {
                  transform.localEulerAngles = Vector3.zero;
                  transform.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
                  transform.Rotate(new Vector3(1, 0, 0), angle); //makes the wheel rotate as wheels 
              }
              else if (Input.GetKey(KeyCode.S))
              {
                  transform.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
                  transform.Rotate(new Vector3(1, 0, 0), angle1); //makes the wheel rotate as wheels 

              }
             transform.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
             transform.Rotate(new Vector3(1, 0, 0), angle); //makes the wheel rotate as wheels  */

            // frontLeftWheelMesh.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
            // frontRightWheelMesh.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel

            //WheelWrapper.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
            // transform.Rotate(new Vector3(1, 0, 0), angle); //makes the wheel rotate as wheels

            // Wheel rotation
            //WheelMesh.Rotate(0, wheelC.rpm / 60 * 360 * Time.deltaTime, 0);

            transform.localEulerAngles = Vector3.zero; //KEEP THIS LINE. sets the wheels in the correct rotational position. Without it, the wheels will go CRAZY
            angle += (Mathf.Abs(wheel.Velocity.z)) / (2 * Mathf.PI * wheel.radius) * 360 * Time.deltaTime;
            transform.Rotate(new Vector3(0, 1, 0), wheel.steerAngle - transform.localEulerAngles.y); //makes the wheel go into the direction of the steering wheel
            transform.Rotate(new Vector3(1, 0, 0), angle); //makes the wheel rotate as wheels

        }
    }
}
