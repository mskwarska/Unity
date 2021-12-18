using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformPoints : MonoBehaviour
{
    public float elevatorSpeed = 3f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private int index = 2;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    private float upPosition;
    private float downPosition;
    public List<Vector3> points;
    private Vector3 start;
    private Vector3 stop;
    private bool reverse = false;


    void Start()
    {
        downPosition = transform.position.z + distance;
        upPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningUp && transform.position.z >= downPosition)
        {
            isRunning = false;
        }
        else if (isRunningDown && transform.position.z <= upPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }

        if (isRunning)
        {
            if (Vector3.Distance(transform.position, stop) <= 0.1f)
            {
                isRunning = false;
                if (index < points.Count)
                {
                    start = stop;
                    stop = points[index];
                    index++;
                    isRunning = true;
                }
                else
                {
                    isRunning = false;
                    if (reverse == false)
                    {
                        points.Reverse();
                        start = points[0];
                        stop = points[1];
                        index = 2;
                        reverse = true;
                        isRunning = true;
                    }
                    else
                    {
                        points.Reverse();
                        start = points[0];
                        stop = points[1];
                        index = 2;
                        isRunning = false;
                        reverse = false;
                    }
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform;

            isRunning = true;
        }
    }

}