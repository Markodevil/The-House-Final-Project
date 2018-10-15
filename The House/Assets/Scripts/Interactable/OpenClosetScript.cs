﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClosetScript : MonoBehaviour {

    // Distance in which the player can interact with the door 
    public float interactDistance;
    // Refrences the Camera so it can be locked 
    FPSCamera fpsCamera;
    private GameObject Closet;
    public MonoBehaviour camScript;
    bool isHoldingDown = false;

    // Use this for initialization
    void Start()
    {
        fpsCamera = GetComponent<FPSCamera>();
        Closet = GameObject.FindGameObjectWithTag("Closet");
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward, Color.green);

        //Distance from the Closet to the player 
        Vector3 distance = transform.position - Closet.transform.position;
        distance.y = 0;
        // gets the magnitude of players position and doors position 
        float dist = distance.magnitude;
        //--------------------------------------------------------------------------------------
        // Raycasts in front of the player checking if their is a Closet infront of the player 
        //
        // Param 
        //      Direction: the direction in which i want to check if there is a Closet 
        // Return 
        //      Changes the doorState so that the Closet can be opened
        //--------------------------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Mouse0) && Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.CompareTag("Closet"))
            {
                Closet = hit.collider.gameObject;
                distance = transform.position - Closet.transform.position;
                distance.y = 0;
                dist = distance.magnitude;
                isHoldingDown = true;
                fpsCamera.SetTouching(true);
                //Goes into ClosetScript and allows player to open doors 
                hit.collider.transform.GetComponent<ClosetScript>().ChangeClosetState();
            }
        }

        // if player is holding down mouse1 and moves away from the door
        // camera movement will be enabled 
        if (dist > 4 && isHoldingDown)
        {
            fpsCamera.SetTouching(false);
            isHoldingDown = false;
        }
        //--------------------------------------------------------------------------------------
        // Checks if the Mouse0 button is up  
        //
        // Param 
        //      Determines if Camscript is true 
        // Return 
        //      Changes Camscript to true so player can check cameras 
        //--------------------------------------------------------------------------------------
        if (Input.GetKeyUp(KeyCode.Mouse0) && isHoldingDown)
        {
            //camScript.enabled = true;
            fpsCamera.SetTouching(false);
        }

    }
}