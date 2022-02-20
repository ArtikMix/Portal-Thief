using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Properties
{
    private float run_speed;
    private float portal_size;
    private float portal_distance;
    private float stealth_procent;

    public float Run_Speed
    {
        get { return run_speed;  }
        set { run_speed = value;  }
    }

    public float Portal_Size
    {
        get { return portal_size; }
        set { portal_size = value; }
    }

    public float Portal_Distance
    {
        get { return portal_distance; }
        set { portal_distance = value; }
    }

    public float Stealth_Procent
    {
        get { return stealth_procent; }
        set { stealth_procent = value; }
    }
}
