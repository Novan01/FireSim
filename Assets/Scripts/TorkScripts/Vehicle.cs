using UnityEngine;

namespace Adrenak.Tork
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CenterOfMassAssigner))]
    [RequireComponent(typeof(AntiRoll))]
    [RequireComponent(typeof(Aerodynamics))]
    [RequireComponent(typeof(Motor))]
    [RequireComponent(typeof(Steering))]
    [RequireComponent(typeof(Brakes))]
    public class Vehicle : MonoBehaviour
    {
        [SerializeField] Rigidbody m_Rigidbody;
        [SerializeField] Steering m_Steering;
        [SerializeField] Motor m_Motor;
        [SerializeField] Brakes m_Brake;
        [SerializeField] Aerodynamics m_Aerodynamics;

        [SerializeField] float m_MaxReverseInput = -.5f;
        float num = .5f;

        [Tooltip("The maximum motor torque available based on the speed (KMPH)")]
        [SerializeField] AnimationCurve m_MotorTorqueVsSpeed = AnimationCurve.Linear(0, 10000, 250, 0);

        [Tooltip("The steering angle based on the speed (KMPH)")]
        [SerializeField] AnimationCurve m_MaxSteeringAngleVsSpeed = AnimationCurve.Linear(0, 35, 250, 5);

        [Tooltip("The down force based on the speed (KMPH)")]
        [SerializeField] AnimationCurve m_DownForceVsSpeed = AnimationCurve.Linear(0, 0, 250, 2500);

        VehicleInput m_Input = VehicleInput.Get(VehicleInputType.Keyboard);

        private void Start()
        {
            m_Rigidbody.isKinematic = true;
        }
        private void Update()
        {


            var speed = Vector3.Dot(m_Rigidbody.velocity, transform.forward) * 3.6F;


            if (Input.GetKey(KeyCode.Alpha1) || Input.GetButton("AButton")) //park
            {
                m_Rigidbody.isKinematic = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetButton("BButton")) //reverse the truck 
            {
                m_Rigidbody.isKinematic = false;
                num = 0f;
                m_MaxReverseInput = -0.5f;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetButton("XButton")) //neutral
            {
                m_Rigidbody.isKinematic = false;
                num = 0f;
                m_MaxReverseInput = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetButton("YButton")) //drive the truck 
            {
                m_Rigidbody.isKinematic = false;
                num = 1f;
                m_MaxReverseInput = 0;
            }
            

            m_Steering.range = m_MaxSteeringAngleVsSpeed.Evaluate(speed);
            m_Steering.value = m_Input.GetSteering();

            m_Motor.maxTorque = m_MotorTorqueVsSpeed.Evaluate(speed);
            m_Motor.value = Mathf.Clamp(m_Input.GetAcceleration(), m_MaxReverseInput, num);

            m_Aerodynamics.downForce = m_DownForceVsSpeed.Evaluate(speed);
            m_Aerodynamics.midAirSteerInput = m_Input.GetSteering();

            m_Brake.value = m_Input.GetBrake();

            /* if (m_Brake.value == 1f && speed < 1)
             {
                  if (Input.GetKey(KeyCode.Alpha1)) //parking the truck
                  {
                  do
                  {
                      m_Rigidbody.isKinematic = true;
                      m_Brake.value = m_Input.GetBrake();

                  } while (m_Brake.value != 1f && speed > 0);
                  }
                  else if (Input.GetKeyDown(KeyCode.Alpha2)) //reverse the truck
                  {
                    do {
                      m_Rigidbody.isKinematic = false;

                      m_Motor.maxTorque = m_MotorTorqueVsSpeed.Evaluate(speed);
                      m_Motor.value = Mathf.Clamp(m_Input.GetAcceleration(), m_MaxReverseInput, 0);

                      m_Steering.range = m_MaxSteeringAngleVsSpeed.Evaluate(speed);
                      m_Steering.value = m_Input.GetSteering();

                      m_Aerodynamics.downForce = m_DownForceVsSpeed.Evaluate(speed);
                      m_Aerodynamics.midAirSteerInput = m_Input.GetSteering();

                      m_Brake.value = m_Input.GetBrake();
                       } while (m_Brake.value != 1f && speed > 0);

                  // m_Brake.value = m_Input.GetBrake();
              }
                  else if (Input.GetKeyDown(KeyCode.Alpha3))
                  {
                      do {
                             m_Rigidbody.isKinematic = false;
                             m_Brake.value = m_Input.GetBrake();

                         } while (m_Brake.value != 1f && speed > 0);

                    //  m_Motor.maxTorque = m_MotorTorqueVsSpeed.Evaluate(speed);
                     // m_Motor.value = Mathf.Clamp(m_Input.GetAcceleration(), 0, 1);
                  }
                  else if (Input.GetKeyDown(KeyCode.Alpha4)) //drive the truck 
                  {
                     do
                     {

                      m_Rigidbody.isKinematic = false;

                    //  m_Steering.range = m_MaxSteeringAngleVsSpeed.Evaluate(speed);
                    //  m_Steering.value = m_Input.GetSteering();

                      m_Motor.maxTorque = m_MotorTorqueVsSpeed.Evaluate(speed);
                      m_Motor.value = Mathf.Clamp(m_Input.GetAcceleration(), 0, 1);

                      m_Aerodynamics.downForce = m_DownForceVsSpeed.Evaluate(speed);
                      m_Aerodynamics.midAirSteerInput = m_Input.GetSteering();

                     // m_Brake.value = m_Input.GetBrake();

                      } while (m_Brake.value != 1f && speed > 0);

                  // m_Brake.value = m_Input.GetBrake();
                    } 
              } */
        }

        void OnGUI()
        {
            var speed = Vector3.Dot(m_Rigidbody.velocity, transform.forward) * 2.23694f;

            //Mathf.Round(speed);

            if (speed < 0)
            {                                                                           //keeps the speed positive
                speed *= -1;
            }

            GUI.Box(new Rect(10, 10, 75, 60), "Speed");                                 //creates the box for the display

            GUI.Label(new Rect(20, 40, 80, 20), Mathf.Round(speed) + " MPH");          //Displays the speed rounded to the nearest whole number


        }
    }
}