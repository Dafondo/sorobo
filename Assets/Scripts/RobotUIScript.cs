using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotUIScript : MonoBehaviour {
    private RectTransform RobotList;
    public string directory = @"Assets\Paths";
    private string path;
    private int index;
    private int yInitial = -30;
    private int yOffset = 40;
    private Dropdown mainDropdown;
	private Dropdown dropdown;
    private int ddValue;

    private void Awake()
    {
        dropdown = gameObject.GetComponentInChildren<Dropdown>();
    }

    void Start ()
    {
        RobotList = (RectTransform)transform.parent;
        // Finds index of this UI element within the RobotGrid and places it correctly
        index = transform.parent.transform.childCount - 1;
        gameObject.GetComponentInChildren<Text>().text = (index+1).ToString();
        //int y = yInitial - index * yOffset;
        //Vector3 pos = new Vector3(transform.localPosition.x, y, 0);
        //transform.localPosition = pos;

        mainDropdown = GameObject.Find("Canvas/Dropdown").GetComponent<Dropdown>();
        dropdown.options = mainDropdown.options;
        dropdown.value = ddValue;
    }

    // Called when created
    // TODO: Allow path to be changed
    public void SetPath(string path, int ddValue)
    {
        this.path = path;
        Debug.Log(ddValue);
        this.ddValue = ddValue;
    }

    public void ChangePath()
    {
        this.path = directory + "\\" + dropdown.options[dropdown.value].text + ".txt";
        GameManager.paths[index] = this.path;
    }

    // Deletes this UI element and removes path from GameManager
    public void Delete()
    {
        Debug.Log(GameManager.paths[index]);
        GameManager.paths.RemoveAt(index);
        foreach (Transform child in transform.parent.transform)
        {
            child.GetComponent<RobotUIScript>().UpdatePos(index);
        }
        Destroy(gameObject);
    }

    // Updates the position of following UI elements after one has been deleted
    public void UpdatePos(int i)
    {
        if (index > i)
        {
            index--;
            gameObject.GetComponentInChildren<Text>().text = (index+1).ToString();
            //int y = yInitial - index * yOffset;
            //Vector3 pos = new Vector3(transform.localPosition.x, y, 0);
            //transform.localPosition = pos;
        }
    }
}
