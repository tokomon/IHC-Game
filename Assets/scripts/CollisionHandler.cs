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

    void OnCollisionEnter(Collision other)
    {
       // Debug.Log("leavingtrigger");

        this.GetComponent<Renderer>().material.color = Color.blue;
       // Destroy(gameObject);
       // gameObject = null;

        saber.laserLogic.score += 1;
      
        gamePuntaje.GetComponent<TextMesh>().text = saber.laserLogic.score.ToString();
        //TO DO
        //destruir objeto en la cola 


        Debug.Log("Score: " + saber.laserLogic.score + " Speed: " + saber.laserLogic.Speed);
        /*  if (other.name == "Detection Zone")
          {
              inSight = true;
          }
  */
    }

    void OnCollisionExit(Collision other)
    {
        // Debug.Log("leavingtrigger");

        /*
        if (other.name == "Detection Zone")
        {
            Debug.Log("leavingtrigger");
            inSight = false;
            Debug.Log("not in sight");
        }*/
    }
}
