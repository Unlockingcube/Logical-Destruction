using UnityEngine;
using System.Collections;

//move the class into camera controller later
public class Pivot : MonoBehaviour {
    private float turn;
    public float turnSpeed=1;
    public float pivotSpeed = 5f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
        {
            turn += Input.GetAxis("Mouse X")*turnSpeed;
        }
        else
        {
            turn = 0;
        }
        Quaternion direction = Quaternion.Euler(0, transform.parent.localEulerAngles.y+turn, 0);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, pivotSpeed * Time.deltaTime);
    }
}
