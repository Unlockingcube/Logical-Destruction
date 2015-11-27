using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour{
	public string QuestName;
	public bool dynamic = false;
	public int length;
	//Quest are intended to either be pre completed
	//or added onto dynamically
	//
	//dynamic quest will use appendQuestStep
	//static quest will simply increment the currentQuest
	//
	public int currentQuest = 0;
	public QuestStep[] questChain = null;
	public int nextFree = 0;
	void Start () {
		length = questChain.GetLength(0);
	}
	public void MoveToQuestStep(int target){
		currentQuest = target;
	}
	public void incrementQuest(){
		currentQuest++;
	}
	//most likely never used
	public void AddQuestStep(QuestStep target,int location){
		questChain [location] = target;
	}
	//use this to add quest
	public void AppendQuestStep(QuestStep target){
		questChain [nextFree] = target;
		nextFree ++;
		incrementQuest ();
	}
	public string QuestToString(){
		return questChain [currentQuest].text;
	}
}