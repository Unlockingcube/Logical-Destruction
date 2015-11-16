using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour
{

    private bool paused = false;

    public GUISkin mySkin;

    void Start()
    {
        paused = false;
        //you need this to be stated so your game does not start paused. 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                OnPause();
            }
            else
            {
                OutPause();
            }
        }
    }

    void OnPause()
    {
        Time.timeScale = 0;
        paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("IN PAUSE");
    }

    void OutPause()
    {
        Time.timeScale = 1;
        paused = false;
        Debug.Log("NOT IN PAUSE");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnGUI()
    {

        if (paused == true)
        {
            Cursor.visible = true;
            GUI.Box(new Rect(250, Screen.height - 200, 300, 400), "CIGARETTES BREAK");//"Cigarettes break"
            if (GUI.Button(new Rect(350, Screen.height - 175, 85, 50), "RESUME"))
            {
                OutPause();
                Debug.Log("This Should've Unpaused,man. WTF I Quit");
            }
            if (GUI.Button(new Rect(350, Screen.height - 100, 85, 50), "GIVE UP"))
            {
                Application.Quit();
            }

        }
    }

}
