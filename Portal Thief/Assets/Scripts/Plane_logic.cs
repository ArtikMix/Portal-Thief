using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane_logic : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject portalVFX;
    private int[] parent_position = new int[2];
    private Player_Properties pl_properties;

    public int[] Parent_Position
    {
        get { return parent_position; }
        set { parent_position = value; }
    }

    void Start()
    {
        pl_properties = FindObjectOfType<Player_Properties>();
    }

    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("Click on " + transform.name);
        PortalSpawn();
    }

    private void PortalSpawn()
    {
        PlaneNumber();
    }

    private void PlaneNumber()
    {
        int portal_radius = pl_properties.Portal_Size;
        GameObject[,] planes = FindObjectOfType<PlanesContainer_logic>().Get_Planes_Container_Dictionary(transform.parent.name);
        //1 четверть
        int I = GroundNPlanesSize(1, planes.GetLength(0), planes.GetLength(1))[0];
        int J = GroundNPlanesSize(1, planes.GetLength(0), planes.GetLength(1))[1];
        for (int i = parent_position[0]; i < I; i++)
        {
            for(int j = parent_position[1]; j < J; j++)
            {
                if (planes[i, j].transform.childCount > 0)
                {
                    if (planes[i, j].transform.GetChild(0).GetComponent<Item_properties>().Weight < pl_properties.Force)
                    {
                        planes[i, j].transform.GetChild(0).GetComponent<Item_properties>().Kidnapping = true;
                    }
                }
            }
        }
        //2 четверть
        for (int i = parent_position[0]; i < parent_position[0] - portal_radius; i--)
        {
            for (int j = parent_position[1]; i < parent_position[1] + portal_radius; j++)
            {
                if (planes[i, j].transform.childCount > 0)
                {
                    //planes[i, j].transform.GetChild(0).GetComponent<Item_properties>()...
                }
            }
        }
        //3 четверть
        for (int i = parent_position[0]; i < parent_position[0] - portal_radius; i--)
        {
            for (int j = parent_position[1]; i < parent_position[1] - portal_radius; j--)
            {
                if (planes[i, j].transform.childCount > 0)
                {
                    //planes[i, j].transform.GetChild(0).GetComponent<Item_properties>()...
                }
            }
        }
        //4 четверть
        for (int i = parent_position[0]; i < parent_position[0] + portal_radius; i++)
        {
            for (int j = parent_position[1]; i < parent_position[1] - portal_radius; j--)
            {
                if (planes[i, j].transform.childCount > 0)
                {
                    //planes[i, j].transform.GetChild(0).GetComponent<Item_properties>()...
                }
            }
        }
    }

    private int[] GroundNPlanesSize(int variant, int x, int z)
    {
        int[] result = new int[2];
        switch (variant)
        {
            case 1:
                {
                    for (int i = pl_properties.Portal_Size; i < 0; i--)
                    {
                        if (parent_position[0] + i <= x)
                        {
                            result[0] = parent_position[0] + i;
                            break;
                        }
                    }
                    for (int i = pl_properties.Portal_Size; i < 0; i--)
                    {
                        if (parent_position[1] + i <= z)
                        {
                            result[1] = parent_position[1] + i;
                            break;
                        }
                    }
                    break;
                }
            case 2:
                {
                    for (int i = pl_properties.Portal_Size; i<0; i--)
                    {
                        if (parent_position[0] - i >= 0)
                        {
                            result[0] = parent_position[0] - i;
                            break;
                        }
                    }
                    for(int i = pl_properties.Portal_Size; i < z; i--)
                    {
                        if (parent_position[1] + i <= z)
                        {
                            result[1] = parent_position[1] + i;
                            break;
                        }
                    }
                    break;
                }
            case 3:
                {
                    for (int i = pl_properties.Portal_Size; i<=0; i--)
                    {
                        if (parent_position[0] - i >= 0)
                        {
                            result[0] = parent_position[0] - i;
                            break;
                        }
                    }
                    for (int i = pl_properties.Portal_Size; i <= 0; i--)
                    {
                        if (parent_position[1] - i >= 0)
                        {
                            result[1] = parent_position[1] - i;
                            break;
                        }
                    }
                    break;
                }
            case 4:
                {
                    for (int i = pl_properties.Portal_Size; i <= x; i--)
                    {
                        if (parent_position[0] + i <= x)
                        {
                            result[0] = parent_position[0] + i;
                            break;
                        }
                    }
                    for (int i = pl_properties.Portal_Size; i <= z; i--)
                    {
                        if (parent_position[1] + i <= z)
                        {
                            result[1] = parent_position[1] + i;
                            break;
                        }
                    }
                    break;
                }
        }
        return result;
    }
}
