using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int camJumpDistanceHorizontal = 17;
    public int camJumpDistanceVertical = 10;

    public GameObject cam;
    public GameObject player;

    Vector2 maxview;
    Vector2 minview;
    // Start is called before the first frame update 
    void Start()
    {
        cam.transform.position = new Vector3(0, 0, 0);

        // max view point and min viewpoint are asigned //
        
    }

    // Update is called once per frame
    void Update()
    {
        minview = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        maxview = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // camMovesUp
        if (player.transform.position.y > maxview.y + transform.localScale.x / 2)
        {
            cam.transform.position = cam.transform.position + new Vector3(0, camJumpDistanceVertical, 0);
        }

        //camMovesRight
        else if (player.transform.position.x > maxview.x + transform.localScale.y /2)
        {
            cam.transform.position = cam.transform.position + new Vector3(camJumpDistanceHorizontal, 0, 0);
        }

        // camMovesDown
        else if (player.transform.position.y < minview.y + transform.localScale.x / 2)
        {
            cam.transform.position = cam.transform.position + new Vector3(0, -camJumpDistanceVertical, 0);
        }

        // camMovesLeft
        else if (player.transform.position.x < minview.x + transform.localScale.y / 2)
        {
            cam.transform.position = cam.transform.position + new Vector3(-camJumpDistanceHorizontal, 0, 0);
        }
    }
}
