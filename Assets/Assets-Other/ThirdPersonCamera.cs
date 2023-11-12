using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{

    public const float Y_ANGLE_MIN = 0.0f;
    public const float Y_ANGLE_MAX = 30.0f;


    public Transform lookAt;
    public Transform camTransform;

    public Camera cam;

    public float distance = 10.0f;                                              //distance btwn camera and object
    public float currentX = 0.0f;                                               //current x of the camera
    public float currentY = 0.0f;                                               //current y of the camera
    public float sensitivityX = 10.0f;                                          //sensitivity of x input on the mouse
    public float sensitivityY = 1.0f;                                            //sensitivity of y input on the mouse

    public void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            distance -= Input.mouseScrollDelta.y;                               //scroll mouse in toward the object
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            distance -= Input.mouseScrollDelta.y;                               //scroll mouse out toward the object
        }



        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);            //limits the y axis rotation so that the camera is controlled on the subject
    }


    public void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;             //updates the position of the camera around the object
        camTransform.LookAt(lookAt.position);
    }



}