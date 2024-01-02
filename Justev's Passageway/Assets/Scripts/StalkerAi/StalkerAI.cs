using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StalkerAI : MonoBehaviour
{
    public List<GameObject> waypoints;
    public GameObject playerTarget;

    public float speed;
    public float nextWaypointDistance;
    public bool spottedPlayer;

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
        spottedPlayer = false;
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

    public void chasingStarts()
    {
        spottedPlayer=true;
    }
    // Update is called once per frame
    void FixedUpdate()
    { 
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
            //Moves Stalker
            if(spottedPlayer == true)
            {
                // Rotates light Towards waypoint
                rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, playerTarget.transform.position - rb.transform.position);

                Vector2 direction = ((Vector2)playerTarget.transform.position - rb.position).normalized;
                Vector2 force = direction * speed * 3 * Time.deltaTime;
                rb.AddForce(force);
            }
            else
            {
                // Rotates light Towards waypoint
                rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, path.vectorPath[currentWaypoint] - rb.transform.position);

                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
                Vector2 force = direction * speed * Time.deltaTime;
                rb.AddForce(force);
                float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

                if (distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }
            }
        }
    }
}
