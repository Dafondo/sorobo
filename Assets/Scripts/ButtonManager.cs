﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class ButtonManager : MonoBehaviour {

    public GameObject RobotUI;

    //public Transform RobotGrid;

    public Dropdown RobotDropdown;

    public RectTransform RobotList;

    public string directory = @"Assets\Paths";

    public DirectoryInfo directoryPath;

    public string[] files;

    private void Start()
    {
        directoryPath = new DirectoryInfo(directory);
        FileInfo[] fileInfo = directoryPath.GetFiles("*.txt");
        Debug.Log(directoryPath.GetFiles()[0]);
        foreach(FileInfo file in fileInfo)
        {
            RobotDropdown.options.Add(new Dropdown.OptionData() { text = Path.GetFileNameWithoutExtension(file.Name) });
        }
        RobotDropdown.value = 0;
    }

    public void AddBotBtn()
    {
        // string path = EditorUtility.OpenFilePanel("Choose robot path file", "Assets/Paths", "");
        string path = directory + "\\" + RobotDropdown.options[RobotDropdown.value].text + ".txt";

        // Instantiates new robot UI element, places it in the RobotGrid, and passes path parameter
        GameObject robot = Instantiate(RobotUI);
        robot.transform.SetParent(RobotList);
        robot.GetComponent<RobotUIScript>().SetPath(path, RobotDropdown.value);

        GameManager.addPath(path);
    }

    public void StartBtn(string level)
    {
        SceneManager.LoadScene(level);
    }
}
