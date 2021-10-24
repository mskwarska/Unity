using UnityEngine;

public class SquareMove : MonoBehaviour
{
     public float force = 10.0f;
     public Rigidbody rb;
     public int changeMove=2;// = 2; // 1 - move right, 2 - move left, 3 - move up, 4- move down
     void Start()
     {
         rb = GetComponent<Rigidbody>();
     }
     void Update()
     {
         // 1 - move right
         if (changeMove == 1)
         {
             if (transform.position.x >= 10f )
                 changeMove = 3;
                 
             //transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
             transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
             transform.position = transform.position + new Vector3(force, 0, 0) * Time.deltaTime;
         }
         //  2 - move left
         else if (changeMove == 2)
         {
             if (transform.position.x <= 0)
                 changeMove = 4;
                 
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            transform.position  = transform.position + new Vector3(-force, 0, 0) * Time.deltaTime;
         }
         // 3 - move up
         else if(changeMove == 3)
         {
             if (transform.position.z >= 10f)
                 changeMove = 2;

             transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
             transform.position = transform.position + new Vector3(0, 0, force) * Time.deltaTime;
         }
        // changeMove == 4,  4 - move down
        else
        {
             if (transform.position.z <= 0f)
                 changeMove = 1;
                 
             transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
             transform.position = transform.position + new Vector3(0, 0, -force) * Time.deltaTime;
         }
     }
}
