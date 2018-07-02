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

        Vector3 destination = this.transform.position;
        destination.y-=5;
        
        transform.position = Vector3.Lerp(transform.position, destination, 5f * Time.deltaTime);
    
        //SoundManagerScript.PlaySound("cube");


        saber.laserLogic.score += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

        Vector3 destination = this.transform.position;
        destination.y-=1;

        transform.position = Vector3.Lerp(transform.position, destination, 5f * Time.deltaTime);

        Destroy(gameObject);
    }
}
