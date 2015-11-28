using UnityEngine;
using System.Collections;

public class SpikeScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.name.Equals("Player")){
			collision.gameObject.GetComponent<RespawnController>().Respawn();
		}
	}
}
