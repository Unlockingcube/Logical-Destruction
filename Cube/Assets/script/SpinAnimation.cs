using UnityEngine;
using System.Collections;

public class SpinAnimation : MonoBehaviour {
    double time = 0.00;
    bool Flip = false;
    public int FlipTime = 1;

	// Use this for initialization
	void Start () {
        time = Time.deltaTime;

    }
	
	// Update is called once per frame
	void Update () {
       
        time += Time.deltaTime ;
        if(!Flip && time>FlipTime)
        {
            Flip = true;
            time = 0;
        }
        if(Flip && time > FlipTime)
        {
            Flip = false;
            time = 0;
        }

        if (Flip)
        {
            this.transform.Rotate(Vector3.left * Time.deltaTime/2);
            this.transform.Rotate(Vector3.up * Time.deltaTime/2);
        }
        else
        {
            this.transform.Rotate(Vector3.right * Time.deltaTime/2);
            this.transform.Rotate(Vector3.down * Time.deltaTime/2);
        }
    }
}
