using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class StopWatch : MonoBehaviour
{
    public int timeNow = 0;
    public Text timer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GainTime");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = ("" + timeNow);
    }

    IEnumerator GainTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeNow++;
        }
    }

}

