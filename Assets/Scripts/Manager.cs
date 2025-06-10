using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Drone amount per faction")]
    [Range(1, 10)]
    private int droneAmount = 3;

    [SerializeField]
    [Range(0f, 10f)]
    private float droneSpeed = 1f;

    [SerializeField]
    [Tooltip("Resource respawn rate in seconds")]
    [Range(.5f, 10f)]
    private float resourceSpawnRate = 5f;

    [SerializeField]
    private bool dronePathDisplay = false;

    [SerializeField]
    [Range(0f, 5f)]
    private float simulationTime = 1f;

    private float lastResourceSpawn = -10f;

    [SerializeField]
    private Vector2 worldMin;
    [SerializeField]
    private Vector2 worldMax;

    [SerializeField]
    private GameObject floorPlane;

    [SerializeField]
    private GameObject resourcePrefab;

    void Start() {
        
    }

    void Update() {
        if (lastResourceSpawn + resourceSpawnRate < Time.time) {
            SpawnResource();
            lastResourceSpawn = Time.time;
        }
    }

    void SpawnResource() {
        GameObject newResource = Instantiate(resourcePrefab);
        newResource.transform.position = new Vector3(Random.Range(worldMin.x, worldMax.x), 1f, Random.Range(worldMin.y, worldMax.y));
    }
}
