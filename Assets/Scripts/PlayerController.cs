﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;//0 for right and 2 for left;
    public float laneDistance = 4; //distance btw two lanes
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        //get input for the desiredLane
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            desiredLane++;
            if(desiredLane==3){
                desiredLane=2;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            desiredLane--;
            if(desiredLane==-1){
                desiredLane=0;
            }
        }
//Calculate future position

    Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;
        transform.position=targetPosition;
        //To add smoothness in changing lanes
        // transform.position= Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);
     }

     private void FixedUpdate()
    {
        controller.Move(direction*Time.fixedDeltaTime);
    }


}