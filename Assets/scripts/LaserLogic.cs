using System;
using System.Collections.Generic;

namespace Laser2D
{
    public class LaserLogic
    {
        public Queue<Cube> CubesLeft { get; }
        public Queue<Cube> CubesRight { get; }
        public float CubeSize { get; }
        public float Speed { get; set; }
        Cube LastCubeLeft;
        Cube LastCubeRight;

        public int score;

        public LaserLogic(float speed = 1.0f)
        {
            CubesLeft = new Queue<Cube>();
            CubesRight = new Queue<Cube>();

            CubeSize = 1.0f;
            Speed = speed;

            LastCubeLeft = LastCubeRight = null;

            score = 0;
        }

        public void TryToAddCube()
        {
            Random rnd = new Random();
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
                {
                    AddLeftCube();
                }

                else if (right)
                {
                    AddRightCube();
                }
            }
        }

        private void AddRightCube()
        {
            Cube cube = new Cube();
            CubesRight.Enqueue(cube);
            LastCubeRight = cube;

        }

        private void AddLeftCube()
        {
            Cube cube = new Cube();
            cube.CubeObject.transform.position = new UnityEngine.Vector3(5, 0, 0);
            CubesLeft.Enqueue(cube);
            LastCubeLeft = cube;
        }

        public bool CheckLastLeft()
        {
            if (LastCubeLeft == null || LastCubeLeft.CubeObject == null || CubesRight.Count == 0)
                return true;
            return LastCubeLeft.CubeObject.transform.position.z > 1.2f;
        }

        public bool CheckLastRight()
        {
            if (LastCubeRight == null || LastCubeRight.CubeObject == null || CubesRight.Count == 0)
                return true;
            return LastCubeRight.CubeObject.transform.position.z > 1.2f;
        }

        public void RemoveLeft()
        {
            if (CubesLeft.Count != 0)
                CubesLeft.Dequeue();
        }

        public void RemoveRight()
        {
            if (CubesRight.Count != 0)
                CubesRight.Dequeue();
        }


        public void IncreaseSpeed()
        {
            Speed += Speed * 0.0002f;
        }
    }
}
