using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserFromStar : MonoBehaviour
{
    public GameObject laserPrefab; // Prefab for the laser beam
    public float laserDuration = 1.0f; // How long the laser beam should last before disappearing
    public float laserFrequency = 1.0f; // How often the laser beam should appear

    private float timeSinceLastLaser = 0.0f; // Time since the last laser beam appeared

    void Update()
    {
        // Update the time since the last laser beam appeared
        timeSinceLastLaser += Time.deltaTime;

        // If it's been long enough since the last laser beam appeared, create a new one
        if (timeSinceLastLaser >= laserFrequency)
        {
            // Create the laser beam at the position of the star
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

            // [] - add a laser direction 

            // Destroy the laser beam after the specified duration
            Destroy(laser, laserDuration);

            // Reset the time since the last laser beam appeared
            timeSinceLastLaser = 0.0f;
        }
    }

}
