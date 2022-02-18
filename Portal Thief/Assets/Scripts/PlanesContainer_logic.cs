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
        int scaleX = Convert.ToInt32(ground.transform.localScale.x);
        int scaleY = Convert.ToInt32(ground.transform.localScale.y);
        Vector3 pos = new Vector3(ground.transform.position.x, ground.transform.position.y + 0.1f, ground.transform.position.z);
        GameObject[,] planes = new GameObject[scaleX,scaleY];
        for (int i = 0; i < scaleX; i++)
        {
            Debug.Log("-");
            for (int j = 0; j < scaleY; j++)
            {
                Debug.Log("*");
                planes[i,j] = Instantiate(standartPlane, pos, Quaternion.identity);
                planes[i, j].transform.SetParent(ground.transform);
                planes[i, j].transform.localPosition = new Vector3(scaleX, planes[i, j].transform.localPosition.y, scaleY);
            }
        }
    }
}
