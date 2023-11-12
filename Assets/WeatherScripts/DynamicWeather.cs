using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class DynamicWeather : MonoBehaviour
{	
	public GameObject weather;								//Weather gameobject transform
	public GameObject playerPosition;						//This game object is the player (fire truck) and the weather will follow it
	public float weatherHeight = 50f;						//Defines height of the weather above the player
    
	//public ParticleSystem sunCloudsParticleSystem;			//Creates a slot in inspector to assign our sun cloud system
	public ParticleSystem stormParticleSystem;				//Creates a slot in inspector to assign our storm system
	public ParticleSystem mistParticleSystem;				//Creates a slot in inspector to assign our mist system
	//public ParticleSystem overcastParticleSystem;			//Creates a slot in inspector to assign our overcast system
	public ParticleSystem snowParticleSystem; 				//Creates a slot in inspector to assign our snow system

	//private ParticleSystem.EmissionModule sunClouds;		//Defines naming convention for sun clouds emission module
	private ParticleSystem.EmissionModule storm; 			//Defines naming convention for storm emission module
	private ParticleSystem.EmissionModule mist;				//Defines naming convention for mist emission module
	//private ParticleSystem.EmissionModule overcast;			//Defines naming convention for overcast emission module
	private ParticleSystem.EmissionModule snow;				//Defines naming convention for snow emission module	

	public int rando;										//Sets a random number for picking weather
    public int weatheroccurances;                           //sets a number for the number of times the weather has been changed
	public float audioFadeTime = .25f;						//Defines rate for audio fade
	public AudioClip sunnyAudio;							//Creates a slot in inspector to assign our sunny audio clip
	public AudioClip stormAudio;							//Creates a slot in inspector to assign our stormy audio clip
	public AudioClip mistAudio;								//Creates a slot in inspector to assign our misty audio clip
	public AudioClip overcastAudio;							//Creates a slot in inspector to assign our overcast audio clip
	public AudioClip snowAudio;								//Creates a slot in inspector to assign our overcast audio clip

	public float lightDimTime = .1f;						//Defines rate for light dimming
	public float stormIntensity = 0f;						//Defines storm light intensity
	public float sunIntensity = 1f;							//Defines maxiumum light intensity
	public float mistIntensity = .5f;						//Defines mist intensity
	public float overcastIntesity = .25f;					//Defines overcast intensity
	public float snowIntesity = .75f;						//Defines snow intensity

	public Color sunFog;									//Creates slot in inspector to set sun fog color
	public Color stormFog;									//Creates slot in inspector to set storm fog color
	public Color mistFog;									//Creates slot in inspector to set mist fog color
	public Color overcastFog;								//Creates slot in inspector to set overcast fog color
	public Color snowFog; 									//Creates slot in inspector to set snow fog color
	public float fogChangeSpeed = .05f;						//Defines speed in which the fog will change

	public float frictionValue;								//Creates a value for friction to be set to depending on the weather.

	private WeatherStates _weatherState;					//Defines the name convetion of our weather state
	private int _switchWeather; 

	public Material moonlight;								//Dark Sky material for the skybox
	public Material spotlight;								//Light sky material for the skybox
	public Material snowLight;								//Snow/Overcast sky material for the skybox
	public Material mistSky;								//Mist sky material for the skybox

	public CloudScript cloudScriptu;						//Object that allows us to reference the cloud script

	public enum WeatherStates								//Defines all the states the weather can exist in
	{
		PickWeather, 
		SunnyWeather,
		StormyWeather,
		MistWeather,
		OvercastWeather,
		SnowWeather
	}
/*	void Awake()
	{
		sunClouds = sunCloudsParticleSystem.emission;		//sunClouds is equal to the sun clouds particle system
		storm = stormParticleSystem.emission;				//storm is equal to the storm particle system
		mist = mistParticleSystem.emission;					//mist is equal to the mist particle system
		overcast = overcastParticleSystem.emission;			//overcast is equal to the overcast particle system
		snow = snowParticleSystem.emission;					//snow is equal to the snow particle system

	} */
    // Start is called before the first frame update
    void Start()
    {  

		GameObject playerGameObject = GameObject.FindGameObjectWithTag ("Player"); //Find Player Game Object

        //GameObject weatherGameObject = GameObject.FindGameObjectWithTag("weather");	Find another game object with a "weather" tag also stops the entire weather system from working properly
        weatheroccurances = 0;
		RenderSettings.fog = true;								//Enable fog in render settings
		RenderSettings.fogMode = FogMode.ExponentialSquared;	//Set fog mode to exponential squared	
		RenderSettings.fogDensity = .003f;						//Set fog density

		//sunClouds = sunCloudsParticleSystem.emission;		//sunClouds is equal to the sun clouds particle system
		storm = stormParticleSystem.emission;				//storm is equal to the storm particle system
		mist = mistParticleSystem.emission;					//mist is equal to the mist particle system
		//overcast = overcastParticleSystem.emission;			//overcast is equal to the overcast particle system
		snow = snowParticleSystem.emission; //snow is equal to the snow particle system 
        //sunClouds.enabled = false;		//Disables our sun clouds particle system
        storm.enabled = false; 			//Disables our storm particle system
		mist.enabled = false;			//Disables our mist particle system
		//overcast.enabled = false;		//Disables our overcast particle system
		snow.enabled = false;			//Disables our snow particle system
        stormParticleSystem.Stop();
        snowParticleSystem.Stop();
        mistParticleSystem.Stop();
	//	StartCoroutine (WeatherSM ());						//Start the weather state machine

		_weatherState = DynamicWeather.WeatherStates.PickWeather; 
		PickWeather();
    }

    // Update is called once per frame
    void Update()
    {
		SwitchWeatherTimer();							//Updates our SwitchWeatherTimer Function	

		weather.transform.position = new Vector3(		//Weather position is equal to a new Vector3 which is the
			playerPosition.transform.position.x,		//player's position on the x-axis
			playerPosition.transform.position.y,		//player's position on the y-axis + the weather height
			playerPosition.transform.position.z);       //player's position on the z-axis

        if (Time.time > 60 * weatheroccurances)
        {
            Debug.Log("Weather changed successfully.");
            PickWeather();
        }

    }

	void SwitchWeatherTimer()
	{
	/*	Debug.Log ("SwitchWeatherTimer");

		switchWeatherTimerF -= Time.deltaTime;			//Decreases weather time by real time

		if (switchWeatherTimerF < 0)					//If the switch timer is less than zero
			switchWeatherTimerF = 0;					//Then switch timer is equal to zero

		if (switchWeatherTimerF > 0)					//If switch time greater than zero
			return;										//Then do nothing

		if (switchWeatherTimerF == 0)					//If the switch timer is equal to zero
			_weatherState = DynamicWeather.WeatherStates.PickWeather; 			//Then switch our case block to pick weather

		switchWeatherTimerF = resetWeatherTimer;		//Switch time is equal to the reset time
		*/
	}
/*	IEnumerator WeatherSM() //Weather State Machine, sets WeatherState to pick weather
	{
		WeatherStates.PickWeather;
		PickWeather ();

	}
	*/
    
	void PickWeather() 							//Swaps _weatherState to one of the 4 actual weathers
	{
        _switchWeather = Random.Range(0, 5);	//_switchWeather has the range of 0 through 4.
        weatheroccurances++;

		if (_switchWeather == 0)
		{
			_weatherState = DynamicWeather.WeatherStates.SunnyWeather; //_weatherState becomes Sunny

            stormParticleSystem.Stop();//stops everything else
            snowParticleSystem.Stop();
            mistParticleSystem.Stop();

            SunnyWeather();//calls the method
        }

		if (_switchWeather == 1) 
		{
			_weatherState = DynamicWeather.WeatherStates.StormyWeather; //_weatherState becomes stormy-y

            snowParticleSystem.Stop();//stops everything else
            mistParticleSystem.Stop();
            StormyWeather();//calls the method
        }

		if (_switchWeather == 2) 
		{
			_weatherState = DynamicWeather.WeatherStates.MistWeather;   //_weatherState becomes Misty

            stormParticleSystem.Stop();//stops everything else
            snowParticleSystem.Stop();

            MistWeather();//calls the method
		}

		if (_switchWeather == 3)
		{
			_weatherState = DynamicWeather.WeatherStates.OvercastWeather; //_weatherState becomes Overcast

            stormParticleSystem.Stop();//stops everything else
            snowParticleSystem.Stop();
            mistParticleSystem.Stop();

            OvercastWeather();//calls the method
		}
		if (_switchWeather == 4) 
		{
			_weatherState = DynamicWeather.WeatherStates.SnowWeather; //_weatherState becomes Snowy

            stormParticleSystem.Stop();//stops everything else
            mistParticleSystem.Stop();

            SnowWeather();//calls the method
		}

    }


	void SunnyWeather()
	{
		Debug.Log ("SunnyWeather");

		//sunClouds.enabled = true;												//enables sun particle system

		/*
		if (GetComponent<Light> ().intensity > sunIntensity)				//If the light intensity is greater than sun intensity
		{
			GetComponent<Light> ().intensity -= Time.deltaTime * lightDimTime;	//Then subtract the intensity by our light dim time 
		}

		if (GetComponent<Light> ().intensity < stormIntensity)				//If the light intensity is greater than sun intensity
		{
			GetComponent<Light> ().intensity += Time.deltaTime * lightDimTime; 	//Then add the intensity by our light dim time
		}
		*/
		Color currentFogColor = RenderSettings.fogColor; 					//Current is equal to the render setting fog color 

		RenderSettings.fogColor = Color.Lerp (currentFogColor, sunFog, fogChangeSpeed * Time.deltaTime); 	//Render setting fog equals (change from current to sun fog by fog change speed)

		RenderSettings.skybox = spotlight; 									//Changes the skybox to daylight

		cloudScriptu.coverage = .5f;	//Setting the coverage of the clouds (how much there is) to enough

	}

	void StormyWeather()
	{
		Debug.Log ("StormyWeather");
        stormParticleSystem.Play();
		storm.enabled = true;													//enables storm particle system
		/*
		if (GetComponent<Light> ().intensity > stormIntensity)				//If the light intensity is greater than storm intensity	
		{
			GetComponent<Light> ().intensity -= Time.deltaTime * lightDimTime;	//Then subtract the intensity by our light dim time					
		}

		if (GetComponent<Light> ().intensity < stormIntensity)				//If the light intensity is less than storm intensity 
		{			
			GetComponent<Light> ().intensity += Time.deltaTime * lightDimTime;	//Then add ihe intensity by our light dim time
		}
		*/
		Color currentFogColor = RenderSettings.fogColor; 					//Current is equal to the render setting fog color 

		RenderSettings.fogColor = Color.Lerp (currentFogColor, stormFog, fogChangeSpeed * Time.deltaTime); 	//Render setting fog equals (change from current to storm fog by fog change speed)

		RenderSettings.skybox = moonlight;									//Changes the skybox to night sky
		cloudScriptu.coverage = 2f;	//Setting the coverage of the clouds (how much there is) to enough
        
	}





    void MistWeather()
	{
		Debug.Log ("MistWeather");
        mistParticleSystem.Play();
		mist.enabled = true;													//enables mist particle system
		/*
		if(GetComponent<Light> ().intensity > mistIntensity)				//If the light intesnity is greater than the mist intensity
		{
			GetComponent<Light> ().intensity -= Time.deltaTime * lightDimTime;	//Then subtract the intensity by our light dim time
		}

		if (GetComponent<Light> ().intensity < mistIntensity)				//If the light intesnity is less than the mist intensity  
		{
			GetComponent<Light> ().intensity += Time.deltaTime * lightDimTime;	//Then add the intensity by our light dim time
		}
		*/
		Color currentFogColor = RenderSettings.fogColor; 					//Current is equal to the render setting fog color 

		RenderSettings.fogColor = Color.Lerp (currentFogColor, mistFog, fogChangeSpeed * Time.deltaTime); 	//Render setting fog equals (change from current to mist fog by fog change speed)
	
		RenderSettings.skybox = mistSky; 									//Changes the skybox to daylight
		 
		cloudScriptu.coverage = 1.6f;									//Setting the coverage of the clouds (how much there is) to enough
	}
	void OvercastWeather()
	{
		Debug.Log ("OvercastWeather");

		//overcast.enabled = true;												//enable overcast particle system
		/*
		if(GetComponent<Light> ().intensity > overcastIntesity)				//If the light intensity is greater than the overcast intensity
		{
			GetComponent<Light> ().intensity -= Time.deltaTime * lightDimTime;	//Then subtract the intensity by our light dim time
		}

		if (GetComponent<Light> ().intensity < overcastIntesity)			//If the light intensity is less than the overcast intensity
		{
			GetComponent<Light> ().intensity += Time.deltaTime * lightDimTime;	//Then add the intensity by our light dim time		
		}
		*/
		Color currentFogColor = RenderSettings.fogColor; 					//Current is equal to the render setting fog color 

		RenderSettings.fogColor = Color.Lerp (currentFogColor, overcastFog, fogChangeSpeed * Time.deltaTime); 	//Render setting fog equals (change from current to overcast fog by fog change speed)

		RenderSettings.skybox = snowLight;									//Changes the skybox to overcast sky

		cloudScriptu.coverage = 1.8f;									//Setting the coverage of the clouds (how much there is) to enough
	}

	void SnowWeather()
	{
		Debug.Log ("SnowWeather");
        snowParticleSystem.Play();
		snow.enabled = true;													//enable snow particle system
		/*
		if(GetComponent<Light> ().intensity > snowIntesity)			//If the light intensity is greater than the snow intensity
		{
			GetComponent<Light> ().intensity -= Time.deltaTime * lightDimTime;	//Then subtract the intensity by our light dim time
		}

		if(GetComponent<Light> ().intensity < snowIntesity)			//If the light intensity is less than the snow intensity
		{
			GetComponent<Light> ().intensity += Time.deltaTime * lightDimTime; 	//Then add the intensity by our light dim time
		}
		*/
		Color currentFogColor = RenderSettings.fogColor; 					//Current is equal to the render setting fog color 

		RenderSettings.fogColor = Color.Lerp (currentFogColor, snowFog, fogChangeSpeed * Time.deltaTime); 	//Render setting fog equals (change from current to snow fog by fog change speed)

		RenderSettings.skybox = snowLight;									//Changes the skybox to overcast sky	

		cloudScriptu.coverage = 1.8f;	//Setting the coverage of the clouds (how much there is) to enough
        
	}


}
