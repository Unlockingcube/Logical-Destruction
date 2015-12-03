using UnityEngine;
using System.Collections;

public class PowerUpRespawn : MonoBehaviour {
	public string childName = "";
	public Vector3 pos;
	public GameObject child;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.FindChild (childName) == null) {
			GameObject newChild = Instantiate(child,pos,Quaternion.identity) as GameObject;
			newChild.transform.parent = gameObject.transform;
			newChild.transform.name = childName;
		}
	}
}
