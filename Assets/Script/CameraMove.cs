using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMove : MonoBehaviour
{
    
    public float speed = 0.125f;
    public Transform target;
    public Vector3 offset;

    //public VariableJoystick joy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    
    
    void Start()
    {
        //으헤
        
    }
    
    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothedPosition;
    }
}
