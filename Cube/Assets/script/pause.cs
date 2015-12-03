using UnityEngine;
using System.Collections;
using UnityEditor;
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
        if (Input.GetKey(KeyCode.K))
        {
            //   Debug.Log("TEST K"+ Application.loadedLevelName);
            if (Application.loadedLevelName.Equals("scene1"))
            {
                GUI.Label(new Rect(500, 260f, Screen.height, Screen.width),
                    "Who am I, what has transpired before today. What has become of who I once was? Will i find my answers in this beautiful place or will i find death? ");
            }
            if (Application.loadedLevelName.Equals("scene2"))
            {
                GUI.Label(new Rect(500, 260f, Screen.height, Screen.width),
                    "What is this? I just grabed some cubes and now im here ? why .. this place is dessolate and lacking any color.. . why.. wait .. i just remebered my name! it was cuubee? no Unlockingcube! Thats it! maybe these cubes hold the key to my memory! i must find more! ");
            }
            if (Application.loadedLevelName.Equals("scene3"))
            {
                Debug.Log("TEST K" + Application.loadedLevelName);
                GUI.Label(new Rect(500, 260f, Screen.height, Screen.width), "For some reason this feels like the end, and yet i have only just learned my name, what else will i find in the future, maby I had firends, or family. I don't know, but i will find you mark my words!");
            }
            if (Application.loadedLevelName.Equals("scene5"))
            {
                GUI.Label(new Rect(500, 260f, Screen.height, Screen.width),
                    "For some reason this place feels like home, I dont know why? but i feel at home here, theres nothing here for me but fun!");
            }
        }
        if (Time.timeScale == 0)
        {
            Cursor.visible = true;
            GUI.Box(new Rect(300f, 150f,Screen.width/2, Screen.height/2), "Whoah bro dis is tuff!");
            GUI.Label(new Rect(500,180f, Screen.height,Screen.width), "Press E to Resume");
            if(Input.GetKeyDown(KeyCode.E))
            {
                togglePause();
            }
            GUI.Label(new Rect(500, 200f, Screen.height, Screen.width), "Press M to Return to menu");
            if (Input.GetKeyDown(KeyCode.M))
            {
                Application.LoadLevel("MainMenu");
            }
            GUI.Label(new Rect(500, 220f, Screen.height, Screen.width), "Press P to Quit");
            if(Input.GetKeyDown(KeyCode.P))
            {
                Application.Quit();
            }
          
            GUI.Label(new Rect(500, 240f, Screen.height, Screen.width), "Press N to Restart");
            if (Input.GetKeyDown(KeyCode.N))
            {
                Application.LoadLevel(Application.loadedLevel);
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
