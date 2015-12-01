using UnityEngine;
using System.Collections;

public class KillScript : MonoBehaviour {
    Vector3 startPos;

	// Use this for initialization
	void Start () {

        startPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("onTrigerEntering...");
        if(col.gameObject.tag == "Kill")
        {
            Debug.Log("should respawn!");
            this.transform.position = startPos;
        }
    }
}
