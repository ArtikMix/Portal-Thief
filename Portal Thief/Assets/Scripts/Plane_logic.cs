using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plane_logic : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject portalVFX;
    private int[] parent_position;
    Player_Properties pl_properties;

    public int[] Parent_Position
    {
        get { return parent_position; }
        set { parent_position = value; }
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
        for(int i = parent_position[0]; i < parent_position[0] + portal_radius; i++)
        {
            for(int j = parent_position[1]; i < parent_position[1] + portal_radius; j++)
            {
                if (planes[i, j].transform.childCount > 0)
                {
                    //if (planes[i,j].transform.GetChild(0).GetComponent<Item_properties>().Weight<)
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
}
