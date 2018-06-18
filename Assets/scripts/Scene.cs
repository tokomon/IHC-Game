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
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        // Si la escena es: Pantalla perdiste
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject.Find("Canvas/PlayerName").GetComponent<Text>().text = "hola";
            GameObject.Find("Canvas/Score").GetComponent<Text>().text = "000123123";
        }

    }
    public void LoadScene(int i)
    {
        // Si la escena es: Pantalla inicio 
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            initialSpeed = GameObject.Find("Canvas/SpeedN/Text").GetComponent<Text>().text;
            playerName = GameObject.Find("Canvas/NickN/Text").GetComponent<Text>().text;
        }
        SceneManager.LoadScene(i);
    }
}
