﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;
    public float rotX;
    public float rotY;
    public float rotZ;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void FixedUpdate() {

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w")) {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        } else if (Input.GetKey("w") && !Input.GetKey(KeyCode.LeftShift)) {
            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed;
        } else if (Input.GetKey("s")) {
            transform.position += transform.TransformDirection(Vector3.back) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("a")) {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        } else if (Input.GetKey("a")) {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey("d")) {
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * movementSpeed;
        } else if (Input.GetKey("d")) {
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * movementSpeed;
        }
    }

    void Update () {

        if(Input.GetKeyDown (KeyCode.Space)) {
            if (transform.position.y <= 1.05f) {
                GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
            }
        }

        rotX -= Input.GetAxis("MouseY") * Time.deltaTime * rotationSpeed;
        rotY += Input.GetAxis("MouseX") * Time.deltaTime * rotationSpeed;

        if (rotX < -90) {
            rotX = -90; 
        } else if (rotX > 90) {
            rotX = 90;
        }

        transform.rotation = Quaternion.Euler (0, rotY, 0);
        GameObject.FindWithTag("MainCamera").transform.rotation = Quaternion.Euler (rotX, rotY, 0);
    }
}
