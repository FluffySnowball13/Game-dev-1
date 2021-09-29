using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 600.0f;
    public float turnSpeed = 6000.0f;
    private float hInput;
    private float vInput;
    public float xRange = 9.17f;
    public float yRange = 4.45f;

 // Update is called once per frame
    void Update()
    {
        // Gathering Keyboard input for movement 
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        // makes the p rotate left and right
        transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * hInput);
        // makes the p move foward and back
        transform.Translate(Vector3.right * speed * Time.deltaTime * vInput);
        // Creates right wall
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        //Creates Left wall
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // Creates top wall
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }
        // Creates bottom wall
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }

        
    }
}
