
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.Events; 
using UnityEngine.EventSystems;

public class highlight : MonoBehaviour
{
    public int gear;
    // Start is called before the first frame update
    void Start()
    {
        gear = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetButton("AButton"))
        {
            gear = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha2) || Input.GetButton("BButton"))
        {
            gear = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha3) || Input.GetButton("XButton"))
        {
            gear = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha4) || Input.GetButton("YButton"))
        {
            gear = 4;
        }

        // switch(gear)
        // {

        // }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
        GUI.Box(new Rect(710, 385, 100, 50), "Gear");
        GUI.Label(new Rect(715, 400, 100, 100), "<size=30><color=red>P</color><color=white>RND</color></size>", style);

        switch (gear)
        {
            case 1:
                GUI.Label(new Rect(715, 400, 100,100),"<size=30><color=red>P</color><color=white>RND</color></size>", style);
                break;
            case 2:
                GUI.Label(new Rect(715, 400, 100, 100), "<size=30><color=white>P</color><color=red>R</color><color=white>ND</color></size>", style);
                break;
            case 3:
                GUI.Label(new Rect(715, 400, 100, 100), "<size=30><color=white>PR</color><color=red>N</color><color=white>D</color></size>", style);
                break;
            case 4:
                GUI.Label(new Rect(715, 400, 100, 100), "<size=30><color=white>PRN</color><color=red>D</color></size>", style);
                break;
            default:
                break;

        }

    }
}
