using UnityEngine;
using System.Collections;

public class Pivot : MonoBehaviour {
    private float turn;
    public float turnSpeed=1;
    public float pivotSpeed = 5f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            turn += Input.GetAxis("Mouse X")*turnSpeed;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            turn = 0;
        }
        Quaternion direction = Quaternion.Euler(0, transform.parent.localEulerAngles.y+turn, 0);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, pivotSpeed * Time.deltaTime);
    }
}
