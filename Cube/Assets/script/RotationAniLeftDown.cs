using UnityEngine;
using System.Collections;

public class RotationAniLeftDown : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(Vector3.left * Time.deltaTime);
        this.transform.Rotate(Vector3.down * Time.deltaTime, Space.World);
    }
}
