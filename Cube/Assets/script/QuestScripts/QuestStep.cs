using UnityEngine;
using System.Collections;

public class QuestStep : MonoBehaviour{
	//This class is just a Struct by Unity doesn't work well with structs 
	//
	public string text ="";
	public int stepNumber = 0;
	//public QuestStep next = null;
	public QuestStep(string description, int number){
		this.text = description;
		this.stepNumber = number;
		//this.next = next;
	}
}