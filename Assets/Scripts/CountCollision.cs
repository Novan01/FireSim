using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountCollision : MonoBehaviour
{
    public static float counter = 0f; //collision at start is zero
    //public Text myText;
    // Start is called before the first frame update
    void Start()
    {

        //Text myText = new Text();
        //myText = GetComponent<Text>(); //makes a text variable in order to display text
    }
    void OnTriggerEnter(Collider other) //this is saying that when the truck collides with an object that is labeled as a trigger and has an obs tag, counter will increment by one
    {
        if (other.CompareTag("obs"))
        {
            counter += 1f;
        }
        else if (other.CompareTag("curb"))
        {
            counter += 0.5f;  //increment the counter by half of one when collide with curb since driving over the curb will count as 1 collision instead of two
        }
    }
    private void OnCollisionEnter(Collision collision) //this is saying when truck collides with things that may not be objects, but truck still collides with it, the count will increment by one
    {
        counter += 1f;
    }
    // Update is called once per frame
    void Update()
    {
        //myText.text = "Collisions: " + counter; //displays the text on screen with collision count
        if (Input.GetKeyDown(KeyCode.R))
        {
            counter = 0f;
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(745, 10, 75, 60), "Collision");
        GUI.Label(new Rect(760, 40, 80, 20), (int)counter + " Hits");
    }

}
