using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorPatrol : MonoBehaviour
{
    public Transform waypointParent;
    public static Transform[] waypoints;
    public float speed = 10f;
    private Transform target;
    private int wavepointIndex = 0;
    public float damage = 1f;

    private void Awake()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();

        //for (int i = 0; i < waypoints.Length; i++)
        //{
        //    waypoints[i] = transform.GetChild(i);
        //}

    }
    private void Start()
    {
        target = waypoints[0];
    }
    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (wavepointIndex >= waypoints.Length - 1)
        {
            wavepointIndex = 0;
            return;
        }
        wavepointIndex++;
        target = waypoints[wavepointIndex];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerManager>().TakeDamage(damage);
        }
    }
    
}
