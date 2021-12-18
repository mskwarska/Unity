using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningRight = false;
    private bool isRunningLeft = false;
    private float rightPosition;
    private float leftPosition;

    // Start is called before the first frame update
    void Start()
    {
        rightPosition = transform.position.z + distance;
        leftPosition = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isRunningRight && transform.position.z >= rightPosition)
        {
            isRunning = false;
        }
        else if (isRunningLeft && transform.position.z <= leftPosition)
        {
            isRunning = false;
        }
        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            if (transform.position.z >= rightPosition)
            {
                isRunningLeft = true;
                isRunningRight = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= leftPosition)
            {
                isRunningRight = true;
                isRunningLeft = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
        }
    }

}
