using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 25.0f;
    public float turnSpeed = 50.0f;
    private float hInput;
    private float vInput;

 // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
 // makes the p rotate left and right
        transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime * hInput);
 // makes the p move foward and back
        transform.Translate(Vector3.forward * speed * Time.deltaTime * vInput);
    }
}
