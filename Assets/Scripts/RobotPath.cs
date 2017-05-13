using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPath
{
    public static int itemsPerEntry = 7;
    string pathType;
    List<float[]> coordinates = new List<float[]>();

    public string PathType
    {
        get
        {
            return pathType;
        }
        set
        {
            pathType = value;
        }
    }

    public List<float[]> Coordinates
    {
        get
        {
            return coordinates;
        }
        set
        {
            coordinates = value;
        }
    }
}
