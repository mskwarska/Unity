using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZad4 : MonoBehaviour
{
    public float speed = 1.5f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        transform.position += moveDirection * speed;

    }
    
    void OnCollision(Collision col)
    {
        if (col.gameObject.tag == "obstacle")
        {
            Debug.Log("Collision Detected");
        }

    }
}
