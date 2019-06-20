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

public class EnemyAI : MonoBehaviour
{
    //Enemy Variables
    public float speed = 5f;

    //other variables
    public Transform target;
    private int wavepointIndex = 0;
    public static Transform[] points;

    private void Awake()
    {
        //On game start detects the waypoints from the children of the gameobject
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    void Start()
    {
        target = points[0];
    }

    void Update()
    {
        //movement
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //next waypoint and loop
        if(Vector3.Distance(transform.position,target.position)<=0.5f)
        {
            if (wavepointIndex>=points.Length - 1)
            {
                wavepointIndex = 0;
                return;
            }
            wavepointIndex++;
            target = points[wavepointIndex];
        }
    }
}
