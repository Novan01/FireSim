using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;


public class Pulse : MonoBehaviour {

    private int alpha = 255;
    public bool goingDown = true;
    Color col = new Color(0, 0, 0, 255);

    void Start()
    {
        StartCoroutine(pulse());
    }

    IEnumerator pulse()
    {
        while(true)
        {
            if(GetComponent<Text>().color.a > 0)
            {
                col.a -= 5f;
                Debug.Log(col);
                //GetComponent<Text>().color = col;
            }
            else
            {
                col.a += 5f;
                //GetComponent<Text>().color = col;

            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        Debug.Log("test");
        GetComponent<Text>().color = col;
        if(Input.GetKeyDown(KeyCode.Escape) || CrossPlatformInputManager.GetButton("Start"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
