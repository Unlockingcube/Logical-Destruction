using UnityEngine;
using System.Collections;

public class QuestObject : MonoBehaviour {
	public enum ObjectType{QUEST,DYNAMICSTEP,INCREMENT,QUESTTARGET};
	public ObjectType whatami;
	public bool onStart = false;
	public string questTarget = "";
	public int target = 0;
	public QuestStep questStep;
	public Quest quest;
	// Use this for initialization
	void Start () {
		if (onStart)
			updateQuestLog ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		updateQuestLog ();
	}
	void updateQuestLog(){
		bool kill = true;
		switch(whatami){
		case ObjectType.QUEST:
			QuestLog.AddQuest(quest);
			break;
		case ObjectType.DYNAMICSTEP:
			kill = QuestLog.AddQuestStep(questTarget,questStep);
			break;
		case ObjectType.INCREMENT:
			kill = QuestLog.IncrementQuest(questTarget);
			Debug.Log("GAMEOBJECT:Increment Done");
			break;
		case ObjectType.QUESTTARGET:
			break;
		}
		if (kill) {
			Debug.Log ("Removing Object visibility and collider");
			gameObject.GetComponent<BoxCollider> ().enabled = false;
			gameObject.GetComponent<MeshRenderer> ().enabled = false;
		} else {
			Debug.Log ("not doing anything");
		}

	}
}
