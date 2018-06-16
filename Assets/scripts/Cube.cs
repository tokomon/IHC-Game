using System;
using UnityEngine;

public class Cube
{
    public static GameObject CreateCube(String side)
    {
        char direction;
        System.Random rnd = new System.Random();
        int dir = rnd.Next(0, 4);
        if (dir == 0)
            direction = 'u';
        else if (dir == 1)
            direction = 'l';
        else if (dir == 2)
            direction = 'd';
        else
            direction = 'r';

        // TODO: añadir dirección

        // Create 3d object
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        newCube.GetComponent<Renderer>().material.color = Color.red;//.material = Resources.Load("Assets/Materials/down") as Material;
        newCube.AddComponent<Rigidbody>().useGravity = false;
        newCube.GetComponent<BoxCollider>().isTrigger = true;
        newCube.AddComponent<CollisionHandler>();
        newCube.AddComponent<CubeScript>();

        // Si el cubo es del lado izquierdo, entonces se posiciona ahí 
        if (side.Equals("left"))
            newCube.transform.position = new Vector3(5, 0, 0);

        return newCube;
    }
}
