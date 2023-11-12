using UnityEngine;
using UnityEngine.UI;
using System;

public class RealWorldTime : MonoBehaviour
{
    // Start is called before the first frame update
    private Text clock;
    
    void Start()
    {
        
        
    }
    private void Awake()
    {
        clock = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        string hour = LeadingZero(time.Hour);
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);

        clock.text = hour + ":" + minute + ":" + second;
        
    }
    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
  
}
