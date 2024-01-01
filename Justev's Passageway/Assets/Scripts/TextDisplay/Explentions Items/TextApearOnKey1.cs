using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextApearOnKey1 : MonoBehaviour
{
    public GameObject Text;

    private void Start()
    {
        Text.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            ShowcaseText();
        }
    }
    public void ShowcaseText()
    {
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        Text.SetActive(true);
        yield return new WaitForSeconds(3);
        Text.SetActive(false);
    }
}