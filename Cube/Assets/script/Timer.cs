using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	float time = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
	}
	void OnGUI(){
		GUI.Box (new Rect (10, 10, 50, 20), "" + time.ToString ("0.0"));
	}
}
