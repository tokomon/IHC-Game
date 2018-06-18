using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{

    private Saber saber;

    void Awake()
    {
        saber = GameObject.FindGameObjectWithTag("GameController").GetComponent<Saber>();
    }

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float pos = transform.position.z;
        if (pos < 15.0f)
            transform.Translate(0, 0, saber.laserLogic.speed * Time.deltaTime);
        else
        { // Si su posición en mayor o igual que 15, ha pasado el límite y se debe descontar una vida.
            Destroy(gameObject);
            //saber.laserLogic.lives--;
            Debug.Log("CUBE PASSED");
            // TODO: descontar vida.
        }
    }
}
