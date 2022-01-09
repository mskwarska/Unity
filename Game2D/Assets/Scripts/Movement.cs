using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float speed;
    private Animator animat;
    private bool grounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animat = GetComponent<Animator>();
    }



    // Update is called once per frame
    private void Update()
    {
        grounded = true;
        float horizonatal = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizonatal, body.velocity.y);

        //zmiana kierunku poruszania w zale¿noœci od naciœniêtej strza³ki
        if (horizonatal > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizonatal < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //skok
        if(Input.GetKey(KeyCode.Space) && grounded)
            Jump();



        //Set aminatior param
        animat.SetBool("run", horizonatal != 0); // !=0 False
        animat.SetBool("grounded", grounded); // jeœli jest ziemi¹ to mo¿na skoczyæ
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed/3);//skok
        animat.SetTrigger("jump");
        grounded = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;

        
    }
   
}
