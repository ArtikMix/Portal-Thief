using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanesContainer_logic : MonoBehaviour
{
    private GameObject Ground;
    private GameObject[] grounds = new GameObject[10];//
    [SerializeField] private GameObject standartPlane;

    private void Start()
    {
        Ground = GameObject.FindGameObjectWithTag("Ground");
        int i = 0;
        foreach(Transform ground in Ground.transform)
        {
            Debug.Log("+");
            grounds[i] = ground.gameObject;
            CreatePlanes(grounds[i]);
            i++;
        }
    }

    private void CreatePlanes(GameObject ground)
    {
        float scaleX = ground.transform.localScale.x;
        float scaleY = ground.transform.localScale.y;
        Vector3 pos = new Vector3(ground.transform.position.x, ground.transform.position.y + 0.1f, ground.transform.position.z);
        GameObject[,] planes = new GameObject[Convert.ToInt32(scaleX), Convert.ToInt32(scaleY)];
        float stepX = -0.5f;
        float stepY = -0.5f;
        for (int i = 0; i < scaleX; i++)
        {
            Debug.Log("-");
            for (int j = 0; j < scaleY; j++)
            {
                Debug.Log("*");
                planes[i,j] = Instantiate(standartPlane, pos, Quaternion.identity);
                planes[i, j].transform.SetParent(ground.transform);
                planes[i, j].transform.position = new Vector3(stepX, planes[i, j].transform.position.y, stepY);
                stepY = stepY + 1 / scaleY;
            }
            stepX = stepX + 1 / scaleX;
        }
    }
}
