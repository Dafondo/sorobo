using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static List<string> paths = new List<string>();

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void addPath(string p)
    {
        paths.Add(p);
        Debug.Log("added: " + p);
    }
}
