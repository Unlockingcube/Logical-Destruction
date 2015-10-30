using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    //public float camOffsetX, camOffsetZ, camOffsetY;
    [HideInInspector]public bool mouseLock = true;
    public GameObject target;
    private Quaternion direction;
    private float cameraSliderY = 0;
	//Y refers to the Screen Y angle and not world space Y
    public float yAngleMax, yAngleMin;
    public float inputScalerY;
    private float rotationOffset;
    // Use this for initialization
    void Start () {

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update() {
        if (mouseLock)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            float panY = -1 * Input.GetAxis("Mouse Y");
            cameraSliderY += panY * inputScalerY;
			if (cameraSliderY < yAngleMax)
            {
				cameraSliderY = yAngleMax;
            }
			else if (cameraSliderY > yAngleMin)
            {
				cameraSliderY = yAngleMin;
            }
			direction = Quaternion.Euler(cameraSliderY, 0f, 0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, direction, .2f);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
