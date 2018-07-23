﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorScript : MonoBehaviour {


    public float interactDistance = 5; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Disable Mouse Rotation when opening door

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            Debug.Log("Raycast 1");
            if (Physics.Raycast(ray,out hit,interactDistance))
            {
                Debug.Log("Raycast 2");

                if (hit.collider.CompareTag("Door"))
                {
                   // GetComponent<FPSCamera>().IsPeeking = true;

                    hit.collider.transform.parent.GetComponent<DoorScript>().changeDoorState();
                    Debug.Log("Raycast 3");

                }

            }
        }
        //--------------------------------------------------------------------------------------
        // Raycasts in front of the player checking if their is a Door infront of the player 
        //
        // Param 
        //      Direction: the direction in which i want to check if there is a door 
        // Return 
        //      Changes the doorState so that the door can be opened
        //--------------------------------------------------------------------------------------

    }
}

