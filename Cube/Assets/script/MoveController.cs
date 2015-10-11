using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    public float maxSpeed;
    public float acc;
    public float jumpForce;
    public enum Direction { FORWARD, DOWN, LEFT, RIGHT, STOP };
    public Direction dir = Direction.DOWN;
    public bool control = true;
    private float nx, nz, ny;
    public bool jumpControl = true;
    public float xTurn;
    public float inputScaler=1f;
    public CameraControl playerCamera;
    public bool speedLimte = false;
    private Vector3 mc_localRotation;
    [HideInInspector]
    public bool immediateStop=true;
    // Use this for initialization
    void Start()
    {
        mc_localRotation = new Vector3(0f,0f,0f);
        nx = 0;
        ny = 0;
        
    }

    // Update is called once per frame
    /// <summary>
    /// Movement Direction
    /// </summary>
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        if (control)
        {
            if (!Input.GetMouseButton(0))
            {
                //can add a componet here for lightning
                if(playerCamera.mouseLock)
                    xTurn += Input.GetAxis("Mouse X") * inputScaler;
            }
            mc_localRotation.y = xTurn;
            Vector3 target = new Vector3(0f, 0f, 0f);
            nx = 0f;
            nz = 0;
            if (Input.GetKey(KeyCode.A))
            {
                dir = Direction.LEFT;   
 
                nx = -acc;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir = Direction.RIGHT;
 
                nx = acc;
            }
            if (Input.GetKey(KeyCode.S))
            {
                dir = Direction.DOWN;

                nz = -acc;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                dir = Direction.FORWARD;
   
                nz = acc;
            }
            if (nx == 0f && nz == 0f)
            {
                dir = Direction.STOP;
                //temporary
                if(immediateStop)
                    GetComponent<Rigidbody>().velocity = new Vector3(0f, GetComponent<Rigidbody>().velocity.y, 0f);
            }
            if (nz != 0f && nx != 0f){
                nz = nz/2;
                nx = nx/2;
            }
            target.x = nx;
            target.z = nz;
            //target.y = GetComponent<Rigidbody>().velocity.y;
            target = Quaternion.AngleAxis(xTurn, Vector3.up) * target;
            float vX, vZ;
            vX = GetComponent<Rigidbody>().velocity.x;
            vZ = GetComponent<Rigidbody>().velocity.z;
            if (vX * vX + vZ * vZ < maxSpeed * maxSpeed)
            {
                GetComponent<Rigidbody>().AddForce(target);
                speedLimte = false;
            }
            else
            {
                speedLimte = true;
            }
            //Quaternion direction = transform.localRotation;
            Quaternion direction = Quaternion.Euler(0f,xTurn,0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation,direction,.1f);



            /// <summary>
            /// Jump
            /// </summary>
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (jumpControl&&GetComponent<PowerController>().power!=PowerController.Power.EARTH)
                {
                    
                    GetComponent<Rigidbody>().AddForce(new Vector3(0f, jumpForce, 0f));
                    jumpControl = false;

                }
            }
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (!jumpControl)
            jumpControl = true;
        //JumpSwitch(.1f);
    }
    public IEnumerator JumpSwitch(float time)
    {
        yield return new WaitForSeconds(time);
        jumpControl = true;
    }
}
