using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverExit : MonoBehaviour {
	GameObject gm;
	bool gmActive;

//	public void Start(){
//		GameObject.Find ("buttonBackToMain").GetComponent <enabled>()= true;
//	}

	public void goBack ()
	{
		SceneManager.LoadScene(0);
		/*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); /*Here, BuildIndex can be accessed from Unity by going to 
		FILE --> BUILDSETTINGS. From there, you can add other scenes from previous years or ones that you have made*/
	}
}
