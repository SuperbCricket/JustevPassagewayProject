using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    StalkerAI stalkerAI;

    public void Start()
    {
        stalkerAI = FindObjectOfType<StalkerAI>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Stalker"))
        {
            Debug.Log("beenSpot");
        }
    }
}
