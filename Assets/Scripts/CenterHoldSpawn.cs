using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

public class CenterHoldSpawn : MonoBehaviour
{
    public GameObject starPrefab; // Prefab for the star to spawn
    public float clickHoldTime = 1.0f; // Time that the click must be held to spawn the star, in seconds
    public float minDistance = 3.0f; // Minimum distance from the center at which the star can spawn
    public float maxDistance = 10.0f; // Maximum distance from the center at which the star can spawn

    private bool isClickHeld = false; // Whether the click is currently being held
    private float clickHoldTimer = 0.0f; // Timer for the click hold time
    private Vector3 mouseStartPosition; // Initial mouse position when the click was held

    void Update()
    {
        // Check if the mouse button is down
        if (Input.GetMouseButtonDown(0))
        {
            // Start holding the click
            isClickHeld = true;
            clickHoldTimer = 0.0f;
            mouseStartPosition = Input.mousePosition;

        }

        // Check if the mouse button is up
        if (Input.GetMouseButtonUp(0))
        {
            // Stop holding the click
            isClickHeld = false;


            // Check if the click was held for the required time
            if (clickHoldTimer >= clickHoldTime)
            {
                /* 
                // Calculate the distance from the center to the mouse position
                float distance = Vector3.Distance(transform.position, Input.mousePosition);
                distance = Mathf.Clamp(distance, minDistance, maxDistance);

                // Calculate the angle to the mouse position
               float angle = 
                  Mathf.Atan2(
                      Input.mousePosition.z - transform.position.z, 
                      Input.mousePosition.x - transform.position.x)
                  * Mathf.Rad2Deg;

                */

                // Calculate the position of the star based on the distance and angle
                Vector3 starPosition = new Vector3(
                    mouseStartPosition.x, 
                    mouseStartPosition.y,
                    0);

                // Spawn the star at the calculated position
                GameObject star = Instantiate(starPrefab, starPosition, Quaternion.identity);

            }
        }

        // Update the click hold timer if the click is being held
        if (isClickHeld)
        {
            clickHoldTimer += Time.deltaTime;
            Debug.Log(clickHoldTimer);
        }
    }


}
