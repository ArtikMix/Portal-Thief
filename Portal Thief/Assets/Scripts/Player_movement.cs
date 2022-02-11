using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private CharacterController player;
    [HideInInspector] public float player_speed = 5f;

    private void Start()
    {
        player = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        player.Move(move * player_speed * Time.deltaTime);
    }
}
