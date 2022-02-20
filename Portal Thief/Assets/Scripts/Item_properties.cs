using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_properties : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float weight;
    private bool kidnapping = false;

    public float Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public float Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public bool Kidnapping
    {
        get { return kidnapping; }
        set { kidnapping = value; }
    }
}
