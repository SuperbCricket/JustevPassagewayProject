using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorKeySpawn : MonoBehaviour
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
        float randomNumber = Random.Range(1, 10);
        if (randomNumber == 1)
        {
            Vector3 Location = new Vector3(-54, 30, -1);
            return Location;
        }
        else if (randomNumber == 2)
        {
            Vector3 Location = new Vector3(-35, 50, -1);
            return Location;
        }
        else if (randomNumber == 3)
        {
            Vector3 Location = new Vector3(-18, 40, -1);
            return Location;
        }
        else if (randomNumber == 4)
        {
            Vector3 Location = new Vector3(-0, 50, -1);
            return Location;
        }
        else if (randomNumber == 5)
        {
            Vector3 Location = new Vector3(37, 40, -1);
            return Location;
        }
        else if (randomNumber == 6)
        {
            Vector3 Location = new Vector3(55, 40, -1);
            return Location;
        }
        else if (randomNumber == 7)
        {
            Vector3 Location = new Vector3(52, 50, -1);
            return Location;
        }
        else if (randomNumber == 8)
        {
            Vector3 Location = new Vector3(52, 70, -1);
            return Location;
        }
        else
        {
            Vector3 Location = new Vector3(-55, 80, -1);
            return Location;
        }
    }
}
