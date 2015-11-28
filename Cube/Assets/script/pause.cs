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
            if (GUI.Button(new Rect(350, Screen.height - 175, 85, 50), "Here we go!"))
            {
                togglePause();
            }
            if (GUI.Button(new Rect(350, Screen.height - 100, 85, 50), "Im just done!"))
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
