using System;
using UnityEngine;

namespace Laser2D
{
    public class Cube
    {
        public long TimeStamp { get; }
        public char Direction { get; }
        public GameObject CubeObject { get; set; }

        private LaserLogic laserLogic;

        public Cube()
        {
            
            System.Random rnd = new System.Random();
            int dir = rnd.Next(0, 4);
            if (dir == 0)
                Direction = 'u';
            else if (dir == 1)
                Direction = 'l';
            else if (dir == 2)
                Direction = 'd';
            else
                Direction = 'r';

            TimeStamp = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            // Create 3d object
            CubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // CubeObject.AddComponent<BoxCollider>();
            // CubeObject.AddComponent<Rigidbody>();
            CubeObject.AddComponent<CollisionHandler>();
        }

        public Cube(char direction)
        {
            Direction = direction;
            TimeStamp = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            CubeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }

        public long DiffTime()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - TimeStamp;
        }
    }
}
