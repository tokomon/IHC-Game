using Laser2D;
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
    public System.Random rnd = new System.Random();

    static void UpdateObjects(LaserLogic logic)
    {
        foreach (Cube cube in logic.CubesLeft)
        {
            // actualiza la posición de un cubo
            cube.CubeObject.transform.Translate(0, 0, logic.Speed * Time.deltaTime);
        }
        foreach (Cube cube in logic.CubesRight)
        {
            // actualiza la posición de un cubo
            cube.CubeObject.transform.Translate(0, 0, logic.Speed * Time.deltaTime);
        }
    }

    // Use this for initialization
    void Start()
    {
        laserLogic = new LaserLogic(5.0f);
    }

    // Update is called once per frame
    void Update()
    {
        long elapsedTime;
        int pos;
        if (laserLogic.CubesLeft.Count != 0)
        {
            elapsedTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - laserLogic.CubesLeft.Peek().TimeStamp;
            // TODO: en lugar de esto usar la posición del cubo 
            pos = (int)(laserLogic.Speed * elapsedTime / 1000f);
            if (pos < 15)
            {
                UpdateObjects(laserLogic);
            }
            else
            {
                //objects.Peek().GetComponent<Renderer>().material = matPisoE;
                if (laserLogic.CubesLeft.Peek().CubeObject != null)
                    Destroy(laserLogic.CubesLeft.Peek().CubeObject);
                laserLogic.RemoveLeft();
            }

        }

        if (laserLogic.CubesRight.Count != 0)
        {
            elapsedTime = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - laserLogic.CubesRight.Peek().TimeStamp;
            pos = (int)(laserLogic.Speed * elapsedTime / 1000f);
            if (pos < 15)
            {
                UpdateObjects(laserLogic);
            }
            else
            {
                //objects.Peek().GetComponent<Renderer>().material = matPisoE;

                if (laserLogic.CubesRight.Peek().CubeObject != null)
                    Destroy(laserLogic.CubesRight.Peek().CubeObject);
                laserLogic.RemoveRight();
            }
        }

        if (rnd.Next(3) == 2)
            laserLogic.TryToAddCube();

        if (laserLogic.score > 10 && laserLogic.score % 10 == 0)
        {
            laserLogic.IncreaseSpeed();
        }

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

}






