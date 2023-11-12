using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowpuddlebehavior : MonoBehaviour
{

    /* THIS SCRIPT IS ESSENTIALLY A COPY-PASTE OF RAINPUDDLEBEHAVIOR.
     * FOR INFORMATION ABOUT THESE VARIABLES, CONSULT THAT SCRIPT.
     * THEY USE THE SAME VARIABLES, ALTHOUGH THEY HAVE SLIGHTLY DIFFERENT NAMES.
     * THE NAMES ARE SIMILAR ENOUGH, THOUGH. */

    GameObject weathersystem;
    DynamicWeather weather1;
    float xdiff;
    float xinitial;
    bool updatelimited;
    int newpuddlelimit;

    // Start is called before the first frame update
    void Start()
    {
        weathersystem = GameObject.Find("WeatherSystem");//Used to find the current weather state
        weather1 = weathersystem.GetComponent<DynamicWeather>();//Gets the DynamicWeather script attatched to the WeatherSystem
        updatelimited = false;
        newpuddlelimit = 0;
        StartCoroutine(SnowBuildUp());
    }

    // Update is called once per frame
    void Update()
    {
        if (!updatelimited)//basically allows update limit to do what it is supposed to do
        {
            if (!weather1.snowParticleSystem.isPlaying && transform.position.y > -2)//ensures that the original puddle always exists
            {
                StartCoroutine(SnowShrink());//calls the decrease method
            }
            else if (weather1.snowParticleSystem.isPlaying && transform.position.y > 0)//ensures that the original puddle stays the same size
            {
                StartCoroutine(SnowGrow());//calls the increase method
            }
        }
        if (weather1.snowParticleSystem.isPlaying && transform.position.y < -10 && newpuddlelimit == 0 && Time.time > 60)//in the case snow starts up again, the original puddle will retain the ability to spawn a new one on the map
        {
            Instantiate(this.gameObject, new Vector3(0, -1, 0), Quaternion.identity); //restarts the cycle in case rain starts up again
            newpuddlelimit++; //restricts the original puddle so that it can only spawn 1 when rain starts again
            StartCoroutine(Wait(60));
        }
    }

    IEnumerator Wait(int x)//resets the new puddle limit after a certain amount of time so that the original puddle can spawn a new puddle when it starts raining again
    {
        yield return new WaitForSeconds(x);
        newpuddlelimit = 0;
    }

    IEnumerator SnowBuildUp()
    {
        GameObject snow1 = this.gameObject; //gets the puddle asset

        Vector3 rndm = new Vector3
            (weather1.playerPosition.transform.position.x + Random.Range(-25, 25),
            0.01f,
            weather1.playerPosition.transform.position.z + Random.Range(-25, 25)); //holds a random position on the ground that is close to the player

        xinitial += transform.localScale.x;

        if (xinitial > 3.5)
        {
            xdiff = Random.Range(-(this.xinitial - 0.1f), -0.1f);//If the previous puddle is too big, the next will always be smaller
            transform.localScale += new Vector3(xdiff, 0, xdiff);
        }
        else
        {
            xdiff = Random.Range(-(this.xinitial - 0.1f), 2f);//If the previous puddle is not too big, it will either increase or decrease the size of the next
            transform.localScale += new Vector3(xdiff, 0, xdiff);
        }

        yield return new WaitForSeconds(7);//waits 7 seconds

        if (weather1.snowParticleSystem.isPlaying)
            Instantiate(snow1, rndm, Quaternion.identity); //spawns a puddle close to the player
    }

    IEnumerator SnowGrow()
    {
        updatelimited = true;//stops update from calling this method when it is already active. If you want a more realistic looking grow, set this to false

        yield return new WaitForSeconds(1);

        if (transform.localScale.x < 7)//sets a maximum size for puddles
        {
            transform.localScale += new Vector3(0.1f, 0f, 0.1f);//puddle grows (If you set updatelimited to false earlier, decrease the transform to 0.01f)
        }

        updatelimited = false;//allows update to call this method again
    }

    IEnumerator SnowShrink()
    {
        updatelimited = true;//stops update from calling this method when it is already active. If you want a more realistic looking shrink, set this to false

        yield return new WaitForSeconds(1);

        transform.localScale += new Vector3(-0.2f, 0, -0.2f);//snow shrinks (If you set updatelimited to false earlier, set the transform to -0.01f)

        if (transform.localScale.x < 0.1)//deletes the snow puddles if they get small enough
        {
            Destroy(this.gameObject);//snow doesn't exist in Texas anyway
        }

        updatelimited = false;//allows update to call this method again
    }


}
