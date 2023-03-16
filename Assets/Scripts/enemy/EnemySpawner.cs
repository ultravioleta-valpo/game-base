using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab for the enemy to spawn
    public float spawnRadius = 1.0f; // Radius within which the enemy can spawn
    public float spawnAngle = 0.0f; // Angle at which the enemy can spawn, in degrees
    public bool useMousePosition = false; // Whether to use the mouse position to determine the spawn angle

    void Update()
    {
        // Check if the spawn button was pressed
        // s por spawn
        if (Input.GetButtonDown("s"))
        {
            // define el angulo de spawn mediante la posicion del mouse
            float angle = spawnAngle;
            if (useMousePosition)
            {
                // Calculate the angle to the mouse position
                Vector3 mousePosition = Input.mousePosition;
                angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
            }

            // Calculate the spawn position based on the spawn radius and angle
            Vector3 spawnPosition = transform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0) * spawnRadius;

            // Spawn the enemy at the calculated position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
