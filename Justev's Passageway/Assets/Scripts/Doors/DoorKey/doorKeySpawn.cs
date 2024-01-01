using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorKeySpawn : MonoBehaviour
{
    private Vector3 Location;
    // Start is called before the first frame update
    void Start()
    {
        Location = TPLocation();
        transform.position = Location;
    }
    private Vector3 TPLocation()
    {
        float randomNumber = Random.Range(1, 7);
        if (randomNumber == 1)
        {
            Vector3 Location = new Vector3(-36, 30, -1);
            return Location;
        }
        else if (randomNumber == 2)
        {
            Vector3 Location = new Vector3(36, 30, -1);
            return Location;
        }
        else if (randomNumber == 3)
        {
            Vector3 Location = new Vector3(0, 40, -1);
            return Location;
        }
        else if (randomNumber == 4)
        {
            Vector3 Location = new Vector3(18, 50, -1);
            return Location;
        }
        else if (randomNumber == 5)
        {
            Vector3 Location = new Vector3(-36, 60, -1);
            return Location;
        }
        else
        {
            Vector3 Location = new Vector3(36, 60, -1);
            return Location;
        }
    }
}
