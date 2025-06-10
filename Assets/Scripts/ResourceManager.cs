using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private float lastResourceSpawn = -10f;

    [SerializeField]
    private Vector2 worldMin;
    [SerializeField]
    private Vector2 worldMax;

    void Update() {
        if (lastResourceSpawn + Settings.resourceSpawnRate < Time.time) {
            GetComponent<Spawner>().Spawn(worldMin, worldMax);
            lastResourceSpawn = Time.time;
        }
    }
}
