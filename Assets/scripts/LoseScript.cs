﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject.Find("PlayerName").GetComponent<Text>().text = Scene.playerName;// Saber.laserLogic.playerName;
        GameObject.Find("Score").GetComponent<Text>().text = Saber.score;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
