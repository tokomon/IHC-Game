using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using System;

public class Scene : MonoBehaviour
{
    static public string playerName;
    static public string initialSpeed;
    private void Start()
    {
        try
        {
            initialSpeed = GameObject.Find("Canvas/SpeedN/Text").GetComponent<Text>().text;
            playerName = GameObject.Find("Canvas/NickN/Text").GetComponent<Text>().text;
        }
        catch { }
        

    }
    public void LoadScene(int i)
    {
        
        SceneManager.LoadScene(i);
    }
}
