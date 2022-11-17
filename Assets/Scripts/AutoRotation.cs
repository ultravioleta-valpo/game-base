using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    public float yAngleSpeed = 2f;
    public float xAngleSpeed = 0f;

    /*
    public float yAngleAcceleration = 0f; //speed
    public float maximumRotationSpeed = 10f;
    public float xAngleAcceleration = 0f; //speed
    public float maximumRotationSpeed = 10f;
    */

    void Update()
    {
        /*
        if(yAngleSpeed <= maximumRotationSpeed)
        {
            yAngleSpeed += Time.deltaTime * yAngleAcceleration;
        }
        */


        transform.Rotate(xAngleSpeed,yAngleSpeed, 0, Space.Self);
    }
}
