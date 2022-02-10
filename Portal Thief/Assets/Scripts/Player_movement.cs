using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private Transform player;
    [HideInInspector] public float player_speed = 5f;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.Translate(0f, 0f, player_speed * Time.deltaTime);
        }
    }
}
