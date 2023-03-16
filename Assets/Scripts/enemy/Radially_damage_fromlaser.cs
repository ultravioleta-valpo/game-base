using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radially_damage_fromlaser : MonoBehaviour
{
private float speed = 3.0f; // Speed at which the enemy moves towards the center
public int health = 1; // Number of times the enemy can be hit before it is destroyed

void Update()
{
    // Calculate the direction to the center of the screen
    Vector3 direction = Vector3.zero - transform.position;

    // Normalize the direction to get a unit vector
    direction.Normalize();

    // Move the enemy towards the center
    transform.position += direction * speed * Time.deltaTime;
}

// se activa al colisionar, other es el objeto con el cual colisiona
void OnTriggerEnter(Collider other)
{
    // Laser tag
    if (other.gameObject.tag == "Laser")
    {
        // Reduce the enemy's health
        health--;

        // If the enemy's health reaches 0, destroy it
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Si golpea el planeta, el jugador pierde vida y material
    if (other.gameObject.tag == "Planet")
    {
            // Reducir la vida del jugador, o retornar un valor para leerse?
            //health--;
            // como hablar con el script de vida?
            Debug.Log("Entro en colision");
            Debug.Log(other.gameObject.tag);
            Destroy(gameObject);


        }
}

}
