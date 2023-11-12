using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 FOR THE MAIN MENU SCENE: This GameObject this script is attatched to ("MainMenu") should be enabled, while the gameobjects "optionsMenu" and "creditsMenu" should be disabled.
 You can change this when testing out features (such as adding your class's students' names to the credits), but be sure to change it back to the way I had it when done. 
 */

public class MainMenuScript : MonoBehaviour {

public GameObject bkg; //This GameObject should be the background of the main menu

	public void Start(){
		restoreBkg ();
	}

	//When the start button is pressed, this script changes the scene from the main menu screen to the main simulation scene.
	public void StartSim ()
	{
		SceneManager.LoadScene(1);
		/*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); /*Here, BuildIndex can be accessed from Unity by going to 
		FILE --> BUILDSETTINGS. From there, you can add other scenes from previous years or ones that you have made*/
	}

	//When the exit button is pressed, this script exits the Simulation.
	public void EndSim(){
		Application.Quit ();
	}

	//This changes the background when a sub-Menu is open
	public void changeBkg (){
		bkg.GetComponent<Renderer> ().material.SetColor ("_Color",new Color(.2f,.2f,.2f));
		//SetColor ("_Color",Color.gray);   //Ending with this gives new Color(.5f, .5f, .5f, 1f); so the above is a bit darker
	}

	//This changes the background when a sub-Menu is closed and the Main Menu is opened
	public void restoreBkg (){
		bkg.GetComponent<Renderer> ().material.SetColor ("_Color",new Color(1f,1f,1f));
		//SetColor ("_Color",Color.white);   //Ending with this gives same result as above
	}

	//This script resets the position of the credits when the user leaves the credits screen
//	public void resetcredits(){
//		GameObject.Find("ScrollableCredits").GetComponent<creditScript>().roll = false;
//	}
		
}
