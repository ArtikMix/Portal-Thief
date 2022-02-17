using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanesContainer_logic : MonoBehaviour
{
    private GameObject Ground;
    private GameObject[] grounds;
    private GameObject standartPlane;

    private void Start()
    {
        Ground = GameObject.FindGameObjectWithTag("Ground");
        int i = 0;
        foreach(GameObject ground in Ground.transform)
        {
            grounds[i] = ground;
            CreatePlanes(grounds[i]);
            i++;
        }
    }

    private void CreatePlanes(GameObject ground)
    {
        int x = Convert.ToInt32(ground.transform.localScale.x);
        int y = Convert.ToInt32(ground.transform.localScale.y);
        GameObject[,] planes = new GameObject[x,y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                
            }
        }
    }
}
