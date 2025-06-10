using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField]
    private Faction faction;
    [SerializeField]
    private float droneSpawnCooldown = 1f;
    private float lastDroneSpawn = -10f;
    private List<GameObject> drones = new();

    [SerializeField]
    private GameObject FactionScoreText;
    private int score = 0;

    void Update()
    {
        if (lastDroneSpawn + droneSpawnCooldown > Time.time) { return; }

        lastDroneSpawn = Time.time;

        if (drones.Count >= Settings.droneAmount) { return; }

        GameObject newDrone = GetComponent<Spawner>().Spawn();
        newDrone.GetComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
        drones.Add(newDrone);
    }

    public void SubmitResource(GameObject drone)
    {
        score++;
        UpdateScoreDisplay();
        drones.Remove(drone);
    }

    void UpdateScoreDisplay()
    {
        FactionScoreText.GetComponent<TMP_Text>().text = score.ToString();
    }
}

enum Faction
{
    Blue,
    Red
}