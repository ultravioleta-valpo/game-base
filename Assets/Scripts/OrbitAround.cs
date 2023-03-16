using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class OrbitAround : MonoBehaviour
{
    // Velocidad de rotacion
    public float OrbitDegrees = 10f;
    public float StarIndex; // funciona para no posicionar estrellas sobre otras

    public static Vector3 RotatePointAroundPivot(Vector3 point, Quaternion angle)
    {
        return angle * (point);
    }

    // Update is called once per frame
    void Update()
    {

            transform.position =
            RotatePointAroundPivot(transform.position,
                           Quaternion.Euler(0, OrbitDegrees * Time.deltaTime, 0));

    }
}
