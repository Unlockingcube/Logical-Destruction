using UnityEngine;
using System.Collections;

public class RespawnController : MonoBehaviour {
	static public int checkpoint = 0;
	public GameObject[] respawnPoints;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	public void Respawn(){
		gameObject.transform.position = respawnPoints [checkpoint].transform.position;
		gameObject.transform.rotation = respawnPoints [checkpoint].transform.rotation;
		gameObject.GetComponent<MoveController> ().xTurn = respawnPoints [checkpoint].transform.rotation.y;
		StartCoroutine(gameObject.GetComponent<MoveController> ().disable ());
	}
	public static void UpdateCheckpoint(int number){
		checkpoint = number;
	}
}
