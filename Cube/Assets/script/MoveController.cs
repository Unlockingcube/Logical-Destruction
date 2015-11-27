using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    public float Speed;
	public float acc;
    public float jumpForce;
    public enum Direction { FORWARD, DOWN, LEFT, RIGHT, STOP };
    public Direction dir = Direction.DOWN;
    public bool control = true;
	public bool onGround=true;
	[HideInInspector]public Vector3 groundNormal;
    public float xTurn;
    public float inputScaler=1f;
    public CameraControl playerCamera;
	public float ground_distance;
	private Rigidbody player_body;
    [HideInInspector]public bool immediateStop=true;
	[HideInInspector]public float stopModifier = 2f;
	[HideInInspector]public float speedModifier = 1.0f;
	public Vector3 move;
	private bool jump = false;
    // Use this for initialization
    void Start()
    {
		player_body = GetComponent<Rigidbody> ();
        
    }

    // Update is called once per frame
    /// <summary>
    /// Movement Direction
    /// </summary>
	void Update () {
		//Debug.Log ("WTF");
		jump = Input.GetKeyDown (KeyCode.Space);
	}
    void FixedUpdate()
    {
		if (immediateStop) {
			stopModifier = 2f;
		} else {
			stopModifier = 0.5f;
		}
        //Cursor.lockState = CursorLockMode.Locked;
		//Debug.Log ("WTF");
        if (control)

        {
			//Debug.Log ("WTF");
			CheckGround();
            //
            //Turn Controller
            //
            if(playerCamera.mouseLock)
                 xTurn += Input.GetAxis("Mouse X") * inputScaler;

            Quaternion direction = Quaternion.Euler(0f, xTurn, 0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, direction, .5f);
            //
            //Directional Controller
            //
			move = transform.InverseTransformDirection(player_body.velocity);
			//this step converts the velocity into local space of the cube from world space
			//change to axis later
            if (Input.GetKey(KeyCode.A))
            {
                dir = Direction.LEFT;   
				if(move.x > -Speed*speedModifier)
					Mathf.Max(move.x -= acc * Time.fixedDeltaTime,-Speed);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir = Direction.RIGHT;
				if(move.x < Speed*speedModifier)
					Mathf.Min(move.x += acc*Time.fixedDeltaTime,Speed);

            }else{
				if(move.x < 0)
					move.x=Mathf.Min(move.x += acc*stopModifier *Time.fixedDeltaTime,0f);
				else if(move.x > 0)
					move.x=Mathf.Max(move.x += -acc*stopModifier*Time.fixedDeltaTime,0f);
			}
            if (Input.GetKey(KeyCode.S))
            {
                dir = Direction.DOWN;

				if(move.z > -Speed*speedModifier)
					Mathf.Max(move.z -= acc*Time.fixedDeltaTime,-Speed);

            }
            else if (Input.GetKey(KeyCode.W))
            {
                dir = Direction.FORWARD;
				if(move.z < Speed*speedModifier)
					Mathf.Min(move.z += acc*Time.fixedDeltaTime,Speed);

			}else{
				if(move.z < 0)
					move.z=Mathf.Min(move.z += acc*stopModifier *Time.fixedDeltaTime,0f);
				else if(move.z > 0)
					move.z=Mathf.Max(move.z += -acc*stopModifier *Time.fixedDeltaTime,0f);
			}
			//normalize all directions
			if(Vector3.Magnitude(move) >= Speed*speedModifier){
				if(onGround){
					move.Normalize();
					move = move * Speed*speedModifier;
				}else{

				}
			}
			//move = Quaternion.AngleAxis(xTurn, Vector3.up) * move;
			move = transform.TransformDirection(move);
			if(onGround)
				move = Vector3.ProjectOnPlane(move,groundNormal);
			else
				move.y = player_body.velocity.y;
			player_body.velocity = move;

			if(jump)
				JumpControl();	
        }
    }
	void JumpControl(){
		if (onGround && GetComponent<PowerController>().power!=PowerController.Power.EARTH)
		{
			player_body.velocity=new Vector3(player_body.velocity.x, jumpForce, player_body.velocity.z);
			onGround = false;
		}
	}
	void CheckGround(){
		RaycastHit hitInfo;
		if (Physics.Raycast (transform.position, Vector3.down, out hitInfo, ground_distance)) {
			onGround = true;
			groundNormal = hitInfo.normal;
			if(GetComponent<PowerController>().power!=PowerController.Power.EARTH)
				player_body.useGravity = false;
		} else {
			onGround = false;
			groundNormal = Vector3.up;
			player_body.useGravity = true;
		}
	}

}
