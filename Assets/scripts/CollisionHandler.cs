using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private Saber saber;
    public GameObject gamePuntaje;

    void Awake()
    {
        saber = GameObject.FindGameObjectWithTag("GameController").GetComponent<Saber>();
    }

    void Start()
    {
        gamePuntaje = GameObject.FindWithTag("score");
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.blue;

        saber.laserLogic.score += 1;

        gamePuntaje.GetComponent<TextMesh>().text = saber.laserLogic.score.ToString();
 
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
