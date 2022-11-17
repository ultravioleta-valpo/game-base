using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrbitAround : MonoBehaviour
{
    // Velocidad de rotacion
    public float OrbitDegrees = 1f;

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            RotatePointAroundPivot(transform.position,
                           transform.parent.position,
                           Quaternion.Euler(0, OrbitDegrees * Time.deltaTime, 0));
    }
}
