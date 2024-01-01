using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawn : MonoBehaviour
{
    void Start()
    {
        float doorChance = Random.Range(1, 4);
        if (doorChance == 1)
        {
            Destroy(gameObject);
        }
    }
}
