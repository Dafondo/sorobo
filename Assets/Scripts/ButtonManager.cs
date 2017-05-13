using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ButtonManager : MonoBehaviour {

    public GameObject RobotUI;

    public Transform RobotGrid;

    public void AddBotBtn()
    {
        string path = EditorUtility.OpenFilePanel("Choose robot path file", "Assets/Test", "");

        // Instantiates new robot UI element, places it in the RobotGrid, and passes path parameter
        GameObject robot = Instantiate(RobotUI);
        robot.transform.SetParent(RobotGrid);
        robot.GetComponent<RobotUIScript>().SetPath(path);

        GameManager.addPath(path);
    }

    public void StartBtn(string level)
    {
        SceneManager.LoadScene(level);
    }
}
