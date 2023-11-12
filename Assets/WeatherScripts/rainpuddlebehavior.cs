using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainpuddlebehavior : MonoBehaviour
{
        
    GameObject weathersystem;//makes it possible to get the current weather state
    DynamicWeather weather;//these two are used to get information about the weather
    float xdiff;//used to change sizes of new puddles
    float xinitial;//used to retain the size of the previous puddle
    bool updatelimited;//prevents the update method from calling other methods too quickly
    int newpuddlelimit;//prevents too many puddles from being spawned by the original
    //bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        weathersystem = GameObject.Find("WeatherSystem");//allows this script to use components of the weathersystem
        weather = weathersystem.GetComponent<DynamicWeather>();//allows this script to know what the current weather is
        updatelimited = false;
        newpuddlelimit = 0;
        StartCoroutine(RainBuildUp());//calls the method to spawn a new puddle
        //triggered = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!updatelimited)//basically allows update limit to do what it is supposed to do
        {
            if (!weather.stormParticleSystem.isPlaying && transform.position.y > -2)//the last condition ensures that the original puddle always exists
            {
                StartCoroutine(DecreaseInSize());//calls the decrease method
            }
            else if(weather.stormParticleSystem.isPlaying && transform.position.y > -2)
            {
                StartCoroutine(IncreaseInSize());//calls the increase method
                //triggered = false;
            }
        }
        if (weather.stormParticleSystem.isPlaying && transform.position.y < -10 && newpuddlelimit == 0 && Time.time > 60)//in the case rain starts up again, the original puddle will retain the ability to spawn a new one on the map
        {
            Instantiate(this.gameObject, new Vector3(0, -1, 0), Quaternion.identity); //restarts the cycle in case rain starts up again
            newpuddlelimit++; //restricts the original puddle so that it can only spawn 1 puddle when rain starts again
            StartCoroutine(wait(60));
        }
    }

    IEnumerator wait(int x) //resets the new puddle limit after a certain amount of time so that the original puddle can spawn a new puddle when it starts raining again
    {
        yield return new WaitForSeconds(x);
        newpuddlelimit = 0;
    }

    IEnumerator RainBuildUp()
    {   
        GameObject puddles = this.gameObject; //gets the puddle asset

        Vector3 rndm = new Vector3
            (weather.playerPosition.transform.position.x + Random.Range(-25,25),
            0.01f,
            weather.playerPosition.transform.position.z + Random.Range(-25,25)); //holds a random position on the ground that is close to the player

        xinitial += transform.localScale.x;

        if (xinitial > 3.5)
        {
            xdiff = Random.Range(-(this.xinitial - 0.1f), -0.1f);//If the previous puddle is too big, the next will always be smaller
            transform.localScale += new Vector3(xdiff, 0, xdiff);
        }

        else
        {
            xdiff = Random.Range(-(this.xinitial- 0.1f), 2f);//If the previous one is not too big, it will either increase or decrease the size of the next
            transform.localScale += new Vector3(xdiff, 0, xdiff);
        }

        yield return new WaitForSeconds(7);

        if (weather.stormParticleSystem.isPlaying)//makes sure it is raining before a new puddle can be spawned
            Instantiate(puddles, rndm, Quaternion.identity); //spawns a puddle on a random position on the map
    }

    IEnumerator DecreaseInSize()//the method that causes puddles to shrink if there is no rain
    {
        updatelimited = true;//stops update from calling this method when it is already active. If you want a more realistic looking shrink, set this to false

        yield return new WaitForSeconds(1);

        transform.localScale += new Vector3(-0.2f, 0, -0.2f);//puddle shrinks (If you set updatelimited to false ealier, set the transform to -0.01f)

        if (transform.localScale.x < 0.1)//deletes the puddles if they get small enough
        {
            Destroy(this.gameObject);//rip puddle, you will be missed
        }

        updatelimited = false;//allows update to call this method again
    }

    IEnumerator IncreaseInSize()//the method that causes puddles to grow if there is continued rain
    {
        updatelimited = true;//stops update from calling this method when it is already active. If you want a more realistic looking grow, set this to false

        yield return new WaitForSeconds(1);

        if (transform.localScale.x < 7)//sets a maximum size for puddles
        {
            transform.localScale += new Vector3(0.1f, 0f, 0.1f);//puddle grows (If you set updatelimited to false earlier, decrease the transform to 0.01f)
        }

       updatelimited = false;//allows update to call this method again
    }

    /* void OnParticleCollision(GameObject other)
    {
        Debug.Log("A particle has hit a puddle.");
        triggered = true;      
    } */

}
