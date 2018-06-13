using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    public Texture3D texture;
    public Material matPisoE;

    public static Material matPiso;
    public static Material matPared;

    public LaserLogic laserLogic;

    // Use this for initialization
    void Start()
    {
        laserLogic = new LaserLogic(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        laserLogic.TryToAddCube();

        if (laserLogic.score > 10 && laserLogic.score % 10 == 0)
            laserLogic.IncreaseSpeed();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

}






