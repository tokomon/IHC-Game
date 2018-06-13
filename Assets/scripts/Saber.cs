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

    static void UpdateObjectsLeft(LaserLogic logic)
    {
        foreach (Cube cube in logic.CubesLeft)
        {
            // actualiza la posición de un cubo
            if (cube.CubeObject != null)
                cube.CubeObject.transform.Translate(0, 0, logic.Speed * Time.deltaTime);
        }
    }

    static void UpdateObjectsRight(LaserLogic logic)
    {
        foreach (Cube cube in logic.CubesRight)
        {
            // actualiza la posición de un cubo
            if (cube.CubeObject != null)
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
        ProcessLeft();
        ProcessRight();

        laserLogic.TryToAddCube();

        if (laserLogic.score > 10 && laserLogic.score % 10 == 0)
            laserLogic.IncreaseSpeed();
    }

    void ProcessLeft()
    {
        if (laserLogic.CubesLeft.Count == 0)
            return;

        GameObject cubeObject = laserLogic.CubesLeft.Peek().CubeObject;

        // Si el CubeObject es nulo, significa que ya ha sido eliminado en la colisión.
        if (cubeObject == null)
        {
            Debug.Log("YA SE DESTRUYO LEFT");
            laserLogic.RemoveLeft();
            return;
        }

        float pos = cubeObject.transform.position.z;
        if (pos < 15.0f)
            UpdateObjectsLeft(laserLogic);
        else
        { // Si su posición en mayor o igual que 15, ha pasado el límite y se debe descontar una vida.
            if (cubeObject != null)
                Destroy(cubeObject);
            laserLogic.RemoveLeft();
            // TODO: descontar vida.
        }
    }

    void ProcessRight()
    {
        if (laserLogic.CubesRight.Count == 0)
            return;

        GameObject cubeObject = laserLogic.CubesRight.Peek().CubeObject;
        // Si el CubeObject es nulo, significa que ya ha sido eliminado en la colisión.
        if (cubeObject == null)
        {
            Debug.Log("YA SE DESTRUYO RIGHT");
            laserLogic.RemoveRight();
            return;
        }

        float pos = cubeObject.transform.position.z;
        if (pos < 15.0f)
            UpdateObjectsRight(laserLogic);
        else
        {
            if (cubeObject != null)
                Destroy(cubeObject);
            laserLogic.RemoveRight();
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
    }

}






