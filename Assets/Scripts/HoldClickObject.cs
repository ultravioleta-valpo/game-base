using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldClickObject : MonoBehaviour
{
    /* 
        el objeto recibe el click y cuenta el tiempo que se mantiene presionado
        con ello hace el spawn

     */



    public GameObject SpawnObject;
    public Vector3 randomDisplacement;
    private bool mouseDown = false;
    // comportamiento de carga:
    private float totalCharge = 0f;
    private float totalChargeNeeded = 1f;

    //randomDisplacement =  new Vector3(0.0f, 1.0f, 0.0f);

    public void SpawnCharged()
    {
        Debug.Log("intentando spawnear con: " + totalCharge.ToString());
        if (totalCharge >= totalChargeNeeded)
        {
            Debug.Log("spawn logrado"); 

            GameObject newStar = Instantiate(
                SpawnObject, transform.position + randomDisplacement, Quaternion.identity
                );

            // transform hace referencia al propio objeto,
            // se usa el comportamiento de parent para asi configurar
            newStar.transform.SetParent(transform);
            
        }
        totalCharge = 0f;
    }

    private void OnMouseDown()
    {
        /*random position, find x, then x^2 - ideal_distance = y^2*/
        Debug.Log("Mouse down is pressed");
        mouseDown = true;
    }

    private void OnMouseUp()
    {
        mouseDown = false;
        Debug.Log("Mouse up is pressed");

        SpawnCharged(); // spawn de la estrella

    }

    private void Update()
    {
        if(mouseDown)
        {
            totalCharge += Time.deltaTime;
            Debug.Log("pressing for:" + totalCharge.ToString() );
        }
        
    }


}
