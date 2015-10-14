using UnityEngine;
using System.Collections;

public class PowerController : MonoBehaviour {
    public enum Power { FIRE,ICE,LIGHTNING,EARTH,NORMAL};
    public Power power;
    public Material[] colors;
    public PhysicMaterial Ice,Normal,Earth;
    [HideInInspector]
    public Renderer rend;
    public bool powerSwitch =true;
    public GameObject pc_Pcamera;
    public CameraControl pc_playerCameraController;
    private MoveController move;
    private CapsuleCollider playerCollider;
    private Rigidbody playerBody;
    public static int pc_lightningAmmo = 100;
    static int pc_maxLightningAmmo = 100;
    
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
            pc_playerCameraController.mouseLock = true;
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
                pc_playerCameraController.mouseLock = true;
                move.immediateStop = false;
                move.control = true;
                rend.material = colors[0];
                playerBody.mass = 10;
                playerCollider.material = Ice;
                
            }
            else if (power == Power.FIRE)
            {
                //enable other crap;
                pc_playerCameraController.mouseLock = true;
                move.immediateStop = true;
                move.control = true;
                rend.material = colors[1];
                playerBody.mass = 10;
                playerCollider.material = Normal;
                
            }
            else if (power == Power.LIGHTNING)
            {
                pc_playerCameraController.mouseLock = false;
                move.immediateStop = true;
                move.control = true;
                rend.material = colors[2];
                playerBody.mass = 10;
                playerCollider.material = Normal;
                
            }
            else if (power == Power.EARTH)
            {
                //maybe apply downward force;
                pc_playerCameraController.mouseLock = true;
                move.immediateStop = true;
                move.control = true;
                rend.material = colors[3];
                playerBody.mass = 100;
                playerCollider.material = Earth;
            }
            powerSwitch = false;
            StartCoroutine(PowerSwitch(3f,Power.NORMAL));
        }
    }
    public IEnumerator PowerSwitch(float time,Power toggle_power)
    {
        //expand later to toggle off a power
        yield return new WaitForSeconds(time);   
        powerSwitch = true;
    }
    private void Teleport()
    {
        if (pc_lightningAmmo > 0)
        {
			RaycastHit teleport;
            Ray ray = pc_Pcamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            if (Physics.Raycast(transform.position, ray.direction,out teleport, 50))
            {
				Vector3 playerOffest = teleport.point;
				playerOffest.y += 1f;
                transform.position = playerOffest;
            }else{
				transform.position = ray.GetPoint(50);
			}
            pc_lightningAmmo--;
        }
        //pc_playerCameraController release pivot; later implement
    }
}
