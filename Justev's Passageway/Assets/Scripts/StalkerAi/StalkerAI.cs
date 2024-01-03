using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using TMPro;

public class StalkerAI : MonoBehaviour
{
    public List<GameObject> waypoints;
    public GameObject playerTarget;

    public Vector3 pathTargetPosition;

    public float speed;
    public float rotSpeed;
    public float nextWaypointDistance;

    private Vector3 destination;
    
    Path path;
    private int currentWaypoint = 0;
    private int index;

    Seeker seeker;
    Rigidbody2D rb;
    
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        UpdatePath();
        
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            index = Random.Range(1, waypoints.Count);
            destination = waypoints[index].transform.position;
            seeker.StartPath(rb.position, destination, OnPathComplete);
        }
    }
        
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 directionTopPathTarget = pathTargetPosition - rb.transform.position;

        // Goes To next Waypoint when at Waypoint
        if (path == null)
        {
            return;
        }

        // when at end of path
        if (currentWaypoint >= path.vectorPath.Count)
        {
            UpdatePath();
        }

        // when not at end of path
        else
        {
            {
                pathTargetPosition = path.vectorPath[currentWaypoint];
                Vector3 directionToTarget = pathTargetPosition - rb.transform.position;
                directionToTarget.z = 0;

                //Moves Stalker
                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
                Vector2 force = direction * speed * Time.deltaTime;
                rb.AddForce(force);
                float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

                if (distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }

                //RotatesStalker
                if (directionToTarget != Vector3.zero)
                {
                    // Calculate the rotation needed to face the target position
                    Quaternion PathTargetRotation = Quaternion.LookRotation(rb.transform.forward, directionToTarget);

                    // Rotate towards the target position with a specified speed
                    rb.transform.rotation = Quaternion.RotateTowards(rb.transform.rotation, PathTargetRotation, rotSpeed * Time.deltaTime).normalized;
                }

                
            }
        }
    }
}
