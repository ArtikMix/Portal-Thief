using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    private Transform cam_pos;
    private Transform player;
    private Vector3 mouse_pos;

    private float zoomSpeed = 4f;
    private float minZoom = 5f;
    private float maxZoom = 15f;
    private float currentZoom = 10f;
    private Vector3 offset = new Vector3(0, 20, -14.2f);

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
        //ScrollZoomLogic();
    }

    /*private void LateUpdate()
    {
        transform.position = transform.position - offset * currentZoom;
    }*/

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
            cam_pos.transform.Translate(0f, 15f*Time.deltaTime, 15f*Time.deltaTime);
        }
        if (mouse_pos.y <= 0)
        {
            cam_pos.transform.Translate(0f, -15f * Time.deltaTime, -15f * Time.deltaTime);
        }
    }

    /*private void ScrollZoomLogic()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }*/
}
