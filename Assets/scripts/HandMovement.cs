using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{

    public float speed = 5f;

    private Rigidbody rigBody;

    public KinectWrapper.NuiSkeletonPositionIndex jointRight = KinectWrapper.NuiSkeletonPositionIndex.HandRight;
    public KinectWrapper.NuiSkeletonPositionIndex jointLeft = KinectWrapper.NuiSkeletonPositionIndex.HandLeft;


    // joint position at the moment, in Kinect coordinates
    public Vector3 outputPosition;

    // Use this for initialization
    void Start()
    {
        rigBody = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        KinectManager manager = KinectManager.Instance;

        if (manager && manager.IsInitialized())
        {
            if (manager.IsUserDetected())
            {
                uint userId = manager.GetPlayer1ID();

                if (this.name == "RightHand")
                {
                    if (manager.IsJointTracked(userId, (int)jointRight))

                    {
                        // output the joint position for easy tracking
                        Vector3 jointPosD = manager.GetJointPosition(userId, (int)jointRight);
                        outputPosition = jointPosD;
                        Debug.Log("Derecha: " + jointPosD.ToString());
                        jointPosD.x -= 1;
                        jointPosD.x = jointPosD.x * (-2);// gameObject.transform.position.x;
                        /*  jointPos.y = gameObject.transform.position.y;
                          */
                        jointPosD.z = gameObject.transform.position.z;

                        gameObject.transform.position = jointPosD;


                    }
                }
                else if (this.name == "LeftHand")
                {
                    if (manager.IsJointTracked(userId, (int)jointLeft))
                    {

                        // output the joint position for easy tracking
                        Vector3 jointPos = manager.GetJointPosition(userId, (int)jointLeft);
                        outputPosition = jointPos;
                        Debug.Log("Izquierda: " + jointPos.ToString());
                        jointPos.x -= 2.5f;
                        jointPos.x=jointPos.x * (-2);// gameObject.transform.position.x;
                                          /*   jointPos.y += gameObject.transform.position.y;
                                             */
                        jointPos.z = gameObject.transform.position.z;

                        gameObject.transform.position = jointPos;

                    }
                }
            }
        } else
        {
            if (this.name == "RightHand")
                RightHandMovement();
            else
                LeftHandMovement();
        }
            
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
