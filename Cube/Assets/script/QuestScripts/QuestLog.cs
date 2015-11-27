using UnityEngine;
using System.Collections;

public class QuestLog : MonoBehaviour {
    public string[] questLog = new string[1] { "Welcome: \n F for Ice \n V for Fire \n G For earth \n R for lightning" };
	public int currentQuest = 0;
	static public Quest[] questLog2 = new Quest[10];
	static public int filledSpace = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/10, Screen.height/10, 100, 100), questLog[currentQuest]);
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 10, 100, 100), "Teleports: " + PowerController.pc_lightningAmmo);
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 5, 100, 100)," " +GameObject.Find("Player").GetComponent<PowerController>().power);
    	if(questLog2[currentQuest]!=null)
			GUI.Label(new Rect(Screen.width/3, Screen.height/10, 100, 100), questLog2[currentQuest].QuestToString());
	}
	void Update () {
	
	}
	void updateCurrentQuest(int target){
		currentQuest = target;
	}
	static public void AddQuest(Quest quest){
		questLog2 [filledSpace] = quest;
		filledSpace++;
	}
	static public void AddQuest(int target,Quest quest){
		questLog2 [target] = quest;
	}
	static public bool AddQuestStep(string target,QuestStep questStep){
		int i = 0;
		while (i < filledSpace &&  !questLog2[i].questChain[questLog2[i].currentQuest].text.Equals(target)){
			i++;
		}
		if (i < questLog2.Length) {
			questLog2 [i].AppendQuestStep (questStep);
			return true;
		}
		else 
			return false;
	}
	static public bool IncrementQuest(string target){
		Debug.Log ("INCREMENTING QUEST" + target);
		int i = 0;
		while(i < filledSpace){
			if(questLog2[i] != null)
				if(!questLog2[i].QuestName.Equals(target))
					i++;
				else
					break;
		}
		if (questLog2 [i] != null) {
			questLog2 [i].incrementQuest ();
			Debug.Log ("QUESTLOG:Increment Quest Returned True");
			return true;

		} else {
			Debug.Log ("QUESTLOG:Increment Quest Returned false");
			return false;
		}

	}
}
