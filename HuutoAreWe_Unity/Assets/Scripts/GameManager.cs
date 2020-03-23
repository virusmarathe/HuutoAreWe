using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadLevel("level1.level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string fileName)
    {
        string path = Application.persistentDataPath + "/Levels/" + fileName;

        string readText = File.ReadAllText(path);
        Debug.Log(readText);
    }
}
