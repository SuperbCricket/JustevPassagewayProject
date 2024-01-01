using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject floorKeyDisplay;
    public bool gotKey;

    // Update is called once per frame
    void Start()
    {
        floorKeyDisplay.SetActive(false);
        gotKey = false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Key"))
            {
                gotKey = true;
                floorKeyDisplay.SetActive(true);
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("keyDeposit"))
            {
                if (gotKey == true)
                {
                    gotKey = false;
                    floorKeyDisplay.SetActive(false);
                    Debug.Log("GG");
                }
            }
        }
    }
}
