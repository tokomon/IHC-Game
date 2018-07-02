using System;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic
{
    GameObject lastCubeLeft;
    GameObject lastCubeRight;
    public float cubeSize { get; }
    public float speed { get; set; }
    public int score;
    public int lives;
    public string playerName;

    public LaserLogic(float speed = 1.0f)
    {
        cubeSize = 1.0f;
        this.speed = speed;
        score = 0;
        lives = 9;

        lastCubeLeft = lastCubeRight = null;
    }

    public void TryToAddCube()
    {
        System.Random rnd = new System.Random();
        if (rnd.Next(3) != 2)
            return;

        bool left = CheckLastLeft();
        bool right = CheckLastRight();

        int prob = rnd.Next(100);
        // Añadir dos cubos a la vez.
        if (left && right)
        {
            int doubleProb = rnd.Next(100);
            if (doubleProb < 5) // 30
            {
                AddLeftCube();
                AddRightCube();
                return;
            }
        }
        // Añadir un cubo.
        if (prob < 7) // 45
        {
            if (prob < 3 && left)
                AddLeftCube();

            else if (right)
                AddRightCube();
        }
    }

    private void AddRightCube()
    {
        lastCubeRight = Cube.CreateCube(3);
    }

    private void AddLeftCube()
    {
        lastCubeLeft = Cube.CreateCube(0);
    }

    public bool CheckLastLeft()
    {
        if (lastCubeLeft == null)
            return true;
        return lastCubeLeft.transform.position.z > 1.2f;
    }

    public bool CheckLastRight()
    {
        if (lastCubeRight == null)
            return true;
        return lastCubeRight.transform.position.z > 1.2f;
    }

    public void IncreaseSpeed()
    {
        // TODO: poner una velocidad límite
        speed += speed * 0.002f;
    }
}
