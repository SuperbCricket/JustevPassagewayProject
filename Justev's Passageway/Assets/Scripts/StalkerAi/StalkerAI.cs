using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StalkerAI : MonoBehaviour
{
    public List<GameObject> waypoints;
    public GameObject playerTarget;

    private Vector3 destination;

    public int rotateSpeed;
    private int index;

    public float speed;
    public float nextWaypointDistance;

    Path path;
    private int currentWaypoint = 0;

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

    void TrackingPlayer()
    {
    
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
            // Rotates light Towards waypoint
            rb.transform.rotation = Quaternion.LookRotation(Vector3.forward, path.vectorPath[currentWaypoint] - rb.transform.position);
        }

        //Moves Player 
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
