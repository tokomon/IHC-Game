using System;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic
{
    GameObject LastCubeLeft;
    GameObject LastCubeRight;
    public float CubeSize { get; }
    public float Speed { get; set; }
    public int score;

    public LaserLogic(float speed = 1.0f)
    {
        CubeSize = 1.0f;
        Speed = speed;

        LastCubeLeft = LastCubeRight = null;

        score = 0;
    }

    public void TryToAddCube()
    {
        System.Random rnd = new System.Random();
        if (rnd.Next(3) != 2)
            return;

        bool left = CheckLastLeft();
        bool right = CheckLastRight();

        int prob = rnd.Next(100);
        // Try to add cubes in both queues.
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
        // Add a cube in one of the queues.
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
        LastCubeRight = Cube.CreateCube("right");
    }

    private void AddLeftCube()
    {
        LastCubeLeft = Cube.CreateCube("left");
    }

    public bool CheckLastLeft()
    {
        if (LastCubeLeft == null)
            return true;
        return LastCubeLeft.transform.position.z > 1.2f;
    }

    public bool CheckLastRight()
    {
        if (LastCubeRight == null)
            return true;
        return LastCubeRight.transform.position.z > 1.2f;
    }

    public void IncreaseSpeed()
    {
        Speed += Speed * 0.002f;
    }
}
