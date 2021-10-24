using UnityEngine;

public class skrzynia : MonoBehaviour
{
    public float force= 10f;
    Rigidbody rb;
    public int changeMove = 0; // 0 - move right, 1 - move left
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (changeMove == 0)
        {
            if (transform.position.x >= 10f)
                changeMove = 1;

            transform.position = transform.position + new Vector3(force , 0, 0) * Time.deltaTime;
        }
        else
        {
            if (transform.position.x <= 0f)
                changeMove = 0;

            transform.position = transform.position + new Vector3(-force , 0, 0) * Time.deltaTime;
        }
    }
}