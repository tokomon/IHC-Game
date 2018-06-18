using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        other.GetComponent<Renderer>().material.color = Color.blue;
        Debug.Log("ENTER COLOR");

        SoundManagerScript.PlaySound("cube");
        Debug.Log("HAND ENTER");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("HAND STAY");
    }

    private void OnTriggerExit(Collider other)
    {
        
        Destroy(other);
        Debug.Log("HAND EXIT");
    }
}
