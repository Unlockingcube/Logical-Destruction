using UnityEngine;
using System.Collections;

public class lockDoor : MonoBehaviour {
	public int Locks = 2;
	public string questTarget = "";
	public int target = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Unlock(){
		Locks--;
		if (Locks == 0) {
			QuestLog.SetQuestStep(questTarget,target);
			gameObject.GetComponent<MeshCollider> ().enabled = false;
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			gameObject.GetComponentInChildren<BoxCollider>().enabled = true;
		}
	}
}
