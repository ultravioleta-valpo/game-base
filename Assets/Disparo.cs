using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject prefabBala; //los prefabs son GameObject
    public Transform origenDisparo; //Transform es un datatype con posicion

    public float impulsoDisparo = 5f;

    void Update() // experimentare con Fixed en lugar de Update
    {
        if (Input.GetButtonDown("Fire1")) {
            DispararBalaBasica();
        }
        
    }

    //funcion de disparo
    // instancia el prefab de bala, lee el rigidbody2d de lo creado y le aplica impulso
    void DispararBalaBasica() {
        GameObject spawnedBala = Instantiate(prefabBala, origenDisparo.position, origenDisparo.rotation); 
        Rigidbody2D spawnedBalaRigidBody = spawnedBala.GetComponent<Rigidbody2D>();
        spawnedBalaRigidBody.AddForce(origenDisparo.up * impulsoDisparo, ForceMode2D.Impulse); 

    }
}
