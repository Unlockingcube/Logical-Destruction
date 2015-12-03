using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public lockDoor target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//quick version. update later
	void OnTriggerEnter(Collider Coll){
		target.Unlock ();
		Destroy (gameObject);
	}
}
