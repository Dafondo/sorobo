using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour {
    private RobotPath path;
    private double totalTime;
    private int step;
    private int frameCounter;

	void Start ()
    {
        totalTime = 0;
        step = 0;
        frameCounter = 0;
	}

	void Update ()
    {    
		if(path.PathType == "S")
        {
            totalTime += Time.deltaTime;
            if (step < path.Coordinates.Count)
            {
                float[] coord = path.Coordinates[step];
                if (totalTime >= coord[0])
                {
                    Vector3 newPos = new Vector3(coord[1], coord[2], coord[3]);
                    Vector3 relativePos = newPos - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(relativePos);
                    transform.position = newPos;
                    transform.rotation = rotation;
                    step++;
                    //Debug.Log(transform.position);
                    //Debug.Log(transform.eulerAngles);
                }
                
            }
        }
        if(path.PathType == "Fn")
        {

        }
	}

    void FixedUpdate()
    {
        if(path.PathType == "F")
        {
            if (step < path.Coordinates.Count)
            {
                float[] coord = path.Coordinates[step];
                if (frameCounter >= coord[0])
                {
                    Vector3 newPos = new Vector3(coord[1], coord[2], coord[3]);
                    Vector3 relativePos = newPos - transform.position;
                    Quaternion rotation = Quaternion.LookRotation(relativePos);
                    transform.position = newPos;
                    transform.rotation = rotation;
                    step++;
                }
            }
            frameCounter++;
        }
    }

    public RobotPath Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }
}
