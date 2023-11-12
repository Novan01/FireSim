using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POVSwap : MonoBehaviour
{
    public GameObject fp_camera;
    public GameObject tp_camera;
    public bool swap;
    // Start is called before the first frame update
    void Start()
    {
        swap = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
        
            fp_camera.SetActive(!swap);
            tp_camera.SetActive(swap);

            swap = !swap;
      
        }
       /* else
        {
            fp_camera.SetActive(true);
            tp_camera.SetActive(false);
          
        } */
    }
}
