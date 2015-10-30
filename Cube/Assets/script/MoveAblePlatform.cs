using UnityEngine;
using System.Collections;

public class MoveAblePlatform : MonoBehaviour {
	public enum Platform {STANDARD,UPWARDS,HORIZONTAL,NORESET};
	public Platform platform;
	public Vector3 moveVector = new Vector3(0f,-2f,0f);
	public float moveSpeed = .5f;
	[HideInInspector]public bool move = false;
	[HideInInspector]public bool canMove =true;
	private Vector3 origin;
	//public float debugC, debugT;

	// Use this for initialization
	void Start () {
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){
		//canMove = (transform.position.y > (origin.y + moveVector.y));
		//debugC = (transform.position - origin).magnitude;
		//debugT = (moveVector).magnitude;
		canMove = (transform.position - origin).magnitude < (moveVector).magnitude;
		switch (platform){
			case Platform.STANDARD:
				StandardMove(false);
				break;
			case Platform.HORIZONTAL:
				break;
			case Platform.NORESET:
				StandardMove(true);
				break;
			case Platform.UPWARDS:
				break;
		}
	}
	void StandardMove(bool off){
		if (move) {
			if (canMove){
				Vector3 newtransform = origin;
				newtransform.y = moveVector.y;
				transform.position = Vector3.Lerp(transform.position,newtransform,moveSpeed*Time.deltaTime);
			}
			move = false;
		} else if (transform.position.y < origin.y && !off) {
			transform.position = Vector3.Lerp(transform.position,origin,moveSpeed*Time.deltaTime);
		}

	}
}
