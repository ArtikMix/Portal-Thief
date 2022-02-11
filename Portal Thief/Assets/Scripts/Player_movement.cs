using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private CharacterController player_controller;
    private Transform player_transform;
    [HideInInspector] public float player_speed = 5f;

    private void Start()
    {
        player_controller = GetComponent<CharacterController>();
        player_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        player_controller.Move(move * player_speed * Time.deltaTime);
        RotateLogic();
    }

    private void RotateLogic()
    {
        if (Input.GetAxis("Horizontal") > 0f)
        {
            player_transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            player_transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        if (Input.GetAxis("Vertical") > 0f)
        {
            player_transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetAxis("Vertical") > 0f)
        {
            player_transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
