using UnityEngine;
using System.Collections;

public class RotationAni : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
       this.transform.Rotate(Vector3.right * Time.deltaTime);
       this.transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
	
	}
}
