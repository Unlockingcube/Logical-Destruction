using UnityEngine;
using System.Collections;

public class QuestLog : MonoBehaviour {
    public string[] questLog = new string[1] { "F for Ice \n G For Earth \n R for lightning" };
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
	//find the quest in the questLog requested
	static int getQuest(string target){
		Debug.Log("Finding QUEST!");
		int i = 0;
		while (i < filledSpace &&  !questLog2[i].QuestName.Equals(target)){
			i++;
		}
		Debug.Log("Finding QUEST!");
		if(questLog2[i] == null)
			i = -1;
		return i;
	}
	static public void AddQuest(Quest quest){
		questLog2 [filledSpace] = quest;
		filledSpace++;
	}
	static public void AddQuest(int target,Quest quest){
		questLog2 [target] = quest;
	}
	static public bool AddQuestStep(string target,QuestStep questStep){
		int i = getQuest (target);
		if (i < questLog2.Length && i>-1) {
			questLog2 [i].AppendQuestStep (questStep);
			return true;
		}
		else 
			return false;
	}
	static public bool SetQuestStep(string target,int number){
		Debug.Log ("INCREMENTING QUEST" + target);
		int i = getQuest (target);
		if (i >= -1 && i < questLog2.Length && questLog2 [i] != null) {
			questLog2[i].currentQuest = number;
			return true;
		} else {
			return false;
		}
	}
	static public bool IncrementQuest(string target){
		Debug.Log ("INCREMENTING QUEST" + target);
		int i = getQuest (target);
		if (i >= -1 && i < questLog2.Length && questLog2 [i] != null) {
			questLog2 [i].incrementQuest ();
			Debug.Log ("QUESTLOG:Increment Quest Returned True");
			return true;

		} else {
			Debug.Log ("QUESTLOG:Increment Quest Returned false");
			return false;
		}

	}
}
