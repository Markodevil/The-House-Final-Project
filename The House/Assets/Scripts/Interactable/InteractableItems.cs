﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InteractableItems : MonoBehaviour
{

    public GameObject player;
    public GameObject playerCam;
    float mouseX;
    public float throwForce;
    public float releaseForce;
    public bool playerHere;
    public bool beingCarried;
    public bool touched;

    public AudioClip collisionClip;

    Rigidbody rb;
    AudioSource audioSource;

    public float heading;
    public float speed;

    private Vector3 currentPosition;
    private Vector3 previousPosition;

    private Vector3 localOffset;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        currentPosition = transform.position;
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //currentPosition = transform.position;
        //
        //mouseX = Input.GetAxis("Mouse X");
       //// if (Input.GetKeyUp(KeyCode.T))
       //// {
       ////     rb.AddForce(new Vector3(mouseX * releaseForce, 0, 0));
       ////
       //// }
        //if (beingCarried)
        //{
        //    rb.isKinematic = true;
        //    rb.transform.position = Vector3.Lerp(rb.transform.position, playerCam.transform.position + playerCam.transform.forward * heading, Time.deltaTime * speed);
        //    beingCarried = true;
        //
        //    Vector3 velocity = currentPosition - previousPosition;
        //
        //    if (touched)
        //    {
        //        Drop();
        //        touched = false;
        //    }
        //
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        Drop();
        //        rb.AddForce(playerCam.transform.forward * throwForce);
        //     
        //    }
        //     
        //
        //}
        //
        //
        //previousPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (beingCarried)
        {
            touched = true;

        }

        audioSource.pitch = Random.Range(1, 3);
        audioSource.PlayOneShot(collisionClip);
        CreateSoundColliders();
    }

    public void SetHolding(bool status)
    {
        beingCarried = status;
    }

    public void Drop()
    {
        rb.isKinematic = false;
        transform.parent = null;
       beingCarried = false;
        rb.AddForce(currentPosition - previousPosition);
       // Debug.Log("ButtonUp");
      //  rb.AddForce(new Vector3(mouseX * releaseForce, 0, 0));
      //  rb.AddForce.ri
    }

    public void CreateSoundColliders()
    {
        //GameObject go = new GameObject();
        //go.tag = "Noise";
        //go.hideFlags = HideFlags.HideInHierarchy;
        //go.transform.position = transform.position;
        //
        //go.AddComponent<TestNoises>();

        //SphereCollider sphereCol = go.AddComponent<SphereCollider>();
        //sphereCol.isTrigger = true;
        //sphereCol.radius = 5.0f * audioSource.volume;

        Collider[] hitCollider = Physics.OverlapSphere(transform.position, 2.0f);
        for(int i = 0; i < hitCollider.Length; i++)
        {
            if(hitCollider[i].gameObject.tag == "Ghost")
            {
                //do ghost things
                Debug.Log("ghost can hear player");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2.0f);
    }

}
