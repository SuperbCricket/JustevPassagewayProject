using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texts : MonoBehaviour
{
    public GameObject E;
    // Start is called before the first frame update
    void Start()
    {
        E.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Key") | other.gameObject.CompareTag("doorKey"))
        {
            E.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key") | other.gameObject.CompareTag("doorKey"))
        {
            E.SetActive(false);
        }
    }
}
