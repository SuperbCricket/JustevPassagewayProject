using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class RotatingLight : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    public GameObject cam;
    public Vector3 mousePos;
    public float rotationSpeed;
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos != null)
        {
            RotateTowardsTarget();
        }
    }

    void RotateTowardsTarget()
    {
        Vector3 targetDirection = mousePos - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);

        // Use Quaternion.Slerp to smoothly rotate towards the target
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
