using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
using System;

public class Scene : MonoBehaviour
{
    public InputField SpeedN;
    public InputField NickN;
    public string name;
    private void Start()
    {
        SpeedN = (InputField)GameObject.Find("SpeedN").GetComponent<InputField>();
        NickN = (InputField)GameObject.Find("NickN").GetComponent<InputField>();
        name = NickN.text;
    }
    public void LoadScene()
    {
        
        SceneManager.LoadScene(1);
    }
}
