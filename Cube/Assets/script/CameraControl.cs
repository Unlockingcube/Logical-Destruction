using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    //public float camOffsetX, camOffsetZ, camOffsetY;
    public bool mouseLock = true;
    public float maxX, MaxZ, minX, minZ;
    public float cameraPan;
    public float cameraRotateSpeed,cameraSpeed;
    public GameObject target;
    //private float nX, nZ, nY;
    public float rotationX;


    private Quaternion direction;
    private float cameraSlider = 0;
    private float cameraSliderY = 0;

    public float yAngleMax, yAngleMin, xAngleMax, xAngleMin;
    public float inputScalerX,inputScalerY;
    public int cameraTolerance = 100;
    private float rotationOffset;
    // Use this for initialization
    void Start () {
        direction = Quaternion.Euler(rotationX, cameraPan, 0);
        transform.rotation = direction;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update() {
        if (mouseLock)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            float targetPanX = 0;
            //if (Input.GetMouseButton(0)) {
            //    
            //    rotationOffset = target.transform.localEulerAngles.y;

            //    float pan = Input.GetAxis("Mouse X");
            //    cameraSlider += pan * inputScalerX;
            //    targetPanX = cameraPan * cameraSlider;

            //    if (targetPanX < xAngleMax + rotationOffset)
            //    {
            //        targetPanX = xAngleMax + rotationOffset;
            //        cameraSlider = targetPanX / cameraPan;
            //    }
            //    else if (targetPanX > xAngleMin + rotationOffset)
            //    {
            //        targetPanX = xAngleMin + rotationOffset;
            //        cameraSlider = targetPanX / cameraPan;
            //    }
            //}
            //else
            //{
            //    cameraSlider = 0f;
            //    targetPanX = 0f;
            //}


            float panY = -1 * Input.GetAxis("Mouse Y");
            cameraSliderY += panY * inputScalerY;

            float targetPanY = rotationX * cameraSliderY;
            if (targetPanY < yAngleMax)
            {
                targetPanY = yAngleMax;
                cameraSliderY = targetPanY / rotationX;
            }
            else if (targetPanY > yAngleMin)
            {
                targetPanY = yAngleMin;
                cameraSliderY = targetPanY / rotationX;
            }
            direction = Quaternion.Euler(targetPanY, targetPanX, 0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, direction, .2f);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
}
