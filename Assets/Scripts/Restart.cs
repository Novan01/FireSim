using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{  
    public Scene oldScene;
    public Button restartButton;
    public void RestartScene()
     {
        
            SceneManager.LoadScene(oldScene.name); //reloads the scene that was the beginning scene

    } 
    // Start is called before the first frame update
 
    public void Start()
    {
        oldScene = SceneManager.GetActiveScene(); //creates a reference to the starting scene so it can be recalled when the restart button is pressed
    }

    // Update is called once per frame
    public void Update()
    {
       if(Input.GetKeyDown(KeyCode.R)) //when the R key is pressed, the script activates the invisible button on the canvas which will activate the RestartScene method
        {
            restartButton.onClick.Invoke();
        }
    }
}
