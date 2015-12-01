using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour
{

    private bool paused;

    public GUISkin mySkin;

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = togglePause();
        }
    }
    

    void OnGUI()
    {

        if (Time.timeScale == 0)
        {
            Cursor.visible = true;
            GUI.Box(new Rect(250, Screen.height - 200, 300, 400), "Whoah bro dis is tuff!");
            GUI.Label(new Rect(350, Screen.height - 175, 85, 50), "Press E to Resume");
            if(Input.GetKeyDown(KeyCode.E))
            {
                togglePause();
            }
            GUI.Label(new Rect(350, Screen.height - 100, 85, 50), "Press P to Quit");
            if(Input.GetKeyDown(KeyCode.P))
            {
                Application.Quit();
            }

        }
    }
    bool togglePause()
    {
       if (Time.timeScale == 0)
       {
       //    Screen.lockCursor = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;
           return (false);
       }
       else
       {
            Cursor.lockState = CursorLockMode.Locked;
       //     Screen.lockCursor = false;
            Time.timeScale = 0;
            return (true);
       }
    }

}
