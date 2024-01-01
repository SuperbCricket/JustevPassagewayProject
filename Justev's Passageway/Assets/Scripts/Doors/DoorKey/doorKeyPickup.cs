using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class doorKeyPickup : MonoBehaviour
{
    public GameObject doorKeyDisplay;
    public TextMeshProUGUI text;
    public float gotDoorKey;

    // Update is called once per frame
    void Start()
    {
        gotDoorKey = 0;
    }

    private void Update()
    {
        if (gotDoorKey == 0)
        {
            doorKeyDisplay.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E))
        {   
            if (other.gameObject.CompareTag("doorKey"))
            {
                gotDoorKey += 1;
                text.text = "X " + gotDoorKey;
                doorKeyDisplay.SetActive(true);
                Destroy(other.gameObject);
            }
            if (other.gameObject.CompareTag("Door"))
            {
                if (gotDoorKey >= 1)
                {

                    gotDoorKey -= 1;
                    text.text = "X " + gotDoorKey;
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
