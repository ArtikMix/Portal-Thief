using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanesContainer_logic : MonoBehaviour
{
    private GameObject Ground;
    private GameObject[] grounds = new GameObject[10];//
    [SerializeField] private GameObject standartPlane;
    private Dictionary<string, GameObject[,]> planes_container = new Dictionary<string, GameObject[,]>();

    public GameObject[,] Get_Planes_Container_Dictionary(string name)
    {
        return planes_container[name];
    }

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
        float scaleZ = ground.transform.localScale.z;
        Debug.Log("scaleX = " + scaleX + ", scaleZ = " + scaleZ);
        Vector3 pos = new Vector3(ground.transform.position.x, ground.transform.position.y + 0.5f, ground.transform.position.z);
        GameObject[,] planes = new GameObject[Convert.ToInt32(scaleX), Convert.ToInt32(scaleZ)];
        float stepX = -scaleX / 2 + 0.5f;
        float stepZ = scaleZ / 2 + 0.5f;
        for (int i = 0; i < scaleX; i++)
        {
            stepZ = -scaleZ / 2 + 0.5f;
            //Debug.Log("i = " + i);
            for (int j = 0; j < scaleZ; j++)
            {
                //Debug.Log("j = " + j);
                planes[i, j] = Instantiate(standartPlane, pos, Quaternion.identity);
                planes[i, j].transform.SetParent(ground.transform);
                planes[i, j].transform.position = new Vector3(stepX, planes[i, j].transform.position.y, stepZ);
                planes[i, j].GetComponent<Plane_logic>().Parent_Position[0] = i;
                planes[i, j].GetComponent<Plane_logic>().Parent_Position[1] = j;
                stepZ++;
            }
            stepX++;
        }
        planes_container.Add(ground.name, planes);
    }
}
