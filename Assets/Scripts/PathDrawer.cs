using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class PathDrawer : MonoBehaviour
{
    LineRenderer line;
    NavMeshAgent agent;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        agent = GetComponent<NavMeshAgent>();

        if (!Settings.dronePathDisplay)
        {
            line.enabled = false;
        }
    }

    void Update()
    {
        if (line.enabled != Settings.dronePathDisplay)
        {
            line.enabled = Settings.dronePathDisplay;
        }
        
        if (!Settings.dronePathDisplay) { return; }

        line.SetPositions(agent.path.corners);
    }
}
