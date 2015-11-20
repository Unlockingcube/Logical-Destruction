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
    void OnTriggerEnter3D(Collider col)
    {
        if(col.gameObject.tag == "Kill")
        {
            this.transform.position = startPos;
        }
    }
}
