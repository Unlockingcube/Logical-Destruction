using UnityEngine;
using System.Collections;

public class PowerController : MonoBehaviour {
    public enum Power { FIRE,ICE,LIGHTNING,EARTH,NORMAL};
    public Power power;
    public Material[] colors;
    public PhysicMaterial Ice,Normal,Earth;
    public GameObject pc_Pcamera;
    [HideInInspector]
    public Renderer rend;
    public bool powerSwitch =true;
    public CameraControl playerCamera;
    private MoveController move;
    private CapsuleCollider playerCollider;
    private Rigidbody playerBody;
    
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        move = GetComponent<MoveController>();
        playerCollider = GetComponent<CapsuleCollider>();
        playerBody = GetComponent<Rigidbody>();
        power = Power.NORMAL;
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Ray ray = pc_Pcamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawSphere(ray.GetPoint(10), 1);
    }
    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.F))
		{
            PowerToggle(Power.ICE);
        }
		else if (Input.GetKeyDown(KeyCode.V))
		{
            PowerToggle(Power.FIRE);
        }
		else if (Input.GetKeyDown(KeyCode.R))
		{
            PowerToggle(Power.LIGHTNING);
        }
		else if (Input.GetKeyDown(KeyCode.G))
		{
            PowerToggle(Power.EARTH);	
		}

        if (power == Power.LIGHTNING)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Teleport();
            }
        }
			
	}
    void PowerToggle(Power tarPow)
    {
        if(power == tarPow)
        {
            power = Power.NORMAL;
        }
        else
        {
            if (powerSwitch)
            {
                power = tarPow;
            }
        }
        SwapPower();
    }
    void SwapPower()
    {
        if (power == Power.NORMAL)
        {
            //undo the crap you did in the others basically.
            playerCamera.mouseLock = true;
            move.immediateStop = true;
            move.control = true;
            rend.material = colors[4];
            playerCollider.material = Normal;
            playerBody.mass = 10;
            

        }
        else if (powerSwitch) { 
            if (power == Power.ICE)
            {
                //toggle something moveController to increase speed etc...
                move.immediateStop = false;
                move.control = true;
                rend.material = colors[0];
                playerBody.mass = 10;
                playerCollider.material = Ice;
                
            }
            else if (power == Power.FIRE)
            {
                //enable other crap;
                move.immediateStop = true;
                move.control = true;
                rend.material = colors[1];
                playerBody.mass = 10;
                playerCollider.material = Normal;
                
            }
            else if (power == Power.LIGHTNING)
            {
                playerCamera.mouseLock = false;
                //move.immediateStop = true;
                //move.control = false;
                rend.material = colors[2];
                playerBody.mass = 10;
                playerCollider.material = Normal;
                
            }
            else if (power == Power.EARTH)
            {
                //maybe apply downward force;
                move.immediateStop = true;
                move.control = true;
                rend.material = colors[3];
                playerBody.mass = 100;
                playerCollider.material = Earth;
            }
            powerSwitch = false;
            StartCoroutine(PowerSwitch(3f));
        }
    }
    public IEnumerator PowerSwitch(float time)
    {
        yield return new WaitForSeconds(time);   
        powerSwitch = true;
    }
    private void Teleport()
    {
        Ray ray = pc_Pcamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        if (!Physics.Raycast(ray.origin, ray.direction, 10))
        {
            transform.position = ray.GetPoint(10);
        }
        //playerCamera release pivot; later implement
    }
}
