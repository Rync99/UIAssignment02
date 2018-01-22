using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float rotSpeed = 30.0f;

    public enum RotateDir
    {
        X_DIR_ROTATE,
        Y_DIR_ROTATE,
        Z_DIR_ROTATE,
    }

    [SerializeField]
    RotateDir dirRotate = RotateDir.X_DIR_ROTATE;

    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        float angleRotate = rotSpeed * Mathf.Deg2Rad;

        switch (dirRotate)
        {
            case RotateDir.X_DIR_ROTATE:
                transform.Rotate(Vector3.up, -angleRotate);
                break;
            case RotateDir.Y_DIR_ROTATE:
                transform.Rotate(Vector3.forward, -angleRotate);
                break;
            case RotateDir.Z_DIR_ROTATE:
                transform.Rotate(Vector3.right, -angleRotate);
                break;
        }
    }

}