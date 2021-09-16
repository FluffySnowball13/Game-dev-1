using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    public float speed = 2.0f;
    public float turnspeed = 10.0f;
    private float hInput;
    private float vInput;

 // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal")
        vInput = Input.GetAxis("Vertical")
 // makes the p rotate left and right
        transform.Rotate(Vector3.up, * turnSpeed * Time.deltaTime * hInput);
 // makes the p move foward and back
        transform.Translate(Vector3.foward * speed * Time.deltaTime * vInput);
    }
}
