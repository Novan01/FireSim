using UnityEngine;
using System.Collections;

public class DayNight2  : MonoBehaviour
{

    public GameObject sun; //calls for the Empty object of the day night cycle.
    public Light /**/realSun; //calls for a light source(The sun)
    public Light moon; //calls for a light source(The Moon)
    public float secondsInFullDay = 120f; //how long the entire day is. This will technically be the speed of the sun and how many cycles it takes
    [Range(0, 1)]
    public float currentTimeOfDay = 0; //this is the time of day that the sun starts at
    [HideInInspector]
    public float timeMultiplier = 1f; //the rate at which the time changes
    
    float sunInitialIntensity = 1f; //creates a float
    public float intensityMultiplier = 1;
    public float intensityMultiplierMoon = 1;

    public float wantedTime; //Allows you to select what time you want to set it to.
    void Start()
    {
        //
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            setTime(); //sets time to selected time
        }

        UpdateSun(); //calls the method UpdateSun

        

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier; //calculates how the time will change 

        if (currentTimeOfDay >= 1)
        { //makes that when the currentTimeOfDay reaches 1 or a value greater, it will reset to 0
            currentTimeOfDay = 0;
        }
    }

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0); //this makes the sun rotate in order to change from day to night

        if (currentTimeOfDay > 0.71 || currentTimeOfDay < 0.23)
        {

            //if the current time of day is less than or equal to 0.23 or greater than or equal to 0.75, then the multiplier is 0
            intensityMultiplier -= 0.000271481481482f; //gradually decreases the light as the sun sets
            
            if(currentTimeOfDay > 0.79 || currentTimeOfDay < 0.23)
            {
                intensityMultiplier = 0; //
            }
        }
        else if(intensityMultiplier < 1 && currentTimeOfDay < 0.28)
        {
            intensityMultiplier += 0.000271481481482f; //gradually increases the light as the sun rises
        }
        else
        {
            intensityMultiplier = 1f;
        }
        realSun.intensity = sunInitialIntensity * intensityMultiplier;
    }
    void setTime()
    {
        currentTimeOfDay = wantedTime * 0.0416666666667f;
        if(wantedTime == 6f)
        {
            intensityMultiplier = 0.4416937f;
        }
        if(wantedTime == 18f)
        {
            intensityMultiplier = 0.117391f;
        }
    }
}
