using UnityEngine;
using System.Collections;

public class GrowingControler : MonoBehaviour {
    public int GrowLimiter = 60;  
    int UpdateCounter = 0;
    bool Grow = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCounter++;

        if (UpdateCounter == GrowLimiter)
        {
            Grow = !Grow;
            UpdateCounter = 0;
        }

        if (Grow)
        {
            transform.localScale += new Vector3(.01f, .01f, .01f);

        }
        else
            transform.localScale += new Vector3(-.01f, -.01f, -.01f);
    }
}
