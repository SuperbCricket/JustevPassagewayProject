using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int Speed = 6;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0, Speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0, -Speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Speed * Time.deltaTime, 0, 0);
        }
    }
}
