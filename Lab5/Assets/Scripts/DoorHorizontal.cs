using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHorizontal : MonoBehaviour
{
    public float speed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    private float downPosition;
    private float upPosition;


    void Start()
    {
        upPosition = transform.position.x + distance;
        downPosition = transform.position.x;
    }

    void Update()
    {
        if (isRunningUp && transform.position.x >= upPosition)
        {
            isRunning = false;
        }
        else if (isRunningDown && transform.position.x <= downPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = -transform.right * speed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.x <= downPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                speed = Mathf.Abs(speed);
            }
            else if(transform.position.x >= upPosition)
            {
                isRunningUp = false;
                isRunningDown = true;
                speed = -speed;
            }

            isRunning = true;
        }
    }
}
