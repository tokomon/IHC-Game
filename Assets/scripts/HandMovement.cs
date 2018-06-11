using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{

    public float speed = 5f;

    private Rigidbody rigBody;

    // Use this for initialization
    void Start()
    {
        rigBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "LeftHand")
            LeftHandMovement();
        else
            RightHandMovement();
    }

    void LeftHandMovement()
    {
        Vector3 destination = this.transform.position;
        if (Input.GetKey(KeyCode.A))
            destination.x++;
        if (Input.GetKey(KeyCode.D))
            destination.x--;
        if (Input.GetKey(KeyCode.W))
            destination.y++;
        if (Input.GetKey(KeyCode.S))
            destination.y--;

        transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
    }

    void RightHandMovement()
    {
        Vector3 destination = this.transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
            destination.x++;
        if (Input.GetKey(KeyCode.RightArrow))
            destination.x--;
        if (Input.GetKey(KeyCode.UpArrow))
            destination.y++;
        if (Input.GetKey(KeyCode.DownArrow))
            destination.y--;

        transform.position = Vector3.Lerp(transform.position, destination, speed * Time.deltaTime);
    }




}
