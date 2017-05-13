using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotUIScript : MonoBehaviour {
    private string path;
    private int index;
    private int elemPerRow = 5;
    private int xInitial = 50;
    private int yInitial = -20;
    private int xOffset = 150;
    private int yOffset = 150;

	void Start ()
    {
        // Finds index of this UI element within the RobotGrid and places it correctly
        index = transform.parent.transform.childCount - 1;
        int x = xInitial + index % elemPerRow * xOffset;
        int y = yInitial - index / elemPerRow * yOffset;
        Vector3 pos = new Vector3(x, y, 0);
        transform.localPosition = pos;
    }

    // Called when created
    // TODO: Allow path to be changed
    public void SetPath(string path)
    {
        this.path = path;
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
            int x = xInitial + index % elemPerRow * xOffset;
            int y = yInitial - index / elemPerRow * yOffset;
            Vector3 pos = new Vector3(x, y, 0);
            transform.localPosition = pos;
        }
    }
}
