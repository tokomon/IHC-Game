using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Saber : MonoBehaviour
{
   
    public Texture3D texture;
    public Material matPisoE;

    public static Material matPiso;
    public static Material matPared;

    public LaserLogic laserLogic;

    public Text scoreText;
    public Text playerNameText;
    public Text livesText;


    // Use this for initialization
    void Start()
    {
        laserLogic = new LaserLogic(5.0f);

        playerNameText = GameObject.Find("/Canvas/PlayerName").GetComponent<Text>();
        scoreText = GameObject.Find("/Canvas/Score").GetComponent<Text>();
        livesText = GameObject.Find("/Canvas/Lives").GetComponent<Text>();

        playerNameText.text = laserLogic.playerName = Scene.playerName;
        Debug.Log("NAME: "+ laserLogic.playerName);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        laserLogic.TryToAddCube();

        scoreText.text = laserLogic.score.ToString("0000000000");
        livesText.text = laserLogic.lives.ToString("00");

        if (laserLogic.score > 10 && laserLogic.score % 10 == 0)
            laserLogic.IncreaseSpeed();

        // Si se tienen 0 vidas se pierde:
        if (laserLogic.lives <= 0)
        {
            // TODO: esto hace que luego se pueda seguir jugando?
            Time.timeScale = 0;

            //Score.scoreList.Add(playerNameText.text +" "+scoreText.text );
            Score.WriteScoreFile(laserLogic.playerName, laserLogic.score);
            SceneManager.LoadScene(2);

        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

}






