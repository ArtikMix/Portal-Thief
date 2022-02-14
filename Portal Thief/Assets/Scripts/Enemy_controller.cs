using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_controller : MonoBehaviour
{
    private NavMeshAgent agent;
    //патрулирование
    [SerializeField] private Transform[] patrolPoints;
    private int patrolPointNumber = -1;
    private bool onceStartCoroutine = false;
    //поиск
    [SerializeField] private float lampDistance = 10f;
    [SerializeField] private float visionDistance = 15f;
    [SerializeField] private float angle = 70f;
    private Vector3 offset;
    private Transform target;
    private int raysCount = 100;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        Patrol();
    }

    private void Update()
    {
        CheckPatrolPosition();
        Search();
    }
    #region Patrol
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
    #endregion
    private void EnemyVision()
    {

    }
    #region Search
    private int GetRaycast(Vector3 dir)
    {
        int result = 0;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, visionDistance))
        {
            
            if (hit.transform == target && Vector3.Distance(transform.position, target.position)<=lampDistance)
            {
                result = 1;
                Debug.Log("Enemy " + transform.name + " has find PLAYER at 10 (lampDistance)");
                Debug.DrawLine(transform.position, hit.point, Color.red);
                return result;
            }
            if (hit.transform == target && Vector3.Distance(transform.position, target.position)<=visionDistance && Vector3.Distance(transform.position, target.position) > lampDistance)
            {
                result = 2;
                Debug.Log("Enemy " + transform.name + " has find PLAYER at 15 (visionDistance)");
                Debug.DrawLine(transform.position, hit.point, Color.yellow);
                return result;
            }
        }
        return result;
    }

    private int Search()
    {
        float j = 0;
        for (int i = 0; i < raysCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad / raysCount;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));

            switch (GetRaycast(dir))
            {
                case 0: continue;
                case 1: return 1;
                case 2: return 2;
            }
        }
        return 0;
    }
    #endregion
}
