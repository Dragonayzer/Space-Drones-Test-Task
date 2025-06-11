using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    private State state;
    private GameObject target;
    private GameObject homePoint;
    private NavMeshAgent agent;
    private NavMeshObstacle obstacle;

    [SerializeField]
    private float lootSpeed = 2f;

    [SerializeField]
    private float cooldown = .5f;
    private float lastAction;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        obstacle = GetComponent<NavMeshObstacle>();
        Search();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Searching:
                if (lastAction + cooldown > Time.time) { return; }
                lastAction = Time.time;
                Search();
                break;
            case State.Hunting:
                Hunt();
                break;
            case State.Looting:
                Loot();
                break;
            case State.Returning:
                Home();
                break;
        }

        if (agent.speed != Settings.droneSpeed)
        {
            agent.speed = Settings.droneSpeed;
        }
    }

    // Plays animations and destroys self afterwards
    void Home()
    {
        if (Vector3.Distance(transform.position, homePoint.transform.position) > 2f) return;

        state = State.Finale;
        GetComponentInChildren<ParticleSystem>().Play();
        GetComponent<CompassFollower>().enabled = false;
        transform.DOScale(0.0f, 3f).SetEase(Ease.InOutBounce)
                 .OnComplete(() => {
                    homePoint.GetComponent<Base>().SubmitResource(gameObject);
                    Destroy(gameObject);
                 });
    }

    void Loot()
    {
        if (target == null)
        {
            Search();
            return;
        }

        if (lastAction + lootSpeed > Time.time) { return; }

        Destroy(target);
        state = State.Returning;
        GetComponent<CompassFollower>().enabled = true;
        agent.destination = homePoint.transform.position;
    }

    void Hunt()
    {
        if (target == null || !target.CompareTag("Resource"))
        {
            Search();
            return;
        }

        if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
        {
            agent.destination = transform.position;
            state = State.Looting;
            GetComponent<CompassFollower>().enabled = false;
            lastAction = Time.time;
            target.tag = "Untagged";
            return;
        }
    }

    void Search()
    {
        state = State.Searching;
        agent.destination = transform.position;
        target = GetComponent<Locator>().Locate("Resource");
        if (target == null) { return; }

        state = State.Hunting;
        agent.destination = target.transform.position;
    }

    public void Setup(GameObject _homePoint)
    {
        homePoint = _homePoint;
    }
}

enum State
{
    Searching,
    Hunting,
    Looting,
    Returning,
    Finale
}
