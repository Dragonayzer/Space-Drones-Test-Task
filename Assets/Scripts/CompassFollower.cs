using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject compass;

    [SerializeField]
    [Tooltip("Distance of compass")]
    private float leashLength;

    [SerializeField]
    [Tooltip("Rotatable/visible object")]
    private GameObject body;

    void Update()
    {
        if (Vector3.Distance(transform.position, compass.transform.position) > leashLength)
        {
            Vector3 direction = Vector3.Normalize(compass.transform.position - transform.position);
            compass.transform.position = transform.position + direction * leashLength;
        }

        Vector3 nextStep = Vector3.MoveTowards(transform.position, compass.transform.position, Settings.droneSpeed * Time.deltaTime);
        body.transform.LookAt(nextStep);
        transform.position = nextStep;
    }
}
