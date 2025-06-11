using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private float lastResourceSpawn = -10f;
    [SerializeField]
    private float resourceSpawnRateCap = 0.1f;

    [SerializeField]
    private Vector2 worldMin;
    [SerializeField]
    private Vector2 worldMax;

    void Update() {
        if (lastResourceSpawn + Mathf.Max(Settings.resourceSpawnRate, resourceSpawnRateCap) > Time.time) { return; }
        
        GetComponent<Spawner>().Spawn(worldMin, worldMax);
        lastResourceSpawn = Time.time;
    }
}
