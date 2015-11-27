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

			break;
		case ObjectType.QUESTTARGET:
			break;
		}
		Debug.Log (kill);
		if (kill) {
			gameObject.GetComponent<BoxCollider>().enabled = false;
			gameObject.GetComponent<MeshRenderer>().enabled = false;
		}

	}
}
