using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{


    [SerializeField]
    GameObject UIObj = null;

    public Transform theCamera;

    JoyScript targetScript;

    private float zAn = 0.0f; //variable for control angles rotation
    private float zAnMax = 20.0f;
    private float zAnMin = -20.0f;
    private float speedRot = 50.0f;

    void Start()
    {
        targetScript = UIObj.GetComponent<JoyScript>();
                
    }

    void Update()
    {


     float moveSpeed = 200.0f;

        //Indicator from joyscript to indicate that function Dragging() is running
        if (targetScript.isStopDragging == false)
        {
            Vector3 targetDir = targetScript.direction;
            //Debug.Log(targetDir);

            //Move foward
            if (targetDir.y > 0)
            {
                GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed * Time.deltaTime);
            }
            //Move backward
            else if (targetDir.y < 0 )
            {
                GetComponent<Rigidbody>().AddForce(-transform.forward * moveSpeed * Time.deltaTime);
            }

            //Clockwise rotation
            if (targetDir.x > 0 )
            {
                zAn = zAn - speedRot * Time.deltaTime;
                if (zAn < zAnMin)
                {
                    zAn = zAnMin;
                }
                //GetComponent<Rigidbody>().AddForce(transform.right * moveSpeed * Time.deltaTime);
                this.transform.localRotation = Quaternion.Euler(0, 0, zAn);
            }
            //Anticlockwise rotation
            else if (targetDir.x < 0 )
            {
                zAn = zAn + speedRot * Time.deltaTime;
                if (zAn > zAnMax)
                {
                    zAn = zAnMax;
                }
               // GetComponent<Rigidbody>().AddForce(-transform.right * moveSpeed * Time.deltaTime);
                this.transform.localRotation = Quaternion.Euler(0, 0, zAn);
            }
        }

     
    }
    
}