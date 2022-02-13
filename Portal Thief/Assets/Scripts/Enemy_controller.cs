using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_controller : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] patrolPoints;
    private int patrolPointNumber = -1;
    private bool onceStartCoroutine = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Patrol();
    }

    private void Update()
    {
        CheckPatrolPosition();
    }

    private void Patrol()
    {
        if (patrolPointNumber != patrolPoints.Length-1)
        {
            patrolPointNumber++;
        }
        else
        {
            patrolPointNumber = 0;
        }
        onceStartCoroutine = true;
        agent.SetDestination(patrolPoints[patrolPointNumber].position);
    }

    private void CheckPatrolPosition()
    {
        if (agent.transform.position.x == patrolPoints[patrolPointNumber].position.x &&agent.transform.position.z == patrolPoints[patrolPointNumber].position.z && onceStartCoroutine == true)
        {
            onceStartCoroutine = false;
            StartCoroutine(WaitForNext());
        }
    }

    IEnumerator WaitForNext()
    {
        float x = Random.Range(0, 360);
        float y = Random.Range(0, 360);
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.Euler(0f, x, 0f), Time.deltaTime * 2f);
        yield return new WaitForSeconds(1.5f);
        agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.Euler(0f, y, 0f), Time.deltaTime * 2f);
        yield return new WaitForSeconds(1.5f);
        Patrol();
    }
}
