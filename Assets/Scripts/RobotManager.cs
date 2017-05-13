using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class RobotManager : MonoBehaviour {
    private List<string> paths;
    public GameObject robot;

	void Start ()
    {
        // Copies paths from GameManager
        paths = GameManager.paths;
        foreach (string path in paths)
        {
            StreamReader reader = new StreamReader(path);
            string input = reader.ReadToEnd();
            string[] values = input.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            RobotPath robotPath = new RobotPath();
            robotPath.PathType = values[0];

            List<float[]> coordinates = new List<float[]>();
            int i = 1;
            int row = 0;
            int col = 0;
            for(; i < values.Length; i++, col++)
            {
                col %= RobotPath.itemsPerEntry;
                if (col == 0) coordinates.Add(new float[RobotPath.itemsPerEntry]);
                coordinates[row][col] = float.Parse(values[i]);
                if (col >= RobotPath.itemsPerEntry - 1) row++;
            }
            robotPath.Coordinates = coordinates;
            
            // Debugging
            //foreach(float[] entry in robotPath.Coordinates)
            //{
            //    foreach(float item in entry)
            //    {
            //        Debug.Log(item);
            //    }
            //    Debug.Log("-");
            //}

            GameObject newRobot = Instantiate(robot);
            newRobot.GetComponent<RobotMovement>().Path = robotPath;
        }
    }
}
