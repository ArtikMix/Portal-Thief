using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    private CharacterController player_controller;
    private Transform player_transform;
    [HideInInspector] public float player_speed = 25f;
    [HideInInspector] public float rotate_speed = 45f;
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip[] animations;

    private void Start()
    {
        player_controller = GetComponent<CharacterController>();
        player_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
        RotateLogic();
    }

    private void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        player_controller.Move(move * player_speed * Time.deltaTime);
    }

    private void RotateLogic()
    {
        Vector3 direction = new Vector3();
        direction.x = Input.GetAxis("Horizontal");
        direction.y = 0f;
        direction.z = Input.GetAxis("Vertical");
        Vector3 targetForward = Vector3.RotateTowards(player_transform.forward, direction.normalized, rotate_speed * Time.deltaTime, 0.1f);
        Quaternion rot = Quaternion.LookRotation(targetForward);
        player_transform.rotation = rot;
        AnimationController(direction);
    }

    private void AnimationController(Vector3 dir)
    {
        AnimationDeactivator();
        if (dir == Vector3.zero)
        {
            animator.SetBool("idle", true);
        }
        if (dir.z > 0)
        {
            animator.SetBool("forward", true);
        }
        if (dir.z < 0)
        {
            animator.SetBool("backward", true);
        }
        if (dir.x > 0)
        {
            animator.SetBool("right", true);
        }
        if (dir.x < 0)
        {
            animator.SetBool("left", true);
        }
        /*if (dir.x>0 && dir.z > 0)
        {
            animator.SetBool
        }*/
    }

    private void AnimationDeactivator()
    {
        foreach(AnimationClip anim in animations)
        {
            animator.SetBool(anim.name, false);
        }
    }
}
