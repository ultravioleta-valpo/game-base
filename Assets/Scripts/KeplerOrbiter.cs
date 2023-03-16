using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeplerOrbiter : MonoBehaviour
{
    public float excentricity = 0.0f; // Excentricity of the orbit
    public float period = 20.0f; // Period of the orbit in seconds
    private float timeSincePeriapsis = 0.0f; // Time since the star passed through the periapsis of its orbit
    public float initialAngle = 0.0f; // Initial angle of the star when the simulation starts
    public float currentAngle = 0.0f;
    private float distance = 0.0f;
    Vector3 origin = new Vector3(0, 0, 0);
    public bool isKeplerian = true; // legacy

    void Start()
    {

            distance = Vector3.Distance(transform.position, origin);
            // Calculate the angle to the center of the orbit
            initialAngle = Mathf.Atan2(transform.position.z, transform.position.x) * Mathf.Rad2Deg;

            if (period < 20.0f)
            {
                period = 20.0f;
            }

            // Calculate the mean anomaly based on the initial angle and period
            float meanAnomaly = initialAngle - 360.0f * Mathf.Floor(initialAngle / 360.0f);

            // Calculate the eccentric anomaly based on the mean anomaly and excentricity
            float eccentricAnomaly = CalculateEccentricAnomaly(meanAnomaly, excentricity);

            // Calculate the true anomaly based on the eccentric anomaly and excentricity
            float trueAnomaly = CalculateTrueAnomaly(eccentricAnomaly, excentricity);

            // Set the initial values for timeSincePeriapsis and currentAngle
            timeSincePeriapsis = meanAnomaly / 360.0f * period;
            currentAngle = trueAnomaly;
            
        

    }

    void FixedUpdate()
    {

            // Update the time since periapsis
            timeSincePeriapsis += Time.deltaTime;

            // Calculate the current angle of the star using Kepler's laws
            currentAngle = CalculateCurrentAngle(timeSincePeriapsis, excentricity, period);

            // Calculate the position of the star based on its angle and excentricity
            Vector3 position = distance * CalculateOrbitPosition(currentAngle, excentricity);

            // Set the position of the star
            transform.position = position;

        }





    void OnTriggerEnter(Collider other)
    {
        // Laser tag
        if (other.gameObject.tag == "Enemies")
        {
                Destroy(other.gameObject);
        }

    }


    // Calculates the eccentric anomaly of the star based on its mean anomaly and excentricity
    float CalculateEccentricAnomaly(float meanAnomaly, float excentricity)
    {
        // Convert the mean anomaly to radians
        float meanAnomalyRadians = meanAnomaly * Mathf.Deg2Rad;

        // Initialize the eccentric anomaly to the mean anomaly
        float eccentricAnomaly = meanAnomalyRadians;

        // Iteratively improve the estimate of the eccentric anomaly using the Newton-Raphsonmethod
        for (int i = 0; i < 10; i++)
        {
            // Calculate the error in the current estimate of the eccentric anomaly
            float error = eccentricAnomaly - excentricity * Mathf.Sin(eccentricAnomaly) - meanAnomalyRadians;

            // Calculate the derivative of the error with respect to the eccentric anomaly
            float derivative = 1 - excentricity * Mathf.Cos(eccentricAnomaly);

            // Improve the estimate of the eccentric anomaly using the Newton-Raphson method
            eccentricAnomaly -= error / derivative;
        }

        // Convert the eccentric anomaly back to degrees and return it
        return eccentricAnomaly * Mathf.Rad2Deg;
    }

    // Calculates the true anomaly of the star based on its eccentric anomaly and excentricity
    float CalculateTrueAnomaly(float eccentricAnomaly, float excentricity)
    {
        // Convert the eccentric anomaly to radians
        float eccentricAnomalyRadians = eccentricAnomaly * Mathf.Deg2Rad;

        // Calculate the true anomaly using the eccentric anomaly and excentricity
        float trueAnomalyRadians = Mathf.Atan2(Mathf.Sqrt(1 - excentricity * excentricity) * Mathf.Sin(eccentricAnomalyRadians), excentricity + Mathf.Cos(eccentricAnomalyRadians));

        // Convert the true anomaly back to degrees and return it
        return trueAnomalyRadians * Mathf.Rad2Deg;
    }

    // Calculates the current angle of the star based on its time since periapsis, excentricity, and period
    float CalculateCurrentAngle(float timeSincePeriapsis, float excentricity, float period)
    {
        // Calculate the mean anomaly of the star using the time since periapsis and period
        float meanAnomaly = 360.0f * timeSincePeriapsis / period;

        // Calculate the eccentric anomaly of the star using the mean anomaly and excentricity
        float eccentricAnomaly = CalculateEccentricAnomaly(meanAnomaly, excentricity);

        // Calculate the true anomaly of the star using the eccentric anomaly and excentricity
        float trueAnomaly = CalculateTrueAnomaly(eccentricAnomaly, excentricity);

        // Return the true anomaly as the current angle of the star
        return trueAnomaly;
    }

    // funcion mas conservadora
    Vector3 CalculateOrbitPosition(float angle, float excentricity)
    {
        // Return a default position if the excentricity is 0
        if (excentricity == 0)
        {
            excentricity = 0.001f;
        }

        // Calculate the position of the star based on its angle and excentricity
        float x = excentricity * Mathf.Cos(angle);
        float z = Mathf.Sin(angle);
        Vector3 position = new Vector3(x, 0, z);

        return position;
    }
}