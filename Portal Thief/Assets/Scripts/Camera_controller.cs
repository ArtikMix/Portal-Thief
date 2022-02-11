using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    private Transform cam_pos;
    private Transform player;
    private Vector3 mouse_pos;

    private void Start()
    {
        cam_pos = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            cam_pos.position = new Vector3(player.position.x, cam_pos.position.y, player.position.z - cam_pos.position.y);
        }
        MouseNCameraLogic();
        mouse_pos = Input.mousePosition;
    }

    private void MouseNCameraLogic()
    {
        if (mouse_pos.x >= Screen.width)
        {
            cam_pos.transform.Translate(15f * Time.deltaTime, 0f, 0f);
        }
        if (mouse_pos.x <= 0)
        {
            cam_pos.transform.Translate(-15f * Time.deltaTime, 0f, 0f);
        }
        if (mouse_pos.y >= Screen.height)
        {
        }
        if (mouse_pos.y <= 0)
        {
        }
    }
}
