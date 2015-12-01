using UnityEngine;
using System.Collections;

public class PowerController : MonoBehaviour {
    public enum Power { FIRE,ICE,LIGHTNING,EARTH,NORMAL};
    public Power power;
    public int lightningPowerUpAmount = 2;
    public Material[] colors;
    public PhysicMaterial Ice,Normal,Earth;
    private Renderer rend;
    public bool powerSwitch =true;
    public GameObject pc_Pcamera;
    public CameraControl pc_playerCameraController;
	public GameObject target_circle;
    private MoveController move;
    private CapsuleCollider playerCollider;
    private Rigidbody playerBody;
    public static int pc_lightningAmmo = 0;
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

        if (power == Power.LIGHTNING) {
			//
			// Texture marker script
			//
			RaycastHit teleport;
			Ray ray = pc_Pcamera.GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out teleport, 50)) {
				Vector3 playerOffest = teleport.point;
				playerOffest.y += 5f;
				target_circle.GetComponent<Projector> ().enabled = true;
				target_circle.transform.position = playerOffest;
			}
			if (Input.GetMouseButtonDown (0)) {
				Teleport ();
			}
		} else {
			target_circle.GetComponent<Projector> ().enabled = false;
		}
		if (power == Power.EARTH) {	
			EarthPower();
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
            move.immediateStop = true;
            move.control = true;
			move.speedModifier = 1f;
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
				move.speedModifier = 1.5f;
                rend.material = colors[0];
                playerBody.mass = 10;
                playerCollider.material = Ice;
                
            }
            else if (power == Power.FIRE)
            {
                //enable other crap;
                move.immediateStop = true;
                move.control = true;
				move.speedModifier = 1f;
                rend.material = colors[1];
                playerBody.mass = 10;
                playerCollider.material = Normal;
                
            }
            else if (power == Power.LIGHTNING)
            {

                move.immediateStop = true;
                move.control = true;
				move.speedModifier = 1f;
                rend.material = colors[2];
                playerBody.mass = 10;
                playerCollider.material = Normal;
                
            }
            else if (power == Power.EARTH)
            {
                //maybe apply downward force;
                move.immediateStop = true;
                move.control = true;
				move.speedModifier = .25f;
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
            if (Physics.Raycast(ray.origin, ray.direction,out teleport, 50))
            {
				Vector3 playerOffest = teleport.point;
				playerOffest.y += 1f;
                transform.position = playerOffest;
				pc_lightningAmmo--;
            }else{

			}
            
        }
        //pc_playerCameraController release pivot; later implement
    }
	private void EarthPower(){
		RaycastHit down;
		int layerMask = 1 << 8;
		if(Physics.Raycast(transform.position,Vector3.down,out down, 1f, layerMask)){
			//temp code
			down.collider.gameObject.GetComponent<MoveAblePlatform>().move = true;
		}
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Light5")
        {
            
            pc_lightningAmmo = lightningPowerUpAmount;
            Destroy(col.gameObject);
        }
    }
}


