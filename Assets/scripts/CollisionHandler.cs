using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private Saber saber;

    void Awake()
    {
        saber = GameObject.FindGameObjectWithTag("GameController").GetComponent<Saber>();
    }

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        string otherName = other.GetComponent<Collider>().gameObject.name;
        if (otherName != "LeftHand" && otherName != "RightHand")
            return;

        GetComponent<Renderer>().material.color = Color.blue;
        //SoundManagerScript.PlaySound("cube");


        saber.laserLogic.score += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
