using UnityEngine;
using System.Collections;

public class RespawnCheckpoint : MonoBehaviour {
	public int number;
	public bool OneTime = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(other.name.Equals("Player")){
			RespawnController.UpdateCheckpoint(number);
			OneTime = false;
			gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}
}
