// =========================================================
// Title: EnemyAI
// Author(s): Martin Nguyen
// Date: 19/06/2019
// Details: Handles Waypoints for AI as well as a seek and patrol switch
// Reference: 
// =========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    #region Variables
    public State currentState;
    public Transform waypointParent;
    public float movespeed = 2f;
    public float stoppingDistance = 1f;

    public Transform[] waypoints;
    private int currentIndex = 1;
    private NavMeshAgent agent;
    private Transform target;
    #endregion
    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        currentState = State.Patrol;
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.seek:
                Seek();
                break;
            default:
                Patrol();
                break;
        }
    }

    void Patrol()
    {
        Transform point = waypoints[currentIndex];

        float distance = Vector3.Distance(transform.position, point.position);

        if (distance < stoppingDistance)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }
        agent.SetDestination(point.position);
    }

    void Seek()
    {
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            target = other.transform;
            currentState = State.seek;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentState = State.Patrol;
        }
    }
}
public enum State
    {
        Patrol, seek
    }
