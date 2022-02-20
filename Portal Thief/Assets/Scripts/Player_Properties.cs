using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Properties: MonoBehaviour
{
    private float run_speed;
    private int portal_size;
    private float portal_distance;
    private float stealth_procent;
    private float force;

    private void Start()
    {
        if (PlayerPrefs.HasKey("run_speed"))
        {
            run_speed = PlayerPrefs.GetFloat("run_speed");
        }
        else
        {
            run_speed = 25f;
        }

        if (PlayerPrefs.HasKey("portal_size"))
        {
            portal_size = PlayerPrefs.GetInt("portal_size");
        }
        else 
        {
            portal_size = 2;
        }

        if (PlayerPrefs.HasKey("portal_distance"))
        {
            portal_distance = PlayerPrefs.GetFloat("portal_distance");
        }
        else
        {
            portal_distance = 30f;
        }

        if (PlayerPrefs.HasKey("stealth_procent"))
        {
            stealth_procent = PlayerPrefs.GetFloat("stealth_procent");
        }
        else
        {
            stealth_procent = 0f;
        }

        if (PlayerPrefs.HasKey("force"))
        {
            force = PlayerPrefs.GetFloat("force");
        }
        else
        {
            force = 5f;
        }
    }

    public float Run_Speed
    {
        get { return run_speed;  }
        set { run_speed = value;  }
    }

    public int Portal_Size
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

    public float Force
    {
        get { return force; }
        set { force = value; }
    }
}
